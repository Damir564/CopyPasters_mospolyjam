using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;

    [SerializeField] private SpriteRenderer[] flashedSprites;
    private Material originalMaterial;
    [SerializeField] private Material flashedMaterial;
    private int m_currentHealth;
    [SerializeField] private float flashDuration = 0.1f;

    // Start is called before the first frame update
    private void Start()
    {
        if (flashedSprites.Length > 0)
            originalMaterial = flashedSprites[0].material;
        m_currentHealth = maxHealth;
        this.HealthChange(0);
        // Debug.Log(m_currentHealth);
    }

    private void HealthChange(int value)
    {
        OnHealthChanged(value);
        if (m_currentHealth <= 0)
        {
            Destroy(transform.gameObject, flashDuration);
        }
    }

    private void OnHealthChanged(int value)
    {
        m_currentHealth -= value;
        // GameManager.Instance.PlayerEvents.RaiseWeaponImageAndCameraFollowChangeEvent(m_weaponValues.WeaponImage, m_head.transform.GetChild(1));
        // OnScopeChanged();
        if (value > 0)
        {
            Invoke("FlashMaterial", 0f);
            Invoke("OriginalMaterial", flashDuration);
        }
        // GameManager.Instance.PlayerEvents.RaiseWeaponImageAndCameraFollowChangeEvent(m_weaponValues.WeaponImage, m_head.transform.GetChild(1));
        // OnScopeChanged();
        // string temp = "Health: " + value.ToString() + "/" + maxHealth.ToString(); 
        // GameManager.Instance.PlayerEvents.RaiseHealthChangedEvent(temp);
    }

    private void FlashMaterial()
    {
        foreach (SpriteRenderer elem in flashedSprites)
        {
            elem.material = flashedMaterial;
        }
    }

    private void OriginalMaterial()
    {
        foreach (SpriteRenderer elem in flashedSprites)
        {
            elem.material = originalMaterial;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            // Debug.Log("Enemy health: " + m_currentHealth);
            HealthChange(1);
            Destroy(collision.gameObject);
        }
    }
}

