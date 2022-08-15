using UnityEngine;

public class GameEndController : MonoBehaviour
{
    [SerializeField] private PlayerStumble playerStumble;
    [SerializeField] private CopMovement copMovement;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerAnimationController playerAnimCont;
    [SerializeField] private CopAnimationController copAnimCont;

    private bool _isColliderWithTrain;
    private bool _isCollideWithNoPass;
    [HideInInspector] public bool gameEndControl;
    
    void Update()
    {
        CheckGameEnded();
        GameEnded();
    }

    private void CheckGameEnded()
    {
        if (playerStumble.collisionNumber >= 2)
        {
            gameEndControl = true;
        }
        
        else if (_isCollideWithNoPass || _isColliderWithTrain)
        {
            gameEndControl = true;
        }
    }
    
    void GameEnded()
    {
        if (gameEndControl)
        {
            playerAnimCont.FallingAnimation();
            playerMovement.speed = 0f;
            copMovement.speed = 0f;
            copMovement.gameObject.transform.position =
                playerMovement.gameObject.transform.position + new Vector3(0f, 0f, -1f);
            copAnimCont.CopGuardingAnimation();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("NoPass"))
        {
            _isCollideWithNoPass = true;
        }

        else if (collision.gameObject.CompareTag("Train"))
        {
            collision.gameObject.GetComponent<Collider>().enabled = false;
            _isColliderWithTrain = true;
        }
    }
}
