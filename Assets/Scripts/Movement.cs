using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed;
    [SerializeField] private Animator animator;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform arms;
    [SerializeField] private Transform weaponHolder;
    [SerializeField] private Transform body;
    [SerializeField] private Camera cam;
    private bool isFacingRight = true;

    private Vector2 movement;
    private Vector3 mousePos;
    
    // Update is called once per frame
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if ((mousePos.x - rb.position.x) < 0f && isFacingRight)
            Flip();
        else if ((mousePos.x - rb.position.x) > 0f && !isFacingRight)
            Flip();
        // Implement flipping from aiming
        // if (movement.x < 0f && isFacingRight)
        //     Flip();
        // else if (movement.x > 0f && !isFacingRight)
        //     Flip();
    }

    private void FixedUpdate()
    {
        Move();

        Aim();
    }

    private void Move()
    {
        if (movement.magnitude > 0)
        {
            animator.SetBool("isRun", true);
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        else
            animator.SetBool("isRun", false);
    }

    private void Aim()
    {
        Vector3 lookDir = (mousePos - arms.position).normalized;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        arms.eulerAngles = new Vector3(0, 0, angle);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        body.transform.Rotate(0f, 180f, 0f);
        weaponHolder.Rotate(180f, 0f, 0f);
    }
}
