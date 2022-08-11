using System.Collections;
using UnityEngine;

public class PlayerStumble : MonoBehaviour
{
    public bool isStumbling;
    [SerializeField] private CopPositionController copPositionController;
    [SerializeField] private CopMovement copMovement;
    [SerializeField] private GameEndController gameEnd;
    
    public int collisionNumber;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            collisionNumber++;
            collision.gameObject.GetComponent<Collider>().enabled = false;
            isStumbling = true;
            copPositionController.CatchThePlayer();
        }

        if (!gameEnd.gameEndControl)
        {
            StartCoroutine(FallDownController());
        }
    }
    
    IEnumerator FallDownController()
    {
        yield return new WaitForSeconds(10);
        copMovement.speed = 5f;
        yield return new WaitForSeconds(2f);
        copMovement.speed = 8f;
        collisionNumber = 0;
    }
}
