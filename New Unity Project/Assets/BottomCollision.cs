using UnityEngine;

public class BottomCollision : MonoBehaviour
{
    public bool collided = false;
    public PlayerMovement movement;
    public Rigidbody rb;
    // Update is called once per frame

    void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Ground") {
            movement.jumpCount = movement.maxJumps;
            movement.isGrounded = true;
        }
    }
    
    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Ground")
        {
            movement.isGrounded = false;
            collided = false;
        }
    }
    
}
    
