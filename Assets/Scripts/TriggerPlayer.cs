using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerPlayer : MonoBehaviour
{
   public event UnityAction<int> OnPlayerEnterTrigger;
   [SerializeField] private int groupNumber = 0;

   private void OnTriggerEnter2D(Collider2D collider)
   {
        if (collider.tag.Equals("Player"))
        {
            OnPlayerEnterTrigger?.Invoke(groupNumber);
        }
   }
}
