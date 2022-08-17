using UnityEngine;

public class CopAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private CopMovement copMovement;
    
    void LateUpdate()
    {
        CopRunningAnimation();
        CopRollingAnimaiton();
        CopJumpingAnimation();
    }
    
    private void CopRunningAnimation()
    {
        animator.SetBool("isRunning", true);
    }

    private void CopJumpingAnimation()
    {
        if (copMovement.jumpingController)
        {
            animator.SetBool("isJumping", true);
            copMovement.Jump();
            copMovement.jumpingController = false;
        }
        
        else if (!copMovement.jumpingController)
        {
            animator.SetBool("isJumping", false);
        }
    }

    private void CopRollingAnimaiton()
    {
        if (copMovement.rollingController)
        {
            animator.SetBool("isRolling", true);
            copMovement.rollingController = false;
        }
        
        else if (!copMovement.rollingController)
        {
            animator.SetBool("isRolling", false);
        }
    }

    public void CopGuardingAnimation()
    {
        animator.SetBool("isStopping", true);
    }
}
