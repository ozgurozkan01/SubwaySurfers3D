using UnityEngine;

public class CoinClonerController : MonoBehaviour
{
    [SerializeField] private GameObject originalCoinPrefab;
    [SerializeField] private CreateNewObstacles createNewObstacles;

    [HideInInspector] public float[] obstaclesPositionX;
    [HideInInspector] public float[] obstaclesPositionZ;
    private int _lineNumber;
    private float _zPosition;
    private float _xPosition;

    void Awake()
    {
        obstaclesPositionX = new float[3];
        obstaclesPositionZ = new float[3];
    }

    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            Debug.Log(obstaclesPositionX[i]);
        }
        
        for (int i = 0; i < 3; i++)
        {
            Debug.Log(obstaclesPositionZ[i]);
        }
    }
    
    public void CloneCoin()
    {
        for (int i = 0; i < 3; i++)
        {
            if (obstaclesPositionX[i] != 0 || obstaclesPositionZ[i] != 0)
            {
                for (int k = 0; k < 6; k++)
                {
                    GameObject newCoinClone = Instantiate(originalCoinPrefab, new Vector3(obstaclesPositionX[i], 1.4f, obstaclesPositionZ[i] - 1) , transform.rotation);
                    obstaclesPositionZ[i] -= 1;
                }
            }
        }
    }
}
