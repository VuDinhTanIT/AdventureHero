using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}

// https://stackoverflow.com/questions/63636944/unity-type-or-namespace-name-inputsystem-does-not-exist-in-the-namespace-unit
// using UnityEngine;
// // using UnityEngine.InputSystem;
// using UnityEngine.InputSystem;
// public class PlayerMovement : MonoBehaviour
// {
//     private Rigidbody2D rb;
//     private BoxCollider2D coll;
//     private SpriteRenderer sprite;
//     private Animator anim;

//     [SerializeField] private LayerMask jumpableGround;

//     private float moveSpeed = 7f;
//     private float jumpForce = 14f;

//     private enum MovementState { idle, running, jumping, falling }

//     [SerializeField] private AudioSource jumpSoundEffect;

//     private void Awake()
//     {
//         rb = GetComponent<Rigidbody2D>();
//         coll = GetComponent<BoxCollider2D>();
//         sprite = GetComponent<SpriteRenderer>();
//         anim = GetComponent<Animator>();
//     }

//     private void Update()
//     {
//         // Read horizontal movement from gamepad (if available)
//         var gamepad = Gamepad.current;
//         if (gamepad != null)
//         {
//             var moveX = gamepad.leftStick.ReadValue().x;
//             rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
//         }
//         // Otherwise, use keyboard controls
//         else
//         {
//             float moveX = Keyboard.current.dKey.isPressed ? 1f : (Keyboard.current.aKey.isPressed ? -1f : 0f);
//             rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
//         }

//         // Check for jump using keyboard space key
//         if (Keyboard.current.spaceKey.wasPressedThisFrame && IsGrounded())
//         {
//             jumpSoundEffect.Play();
//             rb.velocity = new Vector2(rb.velocity.x, jumpForce);
//         }

//         UpdateAnimationState();
//     }

//     private void UpdateAnimationState()
//     {
//         MovementState state;

//         float absVelX = Mathf.Abs(rb.velocity.x);
//         if (absVelX > 0.1f)
//         {
//             state = MovementState.running;
//             sprite.flipX = rb.velocity.x < 0f;
//         }
//         else
//         {
//             state = MovementState.idle;
//         }

//         if (rb.velocity.y > 0.1f)
//         {
//             state = MovementState.jumping;
//         }
//         else if (rb.velocity.y < -0.1f)
//         {
//             state = MovementState.falling;
//         }

//         anim.SetInteger("state", (int)state);
//     }

//     private bool IsGrounded()
//     {
//         return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
//     }
// }
