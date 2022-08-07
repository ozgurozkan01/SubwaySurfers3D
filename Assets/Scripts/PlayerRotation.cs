using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private float lerpMultiplier;
    [HideInInspector] public float rotationAngle;

    private void Update()
    {
        PlayerRotationWhileTurning();
    }

    public void PlayerRotationWhileTurning()
    {

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.Euler(0f, rotationAngle ,0f), 
            Time.deltaTime * lerpMultiplier);
    }
}
