using UnityEngine;
public class RagdollActivate : MonoBehaviour
{
    private Rigidbody playerRb;
    private Collider playerCollider;
    [SerializeField] private Animator animator;

    private Rigidbody[] _rigidbodies;
    private Collider[] _colliders;
    // Start is called before the first frame update
    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<Collider>();

        _rigidbodies = GetComponentsInChildren<Rigidbody>();
        _colliders = GetComponentsInChildren<Collider>();
        
        SetCollidersInChildren(false);
        SetRigidBodiesInChildren(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ActivateRagdoll();
        }
    }

    private void SetRigidBodiesInChildren(bool isKinematic)
    {
        foreach (Rigidbody rb in _rigidbodies)
        {
            rb.isKinematic = isKinematic;
        }
    }

    private void SetCollidersInChildren(bool enabled)
    {
        foreach (Collider col in _colliders)
        {
            col.enabled = enabled;
        }
    }

    private void ActivateRagdoll()
    {
        playerCollider.enabled = false;
        playerRb.isKinematic = true;
        animator.enabled = false;
        
        SetCollidersInChildren(true);
        SetRigidBodiesInChildren(false);
    }
}
