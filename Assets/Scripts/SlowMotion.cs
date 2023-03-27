using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    
    [SerializeField] private float m_slowMoValue;
    public float SlowMoValue
    {
        get => m_slowMoValue;
    }

    private float m_normalTime = 1;
    private bool isNormalTime = true;

    public bool IsNormalTime
    {
        get => isNormalTime;
    }

    private void Start()
    {
        GameManager.Instance.PlayerEvents.TimeSnapEvent += TimeSnap;
    }

    private void OnDisable()
    {
        GameManager.Instance.PlayerEvents.TimeSnapEvent -= TimeSnap;
    }

    public void TimeSnap()
    {
        if (isNormalTime)
            slowMotion();
        else
            normalise();
        isNormalTime = !isNormalTime;
    }
    private void slowMotion()
    {
        Time.timeScale = m_slowMoValue;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        // GameManager.Instance.Player.GetComponent<Movement>()
    }
    private void normalise()
    {
        Time.timeScale = m_normalTime;

    }
}