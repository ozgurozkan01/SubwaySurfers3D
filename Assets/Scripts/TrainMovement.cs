using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        TrainMove();
    }

    private void TrainMove()
    {
        rb.velocity = new Vector3(0f, 0f, -speed * Time.deltaTime);
    }
}
