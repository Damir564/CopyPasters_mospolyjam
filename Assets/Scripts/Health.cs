using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int m_currentHealth;

    // Start is called before the first frame update
    private void Start()
    {
        m_currentHealth = maxHealth;
        this.HealthChange(0);
        // Debug.Log(m_currentHealth);
    }

    private void HealthChange(int value)
    {
        m_currentHealth -= value;
        OnHealthChanged(m_currentHealth);
        if (m_currentHealth <= 0)
        {
            OnGameOver();
        }
    }

    private void OnGameOver()
    {
        Debug.Log("Game over");
    }

    private void OnHealthChanged(int value)
    {
        // GameManager.Instance.PlayerEvents.RaiseWeaponImageAndCameraFollowChangeEvent(m_weaponValues.WeaponImage, m_head.transform.GetChild(1));
        // OnScopeChanged();
        string temp = "Health: " + value.ToString() + "/" + maxHealth.ToString(); 
        GameManager.Instance.PlayerEvents.RaiseHealthChangedEvent(temp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("EnemyBullet"))
        {
            // Debug.Log(m_currentHealth);
            HealthChange(1);
            Destroy(collision.gameObject);
        }
    }
}

