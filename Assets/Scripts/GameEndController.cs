using UnityEngine;

public class GameEndController : MonoBehaviour
{
    [HideInInspector] public int _stumbleNumber;
    [SerializeField] private CopMovement copMovement;
    [SerializeField] private PlayerMovement playerMovement; 
    [SerializeField] private PlayerAnimationController playerAnimation;
    void Update()
    {
        GameEnd();
    }

    void GameEnd()
    {
        if (_stumbleNumber == 2)
        {
            Debug.Log("Game ENDED");
            copMovement.speed = 0f;
            playerMovement.speed = 0f;
            playerAnimation.FallingAnimation();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("NoPass"))
        {
            playerMovement.speed = 0f;
            copMovement.speed = 0f;
            playerAnimation.FallingAnimation();
        }
    }
}
