
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 500f;
    public float sidewaysForce = 500f;
    public float jumpForce = 1000f;
    public int maxJumps = 2;
    public int jumpCount;
    bool isforward = false;
    bool isbackward = false;
    bool isright = false;
    bool isleft = false;
    bool isJump = false;
    bool jumpHeld = false;
    public Vector3 respawn = Vector3.up*3;
    public bool isGrounded = true;
    public float lowJumpMultiplier = 4f;
    public float fallMultiplier = 6f;
    public float RespawnHeight = -100f;

    void Awake()
    {
        jumpCount = maxJumps;
    }


    void Update()
    {   
        
        if (Input.GetKeyDown("space"))
        {
            if (isGrounded || jumpCount != 0)
            {
                isJump = true;
                jumpCount -= 1;
            }
        }
        if (isJump) {
            isGrounded = false;
        }
        if (Input.GetKey("space"))
        {
            jumpHeld = true;
        }
        else if (Input.GetKeyUp("space")) {
            jumpHeld = false;
            isJump = false;
        }
        if (Input.GetKeyUp("space")) {
            jumpHeld = false;
        }
        if (Input.GetKey("w"))
        {
            isforward = true;
        }
        if (Input.GetKey("s"))
        {
            isbackward = true;
        }
        if (Input.GetKey("d"))
        {
            isright = true;
        }
        if (Input.GetKey("a"))
        {
            isleft = true;
        }
        if (Input.GetKeyUp("w"))
        {
            isforward = false;
        }
        if (Input.GetKeyUp("s"))
        {
            isbackward = false;
        }
        if (Input.GetKeyUp("d"))
        {
            isright = false;
        }
        if (Input.GetKeyUp("a"))
        {
            isleft = false;
        }

    }

    // We mark this as "FixedUpdate" because we are using it to mess with physics
    void FixedUpdate()
    {

        if (rb.position.y<= RespawnHeight) {
            rb.position = respawn;
        }
        if (isforward)
        {
            rb.AddForce(-1*forwardForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        }
        if (isbackward)
        {
            rb.AddForce(forwardForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        }
        if (isright)
        {
            rb.AddForce(0,0, sidewaysForce* Time.deltaTime, ForceMode.VelocityChange);

        }
        if (isleft)
        {
            rb.AddForce(0,0,-1*sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);

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
