using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    private enum States {
        Idle,
        Chase,
        Run
    }

    private States currentState = States.Idle;

    [SerializeField] private Animator animator;
    [SerializeField] private int groupNumber = 0;
    [SerializeField] private float distanceFrom = 20f;
    [SerializeField] private float speed = 4f;
    [SerializeField] private Transform armsHolder;
    [SerializeField] private Transform idleArms;
    [SerializeField] private Transform weaponHolder;
    [SerializeField] private Transform body;
    
    [SerializeField] private Transform posToGo;
    [SerializeField] private bool isFiringWhileMove = false;

    private ZombieShooting enemyShooting;
    private bool isFacingRight = true;
    private float distance = 0f;
    private float angle = 0f;
    private Vector2 direction;

    // Start is called before the first frame update
    private void Start()
    {
        armsHolder.gameObject.SetActive(false);
        enemyShooting = transform.GetComponent<ZombieShooting>();

        List<GameObject> triggers = GameManager.Instance.Triggers;
        foreach (GameObject el in triggers)
        {
            el.GetComponent<TriggerPlayer>().OnPlayerEnterTrigger += PlayerTrigger_OnPlayerEnterTrigger;
            // Debug.Log("Subscribed");
        }
    }

    private void OnDisable()
    {
        List<GameObject> triggers = GameManager.Instance.Triggers;
        foreach (GameObject el in triggers)
        {
            el.GetComponent<TriggerPlayer>().OnPlayerEnterTrigger -= PlayerTrigger_OnPlayerEnterTrigger;
            // Debug.Log("Subscribed");
        }
    }

    // private void OnDisable()
    // {
    //     List<GameObject> triggers = GameManager.Instance.Triggers;
    //     foreach (GameObject el in triggers)
    //     {
    //         el.GetComponent<TriggerPlayer>().OnPlayerEnterTrigger -= PlayerTrigger_OnPlayerEnterTrigger;
    //     }
    // }

    private void PlayerTrigger_OnPlayerEnterTrigger(int number)
    {
        if (gameObject == null)
            return;
        if (groupNumber == number && currentState == States.Idle)
        {
            if (posToGo == null)
            {
                // posToGo = GameManager.Instance.Player;
                StartBattle();
            }
            else
            {
                StartRun();
            }
        }
    }

    private void StartRun()
    {
        if (gameObject == null)
            return;
        if (isFiringWhileMove)
        {
            armsHolder.gameObject.SetActive(true);
            idleArms.gameObject.SetActive(false);
            body.transform.rotation = new Quaternion();
        }
        currentState = States.Run;
    }

    private void StartBattle()
    {
        if (gameObject == null)
            return;
        armsHolder.gameObject.SetActive(true);
        idleArms.gameObject.SetActive(false);
        body.transform.rotation = new Quaternion();
        currentState = States.Chase;
        // Debug.Log("Battle Started on: " + gameObject.name);
    }

    private void Update()
    {
        if (currentState == States.Chase)
        {
            distance = Vector2.Distance(transform.position, GameManager.Instance.Player.position);
            direction = (GameManager.Instance.Player.position - transform.position).normalized;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if ((direction.x) < 0f && isFacingRight)
                Flip();
            else if ((direction.x) > 0f && !isFacingRight)
                Flip();
        }
        else if (currentState == States.Run)
        {
            distance = Vector2.Distance(transform.position, posToGo.position);
            if (isFiringWhileMove)
                direction = (GameManager.Instance.Player.position - transform.position).normalized;
            else
                direction = (posToGo.position - transform.position).normalized;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if ((direction.x) < 0f && isFacingRight)
                Flip();
            else if ((direction.x) > 0f && !isFacingRight)
                Flip();
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (currentState == States.Chase)
        {
            armsHolder.eulerAngles = new Vector3(0, 0, angle);
            if (!isFiringWhileMove)
            {
                if (distance > distanceFrom)
                {
                    transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.Player.position, speed * Time.deltaTime);
                    animator.SetBool("isRun", true);
                }
                else
                {
                    animator.SetBool("isRun", false);
                    enemyShooting.Shoot();
                }
            }
            else
            {
                if (distance > distanceFrom)
                {
                    transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.Player.position, speed * Time.deltaTime);
                    animator.SetBool("isRun", true);
                }
                else
                {
                    animator.SetBool("isRun", false);
                }
                enemyShooting.Shoot();
            }
        }
        else if (currentState == States.Run)
        {
            armsHolder.eulerAngles = new Vector3(0, 0, angle);
            if (isFiringWhileMove)
            {
                if (distance > distanceFrom)
                {
                    transform.position = Vector2.MoveTowards(transform.position, posToGo.position, speed * Time.deltaTime);
                    animator.SetBool("isRun", true);
                }
                else
                {
                    animator.SetBool("isRun", false);
                }
                enemyShooting.Shoot();
            }
            else 
            {
                if (distance > distanceFrom)
                {
                    transform.position = Vector2.MoveTowards(transform.position, posToGo.position, speed * Time.deltaTime);
                    animator.SetBool("isRun", true);
                }
                else
                {
                    animator.SetBool("isRun", false);
                    isFiringWhileMove = true;
                    StartRun();
                }
            }
        }
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        body.transform.Rotate(0f, 180f, 0f);
        weaponHolder.Rotate(180f, 0f, 0f);
    }
}
