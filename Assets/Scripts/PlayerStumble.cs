using System.Collections;
using UnityEngine;

public class PlayerStumble : MonoBehaviour
{
    [HideInInspector] public bool isStumbling;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isStumbling = true;
        }

        StartCoroutine(StumblingControl());
    }

    IEnumerator StumblingControl()
    {
        yield return new WaitForSeconds(0.2f);
        isStumbling = false;
    }
}
