using UnityEngine;
using Random = UnityEngine.Random;

public class CreateNewObstacles : MonoBehaviour
{
    
    [SerializeField] private GameObject obstacleOverPassPrefab;
    [SerializeField] private GameObject obstacleUnderPassPrefab;
    [SerializeField] private GameObject obstacleNoPassPrefab;
    public GameObject[] lastObstacles;
    public int[] obstacleTypeList = new int[3]; // ( 0-> NoPass, 1-> UnderPass, 2-> OverPass)
    [SerializeField] private DestroyPlatform destroyPlatform;
    [SerializeField] private CoinClonerController coinClonerController;

    
    private GameObject[] _platformHolder;
    private int _obstacleIndex;
    private int _obstacleType;
    private int _passControl;
    


    void Awake()
    {
        _platformHolder = new GameObject[3];
    }

    public void DetermineTheObstacleType()
    {
        for (int i = 0; i < obstacleTypeList.Length; i++)
        {
            obstacleTypeList[i] = Random.Range(0, 3);
        }
        
        CheckPassExisted();
    }

    private void CheckPassExisted()
    {
        for (int i = 0; i < obstacleTypeList.Length; i++)
        {
            if (obstacleTypeList[i] == 1 || obstacleTypeList[i] == 2)
            {
                _passControl = 1;
            }
        }
        
        if (_passControl == 0)
        {
            _obstacleIndex = Random.Range(0, 3);
            _obstacleType = Random.Range(1, 3);
            obstacleTypeList[_obstacleIndex] = _obstacleType;
        }

        _passControl = 0;
        AttachTheObstacles();
    }
    
    private void AttachTheObstacles()
    {
        for (int i = 0; i < obstacleTypeList.Length; i++)
        {
            if (obstacleTypeList[i] == 0)
            {
                GameObject newObstacle = Instantiate(
                    obstacleNoPassPrefab, 
                    lastObstacles[i].transform.position + new Vector3(0f, 0f, 20f),
                    Quaternion.identity);
                
                _platformHolder[i] = lastObstacles[i];
                lastObstacles[i] = newObstacle;
                destroyPlatform.newPassedPlatform[i] = _platformHolder[i];
                
                coinClonerController.obstaclesPositionX[i] = 0;
                coinClonerController.obstaclesPositionZ[i] = 0;
            }
            
            else if (obstacleTypeList[i] == 1)
            {
                GameObject newObstacle = Instantiate(
                    obstacleUnderPassPrefab, 
                    lastObstacles[i].transform.position + new Vector3(0f, 0f, 20f), 
                    Quaternion.identity);
                
                _platformHolder[i] = lastObstacles[i];
                lastObstacles[i] = newObstacle;
                destroyPlatform.newPassedPlatform[i] = _platformHolder[i];
                
                coinClonerController.obstaclesPositionX[i] = lastObstacles[i].transform.position.x;
                coinClonerController.obstaclesPositionZ[i] = lastObstacles[i].transform.position.z;
            }
            
            else if (obstacleTypeList[i] == 2)
            {
                GameObject newObstacle = Instantiate(
                    obstacleOverPassPrefab, 
                    lastObstacles[i].transform.position + new Vector3(0f, 0f, 20f), 
                    Quaternion.identity);

                _platformHolder[i] = lastObstacles[i];
                lastObstacles[i] = newObstacle;
                destroyPlatform.newPassedPlatform[i] = _platformHolder[i];
                
                coinClonerController.obstaclesPositionX[i] = lastObstacles[i].transform.position.x;
                coinClonerController.obstaclesPositionZ[i] = lastObstacles[i].transform.position.z;
            }
        }
        coinClonerController.CloneCoin();
    }
}
