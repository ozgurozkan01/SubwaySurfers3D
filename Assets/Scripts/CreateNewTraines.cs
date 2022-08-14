using UnityEngine;

public class CreateNewTraines : MonoBehaviour
{
    [SerializeField] private GameObject originalTrainPrefab;
    [SerializeField] private DetermineObstacleOrTrain determineObject;
    [SerializeField] private DestroyPlatform destroyPlatform;

    [HideInInspector] public int trainAmount; 
     
    public void CreateNewTrain(int lastObjectIndex)
    {
        GameObject newTrain = Instantiate(originalTrainPrefab, 
                determineObject.firstObsPositionsHolder[lastObjectIndex] + new Vector3(0f, 0f, determineObject.trainPositionZ) 
                , transform.rotation);

        determineObject.objectHolder[lastObjectIndex] = determineObject.lastObjects[lastObjectIndex];
        determineObject.lastObjects[lastObjectIndex] = newTrain;
        destroyPlatform.newPassedPlatform[lastObjectIndex] = determineObject.objectHolder[lastObjectIndex];
    }
}
