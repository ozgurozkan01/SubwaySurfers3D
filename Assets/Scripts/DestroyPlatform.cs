
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{

    [SerializeField] private GameObject[] passedPlatform;
    [HideInInspector] public GameObject[] newPassedPlatform;
    
    [HideInInspector] public bool timeController;
    private float _timeLimit = 1f;
    private float _timeCounter;

    private void Update()
    {
        TimerForDestroying();
    }

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

    private void TimerForDestroying()
    {
        if (timeController)
        {
            if (_timeCounter >= _timeLimit)
            {
                UpdatePassedPlatform();
                DestroyPassedPlatform();
                _timeCounter = 0f;
                timeController = false;
            }
            _timeCounter += Time.deltaTime;
        }
    }
}
