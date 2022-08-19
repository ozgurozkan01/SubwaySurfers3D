using UnityEngine;
using Random = UnityEngine.Random;

public class CreateNewObstacles : MonoBehaviour
{
    [SerializeField] private GameObject obstacleOverPassPrefab;
    [SerializeField] private GameObject obstacleUnderPassPrefab;
    [SerializeField] private GameObject obstacleNoPassPrefab;
    public int obstacleType; // ( 0-> NoPass, 1-> UnderPass, 2-> OverPass)
    [SerializeField] private DestroyPlatform destroyPlatform;
    [SerializeField] private CoinClonerController coinClonerController;
    [SerializeField] private DetermineObstacleOrTrain determineObject;
    
    private int _obstacleIndex;
    private int _obstacleType;
    private int _passControl;
    
    private void DetermineTheObstacleType()
    { 
        obstacleType = Random.Range(0, 3);

        if (obstacleType == 0)
        {
            determineObject.noPassLineAmount += 1;

            if (determineObject.noPassLineAmount >= 3)
            {
                obstacleType = Random.Range(1, 3);
            }
        }
    }

    public void CreateTheObstacles(int lastObjectIndex)
    {
        DetermineTheObstacleType();
        if (obstacleType == 0 && determineObject.noPassLineAmount != 3)
            {
                GameObject newObstacle = Instantiate(
                    obstacleNoPassPrefab, 
                    determineObject.firstObsPositionsHolder[lastObjectIndex] + new Vector3(0f, 0f, determineObject.obsPositionZ),
                    Quaternion.identity);
                
                determineObject.objectHolder[lastObjectIndex] = determineObject.lastObjects[lastObjectIndex];
                determineObject.lastObjects[lastObjectIndex] = newObstacle;
                determineObject.staticLine[determineObject.staticLineIndex] = determineObject.lastObjects[lastObjectIndex];
                destroyPlatform.newPassedPlatform[lastObjectIndex] = determineObject.objectHolder[lastObjectIndex];

                determineObject.staticLineIndex += 1;
            }
            
            else if (obstacleType == 1)
            {
                GameObject newObstacle = Instantiate(
                    obstacleUnderPassPrefab, 
                    determineObject.firstObsPositionsHolder[lastObjectIndex] + new Vector3(0f, 0f, determineObject.obsPositionZ), 
                    Quaternion.identity);
                
                determineObject.objectHolder[lastObjectIndex] = determineObject.lastObjects[lastObjectIndex];
                determineObject.lastObjects[lastObjectIndex] = newObstacle;
                determineObject.staticLine[determineObject.staticLineIndex] = determineObject.lastObjects[lastObjectIndex];
                destroyPlatform.newPassedPlatform[lastObjectIndex] = determineObject.objectHolder[lastObjectIndex];
                determineObject.staticLineIndex += 1;
                
                coinClonerController.obstaclesPositionX = determineObject.lastObjects[lastObjectIndex].transform.position.x;
                coinClonerController.obstaclesPositionZ = determineObject.lastObjects[lastObjectIndex].transform.position.z;
                coinClonerController.CloneCoin(coinClonerController.obstaclesPositionX, coinClonerController.obstaclesPositionZ);
            }
            
            else if (obstacleType == 2)
            {
                GameObject newObstacle = Instantiate(
                    obstacleOverPassPrefab, 
                    determineObject.firstObsPositionsHolder[lastObjectIndex] + new Vector3(0f, 0f, determineObject.obsPositionZ), 
                    Quaternion.identity);

                determineObject.objectHolder[lastObjectIndex] = determineObject.lastObjects[lastObjectIndex];
                determineObject.lastObjects[lastObjectIndex] = newObstacle;
                determineObject.staticLine[determineObject.staticLineIndex] = determineObject.lastObjects[lastObjectIndex];
                destroyPlatform.newPassedPlatform[lastObjectIndex] = determineObject.objectHolder[lastObjectIndex];
                determineObject.staticLineIndex += 1;
                
                coinClonerController.obstaclesPositionX= determineObject.lastObjects[lastObjectIndex].transform.position.x;
                coinClonerController.obstaclesPositionZ= determineObject.lastObjects[lastObjectIndex].transform.position.z;
                coinClonerController.CloneCoin(coinClonerController.obstaclesPositionX, coinClonerController.obstaclesPositionZ);
            }

    }
}
