using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameStates {
        Cutscene,
        Playable
    }

    [SerializeField] private Transform allBulletsParent;
    public Transform AllBulltesParent
    {
        get => allBulletsParent;
    }

    private SlowMotion slowMotion;
    public SlowMotion SlowMotion
    {
        get => slowMotion;
    }

    private GameStates gameState = GameStates.Cutscene;
    public GameStates GameState
    {
        get => gameState;
        set 
        {
            gameState = value;
        }
    }

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
    [SerializeField] private List<GameObject> m_levelTriggers;
    public List<GameObject> LevelTriggers
    {
        get => m_levelTriggers;
    }

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

    private int m_lastScene;

    public int LastScene
    {
        get => m_lastScene;
    }

    private void Awake()
    {
        if (m_instance == null)
            m_instance = this;
        else
            Destroy(this);
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name != "Level_Begin")
            gameState = GameStates.Playable;
        Instance.PlayerEvents.ChangeSceneEvent += StartLevel;
        Instance.slowMotion = GetComponent<SlowMotion>();
    }

    private void OnDisable()
    {
        Instance.PlayerEvents.ChangeSceneEvent -= StartLevel;
    }

    private void StartLevel(int number)
    {
        if (number == -1)
            Application.Quit();
        else if (number == -2)
        {
            m_lastScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            SceneManager.LoadScene(number);
            Destroy(this.gameObject);
        }
    }

    private void OnEnable()
    {
        m_player = GameObject.FindGameObjectWithTag("Player").transform;
        // m_triggers.AddRange(GameObject.FindGameObjectsWithTag("GameController"));
    }
}
