using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private PlayerMovement playerMovement;
    private bool isGrounded;
    void Update()
    {
        AnimationControl();       
    }

    private void AnimationControl()
    {
        RunningAnimation();
        JumpingAnimation();
        RollingAnimation();
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

    public void RightTurnOn()
    {
        animator.SetBool("TurnRight", true);
    }

    public void RightTurnOf()
    {
        animator.SetBool("TurnRight", false);
    }
    
    private void LeftTurn()
    {
        
    }
    
    private void OnCollisionEnter()
    {
        isGrounded = true;
    }
}
