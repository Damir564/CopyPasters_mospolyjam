using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum Weapons
    {
        Simple,
        Shotgun,
        Sniper,
        Rapid,
        Machinegun
    }
    [SerializeField]
    private WeaponSO[] m_weaponSOs;

    public WeaponSO[] WeaponSOs
    {
        get => m_weaponSOs;
    }

    private static GameManager m_instance;

    public static GameManager Instance
    {
        get => m_instance;
    }

    private void Awake()
    {
        if (m_instance == null)
            m_instance = this;
        else
            Destroy(this);
    }
}
