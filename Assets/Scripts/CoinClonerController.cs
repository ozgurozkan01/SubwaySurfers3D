using UnityEngine;

public class CoinClonerController : MonoBehaviour
{
    [SerializeField] private GameObject originalCoinPrefab;

    [HideInInspector] public float[] obstaclesPositionX;
    [HideInInspector] public float[] obstaclesPositionZ;
    private int _lineNumber;
    
    void Awake()
    {
        obstaclesPositionX = new float[3];
        obstaclesPositionZ = new float[3];
    }
    
    public void CloneCoin()
    {
        for (int i = 0; i < 3; i++)
        {
            if (obstaclesPositionX[i] != 0 || obstaclesPositionZ[i] != 0)
            {
                for (int k = 0; k < 6; k++)
                {
                    GameObject newCoinClone = Instantiate(originalCoinPrefab, new Vector3(obstaclesPositionX[i], 1.55f, obstaclesPositionZ[i] - 2) , transform.rotation);
                    obstaclesPositionZ[i] -= 1;
                }
            }
        }
    }
}
