using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TimeSnapEffector : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Color slowColor;
    private Color normalColor;
    private bool isNormalTime = true;
    // Start is called before the first frame update
    private void Start()
    {
        sprite = transform.GetComponent<SpriteRenderer>();
        slowColor = sprite.color;
        normalColor = new Color(0.2f, 0.2f, 1f, 0f);
        sprite.color = normalColor;
        GameManager.Instance.PlayerEvents.TimeSnapEvent += TimeSnap;
    }

    private void OnDisable()
    {
        GameManager.Instance.PlayerEvents.TimeSnapEvent -= TimeSnap;
    }

    public void TimeSnap()
    {
        if (isNormalTime)
            sprite.DOColor(slowColor, 0.5f);
        else
            sprite.DOColor(normalColor, 0.5f);
        isNormalTime = !isNormalTime;
    }
}
