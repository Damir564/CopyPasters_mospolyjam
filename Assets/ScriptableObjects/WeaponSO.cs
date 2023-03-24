using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/WeaponSO", order = 0)]
public class WeaponSO : ScriptableObject
{
    [Header("Prefabs")]
    [SerializeField] private GameObject m_bulletPrefab;
    [SerializeField] private GameObject m_headPrefab;
    [Header("Weapon properties")]
    [SerializeField] private float m_bulletForce;
    [SerializeField] private float m_bulletDestroyTime;
    [SerializeField] private AudioClip m_weaponSoundShoot;
    [SerializeField] private float m_weaponFireRate;
    [SerializeField] private float m_weaponReloadTime;
    [SerializeField] private int m_weaponAllTotalAmmo;
    [SerializeField] private int m_weaponTotalAmmo;
    [SerializeField] private int[] m_weaponScope;
    [SerializeField] private float[] m_weaponScopeMultiplier;
    [SerializeField] private Color m_weaponImage;


    public GameObject BulletPrefab
    {
        get => m_bulletPrefab;
    }
    public GameObject HeadPrefab
    {
        get => m_headPrefab;
    }
    public float BulletForce
    {
        get => m_bulletForce;
    }
    public float BulletDestroyTime
    {
        get => m_bulletDestroyTime;
    }
    public AudioClip WeaponSoundShoot
    {
        get => m_weaponSoundShoot;
    }
    public float WeaponFireRate
    {
        get => m_weaponFireRate;
    }
    public float WeaponReloadTime
    {
        get => m_weaponReloadTime;
    }
    public int WeaponAllTotalAmmo
    {
        get => m_weaponAllTotalAmmo;
    }
    public int WeaponTotalAmmo
    {
        get => m_weaponTotalAmmo;
    }
    public int[] WeaponScope
    {
        get => m_weaponScope;
    }
    public float[] WeaponScopeMultiplier
    {
        get => m_weaponScopeMultiplier;
    }
    public Color WeaponImage
    {
        get => m_weaponImage;
    }
}