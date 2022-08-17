using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] [Range(0, 5)] private float lerpValue;
    private Vector3 _offset;

    void Start()
    {
        _offset = transform.position - player.transform.position;
    }
    
    void FixedUpdate()
    {
        CameraFollow();
    }

    private void CameraFollow()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + _offset,
            Time.deltaTime * lerpValue);
    }
}
