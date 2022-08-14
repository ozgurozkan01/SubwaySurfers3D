using UnityEngine;

public class CheckPlayerPassedTrain : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    private RaycastHit hit;
    public bool isPassed;
    // Update is called once per frame
    void Update()
    {
        CheckPassTrain();
    }

    private void CheckPassTrain()
    {
        if (Physics.Raycast(transform.position, transform.right, out hit, playerLayer))
        {
            Debug.Log("Passed");
            isPassed = true;
        }
    }
}
