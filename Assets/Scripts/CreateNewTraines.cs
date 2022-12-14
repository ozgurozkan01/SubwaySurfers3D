using UnityEngine;

public class CreateNewTraines : MonoBehaviour
{
    [SerializeField] private GameObject trainPrefabCanMove;
    [SerializeField] private GameObject trainPrefabNoMove;
    [SerializeField] private DetermineObstacleOrTrain determineObject;
    [SerializeField] private DestroyObstacle destroyPlatform;

    [HideInInspector] public int trainAmount;
    private int trainType; // 1-> canMove, 2-> noMove 

    private void DetermineTrainType()
    {
        trainType = Random.Range(1, 3);
    }
    
    public void CreateNewTrain(int lastObjectIndex)
    {
        DetermineTrainType();

        if (trainType == 1)
        {
            GameObject newTrain = Instantiate(trainPrefabCanMove, 
                determineObject.firstObsPositionsHolder[lastObjectIndex] + new Vector3(0f, 0f, determineObject.trainPositionZ) 
                , transform.rotation);
            
            determineObject.objectHolder[lastObjectIndex] = determineObject.lastObjects[lastObjectIndex];
            determineObject.lastObjects[lastObjectIndex] = newTrain;
            destroyPlatform.newPassedPlatform[lastObjectIndex] = determineObject.objectHolder[lastObjectIndex];
        }
        
        else if (trainType == 2)
        {
            GameObject newTrain = Instantiate(trainPrefabNoMove, 
                determineObject.firstObsPositionsHolder[lastObjectIndex] + new Vector3(0f, 0f, determineObject.trainPositionZ) 
                , transform.rotation);
            
            determineObject.objectHolder[lastObjectIndex] = determineObject.lastObjects[lastObjectIndex];
            determineObject.lastObjects[lastObjectIndex] = newTrain;
            determineObject.staticLine[determineObject.staticLineIndex] = determineObject.lastObjects[lastObjectIndex];
            destroyPlatform.newPassedPlatform[lastObjectIndex] = determineObject.objectHolder[lastObjectIndex];

            determineObject.staticLineIndex += 1;
            determineObject.staticLineAmount += 1;
        }

    }
}
