using UnityEngine;

public class CreateNewTraines : MonoBehaviour
{
    [SerializeField] private GameObject originalTrainPrefab;
    [SerializeField] private CreateNewObstacles createNewObstacles;
    private int trainAmount; 
    private int[] trainLine; 
    void Awake()
    {
        trainLine = new int[2];
    }

    private void DetermineTrainAmountRandomly()
    {
        trainAmount = Random.Range(1, 3); // 1 or 2
    }

    private void DetermineTrainLine()
    {
        for (int i = 0; i < trainAmount; i++)
        {
            trainLine[i] = Random.Range(0, 3); // 1-> left, 2-> middle, 3->left
        }
    } 
    
    public void CreateNewTrain()
    {
        DetermineTrainAmountRandomly();
        DetermineTrainLine();
        
        if (trainAmount == 1)
        {
            GameObject newTrain = Instantiate(originalTrainPrefab, 
                createNewObstacles.lastObstacles[trainLine[0]].transform.position + new Vector3(0f, 0f, 60f) 
                , transform.rotation);
        }
        
        else if (trainAmount == 2)
        {
            for (int i = 0; i < trainAmount; i++)
            {
                GameObject newTrain = Instantiate(originalTrainPrefab, 
                    createNewObstacles.lastObstacles[trainLine[i]].transform.position + new Vector3(0f, 0f, 60f) 
                    , transform.rotation);

                createNewObstacles.lastObstacles[i] = newTrain;
            }
        }
    }
    
    
}
