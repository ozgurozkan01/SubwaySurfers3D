using UnityEngine;

public class CopMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float speed;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();    
    }
    
    private void Move()
    {
        _rigidbody.velocity = new Vector3(0f, _rigidbody.velocity.x, speed);
    }
}
