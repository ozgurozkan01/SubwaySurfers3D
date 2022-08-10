using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private PlayerStumble playerStumble;
    [SerializeField] private GameEndController gameEnd;
    private bool isGrounded;
    void Update()
    {
        RunningAnimation();
        JumpingAnimation();
        RollingAnimation();
        StumblingAnimation();
    }

    private void RunningAnimation()
    {
        if (isGrounded)
        {
            animator.SetBool("isRunning", true);
        }
    }

    public void JumpingAnimation()
    {
        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            animator.SetBool("isJumping", true);
            isGrounded = false;
        }

        else if(!Input.GetKey(KeyCode.W) && !isGrounded)
        {
            animator.SetBool("isJumping", false);
        }
    }

    private void RollingAnimation()
    {
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isRolling", true);
        }
        
        else if (!Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isRolling", false);
        }
    }

    private void StumblingAnimation()
    {
        if (playerStumble.isStumbling)
        {
            animator.SetBool("isStumbling", true);
            gameEnd._stumbleNumber += 1;
        }
        
        else if (!playerStumble.isStumbling)
        {
            animator.SetBool("isStumbling", false);
        }
    }

    public void FallingAnimation()
    {
         animator.SetBool("isFalling", true);
    }
    
    private void OnCollisionEnter()
    {
        isGrounded = true;
    }
}
