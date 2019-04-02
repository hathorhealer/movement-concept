
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Camera cameraObject;
    public JumpFlip jumper;
    public float forwardForce = 500f;
    public float sidewaysForce = 500f;
    public float jumpForce = 1000f;
    public int maxJumps = 2;
    public int jumpCount;
    bool isForward = false;
    bool isBackward = false;
    bool isRight = false;
    bool isLeft = false;
    public bool isJump = false;
    bool jumpHeld = false;
    public Vector3 respawn = Vector3.up*3;
    public bool isGrounded = true;
    public float lowJumpMultiplier = 4f;
    public float fallMultiplier = 6f;
    public float RespawnHeight = -100f;
    [Range(0.1f, 1f)]
    public float smoothMove = 0.3f;
    public Vector3 moveDirection = Vector3.zero;
    float moveHorizontal;
    float moveVertical;
    float moveVertiRaw;
    float moveHoriRaw;
    Vector3 lastSafe = Vector3.zero;
    void Awake()
    {
        jumpCount = maxJumps;
    }


    void Update()
    {
        jumper.doubleJump = false;
        isJump = false;
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        moveHoriRaw = Input.GetAxisRaw("Horizontal");
        moveVertiRaw = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown("space"))
        {
            if (isGrounded || jumpCount > 0)
            {
                isJump = true;
                jumpCount -= 1;
                if (!isGrounded) {
                    jumper.doubleJump = true;
                }
            }
        }
        if (isJump) {
            isGrounded = false;
        }
        if (Input.GetKey("space"))
        {
            jumpHeld = true;
        }
        if (Input.GetKeyUp("space")) {
            jumpHeld = false;
        }
    }

    // We mark this as "FixedUpdate" because we are using it to mess with physics
    void FixedUpdate()
    {
        Vector3 lastMoveDirection = moveDirection;
        moveDirection = Camera.main.transform.forward * moveVertical;
        moveDirection += Camera.main.transform.right * moveHorizontal;
        moveDirection.y = 0;
        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(Quaternion.LookRotation(moveDirection, Vector3.up), transform.rotation, smoothMove);
        }
        else if (lastMoveDirection != Vector3.zero) {
            moveDirection = lastMoveDirection;
            transform.rotation = Quaternion.Slerp(Quaternion.LookRotation(moveDirection, Vector3.up), transform.rotation, smoothMove);
        }
        rb.AddForce(transform.forward * forwardForce * Time.deltaTime * moveVertiRaw * moveVertical, ForceMode.VelocityChange);
        rb.AddForce(transform.forward * sidewaysForce * Time.deltaTime * moveHoriRaw * moveHorizontal, ForceMode.VelocityChange);

        if (rb.position.y<= RespawnHeight) {
            rb.position = respawn;
        }
        if (isJump)
        {
            rb.velocity += Vector3.up * -1 * rb.velocity.y;
            rb.AddForce(0, jumpForce*Time.deltaTime, 0, ForceMode.VelocityChange);
            isJump = false;
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !jumpHeld) {

            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
