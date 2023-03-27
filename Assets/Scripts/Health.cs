using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private SpriteRenderer[] flashedSprites;
    private SpriteRenderer weaponToFlash;
    private Material originalMaterial;
    [SerializeField] private Material flashedMaterial;
    [SerializeField] private Material healedMaterial;
    [SerializeField] private float flashDuration = 0.1f;

    private int m_currentHealth;

    // Start is called before the first frame update
    private void Start()
    {
        if (flashedSprites.Length > 0)
            originalMaterial = flashedSprites[0].material;
        m_currentHealth = maxHealth;
        this.HealthChange(0);
        GameManager.Instance.PlayerEvents.WeaponChangedEvent += AddWeaponToFlash;
        // Debug.Log(m_currentHealth);
    }
    private void OnDisable()
    {
        GameManager.Instance.PlayerEvents.WeaponChangedEvent -= AddWeaponToFlash;
    }

    private void AddWeaponToFlash(GameObject weaponObj)
    {
        weaponToFlash = weaponObj.GetComponent<SpriteRenderer>();
    }

    private void HealthChange(int value)
    {
        OnHealthChanged(value);
        if (m_currentHealth <= 0)
        {
            OnGameOver();
        }
    }

    private void OnGameOver()
    {
        GameManager.Instance.PlayerEvents.RaiseChangeSceneEvent(-2);
        if (!GameManager.Instance.SlowMotion.IsNormalTime)
            GameManager.Instance.PlayerEvents.RaiseTimeSnapEvent();
        Debug.Log("Game over");
    }

    private void OnHealthChanged(int value)
    {
        m_currentHealth += value;
        // GameManager.Instance.PlayerEvents.RaiseWeaponImageAndCameraFollowChangeEvent(m_weaponValues.WeaponImage, m_head.transform.GetChild(1));
        // OnScopeChanged();
        if (value < 0)
        {
            Invoke("FlashMaterial", 0f);
            Invoke("OriginalMaterial", flashDuration);
        }
        if (value > 0)
        {
            Invoke("HealMaterial", 0f);
            Invoke("OriginalMaterial", flashDuration);
        }
        if (m_currentHealth > maxHealth)
            m_currentHealth = maxHealth;
        string temp = "Health: " + m_currentHealth.ToString() + "/" + maxHealth.ToString(); 
        GameManager.Instance.PlayerEvents.RaiseHealthChangedEvent(temp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FlashMaterial()
    {
        foreach (SpriteRenderer elem in flashedSprites)
        {
            elem.material = flashedMaterial;
        }
        weaponToFlash.material = flashedMaterial;
    }
        private void HealMaterial()
    {
        foreach (SpriteRenderer elem in flashedSprites)
        {
            elem.material = healedMaterial;
        }
        weaponToFlash.material = healedMaterial;
    }

    private void OriginalMaterial()
    {
        foreach (SpriteRenderer elem in flashedSprites)
        {
            elem.material = originalMaterial;
        }
        weaponToFlash.material = originalMaterial;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("EnemyBullet"))
        {
            // Debug.Log(m_currentHealth);
            HealthChange(-1);
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Equals("Heal"))
        {
            Debug.Log(collider.name);
            HealthChange(2);
            Destroy(collider.gameObject);
        }
    }
}

