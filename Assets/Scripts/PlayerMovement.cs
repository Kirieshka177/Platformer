using System.IO;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string RunAnimationName = "IsRunned";

    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] private Animator _animator;

    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    private float moveX; 
    private bool shouldJump; 
    private bool isGrounded;
    private bool _currentMovementState;
    private bool isRunned = false;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        _currentMovementState = false;
    }

    private void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        if (moveX != 0)
           isRunned = true;
        if (moveX == 0)
            isRunned = false;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            shouldJump = true;
        }

        if(isRunned != _currentMovementState)
        {
            _currentMovementState = isRunned;
            _animator.SetBool(RunAnimationName, isRunned);
        }
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(moveX * speed, rigidBody.velocity.y);

        

        if (rigidBody.velocity.x > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (rigidBody.velocity.x < -0.1f)
        {
            spriteRenderer.flipX = true;
        }

        if (shouldJump)
        {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            shouldJump = false; 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float yPos = collision.transform.position.y;
        float playeryPos = transform.position.y;

        if (collision.gameObject.CompareTag("Ground") && yPos < playeryPos)
        {
           isGrounded = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            ScoreManager.instance.Metod(1);
        }
    }

}




