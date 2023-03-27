using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelTrigger : MonoBehaviour
{
    public UnityAction<int> OnChangeLevel;

    [SerializeField] private int sceneNumber = 0;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Equals("Player"))
        {
            GameManager.Instance.PlayerEvents.RaiseChangeSceneEvent(sceneNumber);
            // OnChangeLevel?.Invoke(sceneNumber);
            // Debug.Log("Trigger on: " + groupNumber);
        }
    }
}
