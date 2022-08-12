using UnityEngine;

public class PlayerStumble : MonoBehaviour
{
    public bool isStumbling;
    [SerializeField] private CopPositionController copPositionController;
    public int collisionNumber;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            collisionNumber++;
            Debug.Log(collisionNumber);
            collision.gameObject.GetComponent<Collider>().enabled = false;
            isStumbling = true;
            copPositionController.CatchThePlayer();
        }
    }
}
