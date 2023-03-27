using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerPlayer : MonoBehaviour
{
    public event UnityAction<int> OnPlayerEnterTrigger;
    [SerializeField] private int groupNumber = 0;
    [SerializeField] private bool bulletsInvokeAgro = true;
    // private bool invokedAlready = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (bulletsInvokeAgro && (collider.tag.Equals("Player") || collider.tag.Equals("Bullet")))
        {
            OnPlayerEnterTrigger?.Invoke(groupNumber);
        }
        else if (collider.tag.Equals("Player"))
        {
            OnPlayerEnterTrigger?.Invoke(groupNumber);
        }
    }
}
