using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ActionDialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private string[] lines;
    [SerializeField] private float textSpeed;
    private int index;

    private int state = 0;

    [SerializeField] private bool canBeDisabled = false;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && state == 0)
        {
            
            if (textComponent.text == lines[index])
            {
                GameManager.Instance.Player.GetComponent<Player>().GrabWeapon();
                NextLine();
                state++;
            }
        }
        if (Input.GetButtonDown("Fire1") && state == 1)
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
                state++;
            }
        }
        if (Input.GetButtonDown("TimeSnap") && state == 2)
        {
            if (textComponent.text == lines[index])
            {
                GameManager.Instance.Player.GetComponent<Player>().UseTimeSnap();
                NextLine();
                state++;
            }
        }
        // if (Input.GetButtonDown("Fire1"))
        // {
        //     if (textComponent.text == lines[index])
        //     {
        //         NextLine();
        //     }
        //     else
        //     {
        //         StopAllCoroutines();
        //         textComponent.text = lines[index];
        //     }
        // }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        //yield return new WaitForSeconds(lineSpeed);
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else if (canBeDisabled)
        {
            gameObject.SetActive(false);
        }
    }
}
