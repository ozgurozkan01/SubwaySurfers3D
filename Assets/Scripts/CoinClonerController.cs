using UnityEngine;

public class CoinClonerController : MonoBehaviour
{
    [SerializeField] private GameObject originalCoinPrefab;

    [HideInInspector] public float obstaclesPositionX;
    [HideInInspector] public float obstaclesPositionZ;
    private int _lineNumber;
    
    public void CloneCoin(float xPos, float zPos)
    {
        for (int k = 0; k < 6; k++)
        {
            GameObject newCoinClone = Instantiate(originalCoinPrefab, new Vector3(xPos, 1.55f, zPos - 3) , transform.rotation);
            zPos -= 1;
        }
    }
}
