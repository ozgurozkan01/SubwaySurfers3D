using UnityEngine;

public class CopAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    
    void Update()
    {
        CopRunningAnimation();
    }

    private void CopRunningAnimation()
    {
        animator.SetBool("isRunning", true);
    }
}
