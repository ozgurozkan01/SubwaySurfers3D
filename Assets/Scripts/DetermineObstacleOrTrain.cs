using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class DetermineObstacleOrTrain : MonoBehaviour
{
    [SerializeField] private CreateNewObstacles createObstacle;
    [SerializeField] private CreateNewTraines createTrain;
    private int typeObject;
    
    [SerializeField] private DestroyPlatform destroyPlatform;
    [SerializeField] private CheckPlayerPassedTrain checkPassed;
    
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
        typeObject = Random.Range(0, 2);// 0-> train, 1-> obstacle
    }

    public void InstantiateObject()
    {
        DetermineTypeOfObject();
        // Obstacle
        if (typeObject == 1)
        {
            createObstacle.DetermineTheObstacleType();
        }
        
        // Train
        else if (typeObject == 0)
        {
            createTrain.CreateNewTrain();
        }
    }
}
