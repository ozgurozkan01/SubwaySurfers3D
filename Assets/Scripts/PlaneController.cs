using UnityEngine;

public class PlaneController : MonoBehaviour
{
    private float _zPositionPlus = 25f;
    public void UpdatePlatformPosition()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + _zPositionPlus);
    }
}
