using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerPlayer : MonoBehaviour
{
    public event UnityAction<int> OnPlayerEnterTrigger;
    [SerializeField] private int groupNumber = 0;
    [SerializeField] private bool bulletsInvokeAgro = true;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Equals("Player"))
        {
            OnPlayerEnterTrigger?.Invoke(groupNumber);
            Debug.Log("Trigger on: " + groupNumber);
            //gameObject.SetActive(false);
        }
        else if (bulletsInvokeAgro && collider.tag.Equals("Bullet"))
        {
            OnPlayerEnterTrigger?.Invoke(groupNumber);
            Debug.Log("Trigger on: " + groupNumber);
        }
    }
}
