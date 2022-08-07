using UnityEngine;

public class CopRotation : MonoBehaviour
{
    [SerializeField] private float lerpMultiplier;
    [HideInInspector] public float rotationAngle;

    private void Update()
    {
        CopRotationWhileTurning();
    }

    public void CopRotationWhileTurning()
    {
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.Euler(0f, rotationAngle, 0f),
            Time.deltaTime * lerpMultiplier);
    }
}
