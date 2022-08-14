using UnityEngine;
using Random = UnityEngine.Random;

public class DetermineObstacleOrTrain : MonoBehaviour
{
    [SerializeField] private CreateNewObstacles createObstacle;
    [SerializeField] private CreateNewTraines createTrain;
    
    [HideInInspector] public GameObject[] objectHolder;
    public GameObject[] lastObjects;
    private int _typeObject;
    private int lineAmount = 3;
    [HideInInspector] public int noPassLineAmount;
    [HideInInspector] public Vector3[] firstObsPositionsHolder;
    
    [SerializeField] private DestroyPlatform destroyPlatform;
    [SerializeField] private CheckPlayerPassedTrain checkPassed;

    [HideInInspector] public float obsPositionZ = 20f;
    [HideInInspector] public float trainPositionZ = 30f;
    
    void Awake()
    {
        firstObsPositionsHolder = new Vector3[3];
        
        for (int i = 0; i < lineAmount; i++)
        {
            firstObsPositionsHolder[i] = lastObjects[i].transform.position;
        }
        
        objectHolder = new GameObject[3];
    }

    private void Update()
    {
        PlayerPassedTrain();
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Gate"))
        {
            InstantiateObject();
            destroyPlatform.timeController = true;
        }
    }

    private void PlayerPassedTrain()
    {
        if (checkPassed.isPassed)
        {
            InstantiateObject();
            checkPassed.isPassed = false;
        }
    }
    
    private void DetermineTypeOfObject()
    {
        _typeObject = Random.Range(0, 2); // 0-> train, 1-> obstacle

        if (_typeObject == 0)
        {
            noPassLineAmount += 1;

            if (noPassLineAmount >= 3)
            {
                _typeObject = 1;
            }
        }
    }

    public void InstantiateObject()
    {

        for (int i = 0; i < lineAmount; i++)
        {
            DetermineTypeOfObject();
        
            // Train
            if (_typeObject == 0 && noPassLineAmount != 3)
            {
                createTrain.CreateNewTrain(i);
            }
        
            // Obstacle
            else if (_typeObject == 1)
            {
                createTrain.trainAmount = 0;
                createObstacle.CreateTheObstacles(i);
            }   
        }
        noPassLineAmount = 0;
        obsPositionZ += 20f;
        trainPositionZ += 20f;
    }
    
}
