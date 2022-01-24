using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject leftBorder;
    public GameObject rightBorder;
    public Rigidbody2D rigidBody;
    public GroundDetection groundDetection;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public bool isRightDirection;
    public float speed;

    private void Update()
    {
        if (isRightDirection && groundDetection.isGrounded)
        {
            rigidBody.velocity = Vector2.right * speed;
            if (transform.position.x > rightBorder.transform.position.x)
                isRightDirection = !isRightDirection;
        }
        else if (groundDetection.isGrounded)
        {
            rigidBody.velocity = Vector2.left * speed;
            if (transform.position.x < leftBorder.transform.position.x)
                isRightDirection = !isRightDirection;
        }

        if (rigidBody.velocity.x > 0)
            spriteRenderer.flipX = true;
        if (rigidBody.velocity.x < 0)
            spriteRenderer.flipX = false;
        animator.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));
    }
}
