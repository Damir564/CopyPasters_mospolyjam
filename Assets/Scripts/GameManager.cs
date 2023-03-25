using System;
using System.Collections.Generic;
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

    private Transform m_player;
    

    public Transform Player
    {
        get => m_player;
    }

    [SerializeField] private List<GameObject> m_triggers;

    public List<GameObject> Triggers
    {
        get => m_triggers;
    }

    public WeaponSO[] WeaponSOs
    {
        get => m_weaponSOs;
    }

    [SerializeField] private PlayerEventsSO m_playerEvents;

    public PlayerEventsSO PlayerEvents
    {
        get => m_playerEvents;
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

    private void OnEnable()
    {
        m_player = GameObject.FindGameObjectWithTag("Player").transform;
        // m_triggers.AddRange(GameObject.FindGameObjectsWithTag("GameController"));
    }
}
