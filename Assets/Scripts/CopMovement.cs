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
        CopFollowPlayerLinearly();    
    }
    
    private void CopFollowPlayerLinearly()
    {
        _rigidbody.velocity = new Vector3(0f, _rigidbody.velocity.x, speed);
    }
}
