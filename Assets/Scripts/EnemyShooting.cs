using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    // WeaponHolder
    [SerializeField] private Transform weaponHolder;
    [SerializeField] 
    private GameObject m_head;

    private Transform m_allBulletsParent;
    private Transform m_bulletExit;
    private AudioSource m_audioSource;
    //[SerializeField] 
    private WeaponSO m_weaponValues;
    private bool m_isNotReloading = true;
    // private int m_scopingState = 0;
    private int m_currentWeaponIndex;
    private int m_currentAllAmmo;
    private int m_currentAmmo;
    private float m_nextFireTime = 0f;
    private bool isNormalTime = true;
    [SerializeField] private float defaultMinPtch = 0.9f;
    private float timePitchDelta = 0f;

    private float volumeMin = 0.5f;
    private float volumeMax = 0.7f;

    private void Start()
    {
        GameManager.Instance.PlayerEvents.TimeSnapEvent += PitchChange;
        m_allBulletsParent = GameManager.Instance.AllBulltesParent;
        this.WeaponChange(2);
    }

    private void OnDisable()
    {
        GameManager.Instance.PlayerEvents.TimeSnapEvent -= PitchChange;
    }
    

    private void PitchChange()
    {
        isNormalTime = !isNormalTime;
        if (!isNormalTime)
        {
            timePitchDelta = 0.5f;
        }
        else
            timePitchDelta = 0f;
    }
    

    private void Update()
    {
        // if (Input.GetButton("Fire1"))
        //     Shoot();
        // if (Input.GetButton("Reload"))
        //     OnReloading();
    }

    private void OnReloading()
    {
        if (m_isNotReloading && m_currentAmmo != m_weaponValues.WeaponTotalAmmo && m_currentAllAmmo != 0)
        {
            m_audioSource.pitch = Random.Range(defaultMinPtch - timePitchDelta, 1.1f - timePitchDelta);
            m_audioSource.volume = Random.Range(volumeMin, volumeMax);
            m_audioSource.PlayOneShot(m_weaponValues.WeaponSoundReload);
            StartCoroutine(Reloading());
            m_isNotReloading = false;
        }
    }

    private void OnWeaponChanged()
    {
        // GameManager.Instance.PlayerEvents.RaiseWeaponImageAndCameraFollowChangeEvent(m_weaponValues.WeaponImage, m_head.transform.GetChild(1));
        // OnScopeChanged();
        // OnAmmoAmountChanged();
    }

    // private void OnScopeChanged()
    // {
    //     // GameManager.Instance.PlayerEvents.RaiseScopeChangedEvent(m_weaponValues.WeaponScope[m_scopingState], m_weaponValues.WeaponScopeMultiplier[m_scopingState]);
    // }

    private void OnAmmoAmountChanged()
    {
        string temp = m_currentAmmo + "|" + m_currentAllAmmo;
        GameManager.Instance.PlayerEvents.RaiseAmmoChangedEvent(temp);
    }

    // private void OnScoping()
    // {
    //     if (m_scopingState < m_weaponValues.WeaponScope.Length - 1)
    //     {
    //         m_scopingState += 1;
    //     }
    //     else
    //     {
    //         m_scopingState = 0;
    //     }
    //     Debug.Log(m_scopingState + "!!");
    //     OnScopeChanged();
    //     // m_pixelPerfect.assetsPPU = m_weaponValues.WeaponScope[m_scopingState];
    // }

    public void Shoot()
    {
        if (m_currentAmmo == 0)
            OnReloading();
        if (!m_isNotReloading || Time.time < m_nextFireTime)
            return;
        m_nextFireTime = Time.time + m_weaponValues.WeaponFireRate;
        GameObject bullet = Instantiate(m_weaponValues.BulletPrefab, m_bulletExit.position, m_bulletExit.rotation, m_allBulletsParent);
        bullet.name = "Player";
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(m_bulletExit.right * m_weaponValues.BulletForce, ForceMode2D.Impulse);
        m_audioSource.pitch = Random.Range(defaultMinPtch - timePitchDelta, 1.1f - timePitchDelta);
        m_audioSource.volume = Random.Range(volumeMin, volumeMax);
        m_audioSource.PlayOneShot(m_weaponValues.WeaponSoundShoot);
        Destroy(bullet, m_weaponValues.BulletDestroyTime);
        m_currentAmmo -= 1;
        // OnAmmoAmountChanged();
    }

    private void WeaponChange(int weaponid)  
    {
        // if (m_head != null)
        // {
        //     Destroy(m_head);
        //     Debug.Log(m_head);
        //     m_head = null;
        // }
        m_weaponValues = GameManager.Instance.WeaponSOs[weaponid];
        // m_head = Instantiate(m_weaponValues.HeadPrefab, weaponHolder);
        m_bulletExit = m_head.transform.GetChild(0);
        m_audioSource = m_head.GetComponent<AudioSource>();
        m_currentAllAmmo = m_weaponValues.WeaponAllTotalAmmo;
        m_currentAmmo = m_weaponValues.WeaponTotalAmmo;
        OnWeaponChanged();
    }

    IEnumerator Reloading()
    {
        yield return new WaitForSeconds(m_weaponValues.WeaponReloadTime);
        if (m_currentAllAmmo + m_currentAmmo > m_weaponValues.WeaponTotalAmmo)
        {
            m_currentAllAmmo -= m_weaponValues.WeaponTotalAmmo - m_currentAmmo;
            m_currentAmmo = m_weaponValues.WeaponTotalAmmo;
        }
        else
        {
            m_currentAmmo = m_currentAllAmmo + m_currentAmmo;
            m_currentAllAmmo = 0;
        }
        m_isNotReloading = true;
        // OnAmmoAmountChanged();
    }
}
