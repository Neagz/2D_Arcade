using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5F;
    public float force = 8F;
    public Rigidbody2D rigidBody;
    public float minimalHeight = -15F;
    public bool isCheatMode;
    public GroundDetection groundDetection;
    private Vector3 direction;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    private bool isJumping;

    struct Cat
    {
        public string name;
        public string hight;
        public string age;
        public string mass;
        public string long_tail;

        public void Myau()
        {
            Debug.Log("Мое имя - " + name + ", мой рост - " + hight + ", мой возвраст - " + age + ", моя масса - " + mass + ", а длинна моего хвоста - " + long_tail);
        }

    }

    private void Start()
        {
            Cat cat = new Cat();
            cat.name = "Лапа";
            cat.hight = "20 см";
            cat.age = "2,5 месяца";
            cat.mass = "10 кг";
            cat.long_tail = "18 см";
            cat.Myau();
        }
    void Update()
    {
        animator.SetBool("isGrounded", groundDetection.isGrounded);
        if (!isJumping && !groundDetection.isGrounded)
        {
            animator.SetTrigger("StartFall");
        }
        isJumping = isJumping && !groundDetection.isGrounded;
        direction = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
            direction = Vector3.left;
        if (Input.GetKey(KeyCode.D))
            direction = Vector3.right;
        direction *= speed;
        direction.y = rigidBody.velocity.y;
        rigidBody.velocity = direction;

        if (Input.GetKeyDown(KeyCode.W) && groundDetection.isGrounded)
        {
            rigidBody.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            animator.SetTrigger("StartJump");
            isJumping = true;
        }

        if (direction.x > 0)
            spriteRenderer.flipX = false;
        if (direction.x < 0)
            spriteRenderer.flipX = true;
        animator.SetFloat("Speed", Mathf.Abs(direction.x));

        CheckFall();

    }

    void CheckFall()
    {
        if (transform.position.y < minimalHeight && isCheatMode)
        {
            rigidBody.velocity = new Vector2(0, 0);
            transform.position = new Vector2(0, 0);
        }
        else if (transform.position.y < minimalHeight && !isCheatMode)
            Destroy(gameObject);
    }
}
