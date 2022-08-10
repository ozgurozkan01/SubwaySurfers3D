using System.Collections;
using UnityEngine;

public class PlayerStumble : MonoBehaviour
{
    [HideInInspector] public bool isStumbling;
    [SerializeField] private GameEndController gameEnd;
    [SerializeField] private CopPositionController copPositionController;
    [SerializeField] private CopMovement copMovement;


    private int collisionNumber;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            collisionNumber++;
            isStumbling = true;
            copPositionController.CatchThePlayer();
            StartCoroutine(CollisionController());
        }
        StartCoroutine(StumblingControl());
        Debug.Log(collisionNumber);
    }

    IEnumerator StumblingControl()
    {
        yield return new WaitForSeconds(0.2f);
        isStumbling = false;
    }
    
    IEnumerator CollisionController()
    {
        yield return new WaitForSeconds(5f);
        copMovement.speed = 5f;
        yield return new WaitForSeconds(1.5f);
        copMovement.speed = 7f;
    }
}
