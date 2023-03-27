using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameOverScene : MonoBehaviour
{
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private SpriteRenderer title;
    private Color solidColor = new Color(1f, 1f, 1f, 1f);
    private Color titleColor = new Color(0.7843138f, 0.6156863f, 0.4784314f, 1f);
    // Start is called before the first frame update
    void Start()
    {
        background.DOColor(solidColor, 2f);
        title.DOColor(titleColor, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.PlayerEvents.RaiseChangeSceneEvent(GameManager.Instance.LastScene);
                Destroy(GameManager.Instance.gameObject);
            }
        }
    }
}
