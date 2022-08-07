using System.Collections;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{

    [SerializeField] private GameObject[] passedPlatform;
    [HideInInspector] public GameObject[] newPassedPlatform;

    private void Awake()
    {
        newPassedPlatform = new GameObject[3];
    }

    public void UpdatePassedPlatform()
    {
        for (int i = 0; i < newPassedPlatform.Length; i++)
        {
            passedPlatform[i] = newPassedPlatform[i];
        }
    }

    public void DestroyPassedPlatform()
    {
        for (int i = 0; i < passedPlatform.Length; i++)
        {
            Destroy(passedPlatform[i]);
        }
    }

    public IEnumerator DestroyPlatformAfterDisapearing()
    {
        yield return new WaitForSeconds(0.3f);
        DestroyPassedPlatform();
    }
}
