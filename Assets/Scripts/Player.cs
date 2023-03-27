using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{
    [SerializeField] private Health healthScript;
    [SerializeField] private Shooting shootingScript;
    [SerializeField] private Movement movementScript;
    [SerializeField] private Transform idleArms;
    [SerializeField] private Transform moveArms;
    [SerializeField] private CinemachineVirtualCamera vcam;
    [SerializeField] private Canvas gameCanvas;
    [SerializeField] private Canvas tutorialCanvas;
    [SerializeField] private GameObject actionDialogue;
    [SerializeField] private Transform[] objectsToEnable;
    [SerializeField] private Transform[] objectsToDisable;

    private void Start()
    {
        vcam.m_Lens.OrthographicSize = 2;
    }

    public void ActivateActionDialogue()
    {
        actionDialogue.SetActive(true);
    }

    public void GrabWeapon()
    {
        objectsToDisable[0].gameObject.SetActive(false);
        objectsToEnable[0].gameObject.SetActive(true);
        objectsToEnable[1].gameObject.SetActive(true);
        idleArms.gameObject.SetActive(false);
        moveArms.gameObject.SetActive(true);
        healthScript.enabled = true;
        shootingScript.enabled = true;
    }

    public void UseTimeSnap()
    {
        foreach (Transform elem in objectsToEnable)
        {
            elem.gameObject.SetActive(true);
        }
        foreach (Transform elem in objectsToDisable)
        {
            elem.gameObject.SetActive(false);
        }
        vcam.m_Lens.OrthographicSize = 6;
        movementScript.enabled = true;
        gameCanvas.enabled = true;
        tutorialCanvas.enabled = false;
        GameManager.Instance.GameState = GameManager.GameStates.Playable;
    }
}
