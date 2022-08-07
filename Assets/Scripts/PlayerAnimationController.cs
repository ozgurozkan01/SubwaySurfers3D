using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private PlayerStumble playerStumble;
    private bool isGrounded;
    void Update()
    {
        RunningAnimation();
        JumpingAnimation();
        RollingAnimation();
        StumbleTheObstacles();  
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

    private void StumbleTheObstacles()
    {
        if (playerStumble.isStumbling)
        {
            animator.SetBool("isStumbling", true);
        }
        
        else if (!playerStumble.isStumbling)
        {
            animator.SetBool("isStumbling", false);
        }
    }
    
    
    private void OnCollisionEnter()
    {
        isGrounded = true;
    }
}
