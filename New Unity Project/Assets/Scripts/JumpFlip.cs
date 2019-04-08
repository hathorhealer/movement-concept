
using UnityEngine;

public class JumpFlip : MonoBehaviour
{
    public PlayerMovement player;
    public Animator anim;
    public bool doubleJump;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (doubleJump)
        {
            anim.SetBool("jumpFlip", true);
        }
        else {
            anim.SetBool("jumpFlip", false);
        }
    }
}
