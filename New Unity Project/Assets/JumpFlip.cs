
using UnityEngine;

public class JumpFlip : MonoBehaviour
{
    public PlayerMovement player;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Debug.Log("animator is at least loading");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) {
            Debug.Log("should be flipping right now");
            anim.Play("Cube Flip");
        }
    }
}
