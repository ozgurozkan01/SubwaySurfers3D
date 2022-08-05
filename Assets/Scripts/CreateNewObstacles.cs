using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class CreateNewObstacles : MonoBehaviour
{
    
    [SerializeField] private GameObject obstacleOverPassPrefab;
    [SerializeField] private GameObject obstacleUnderPassPrefab;
    [SerializeField] private GameObject obstacleNoPassPrefab;
    [SerializeField] private GameObject[] lastObstacles;
    [SerializeField] private int[] obstacleTypeList = {0, 0, 0}; // ( 0-> NoPass, 1-> UnderPass, 2-> OverPass)
    [SerializeField] private CopMovement copMovement;
    
    private int _passControl;
    private bool _triggerController = true;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Gate") && _triggerController)
        {
            DetermineTheObstacleType(obstacleTypeList);
            _triggerController = false;
        }
        StartCoroutine(TriggerController());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            copMovement.transform.position = gameObject.transform.position + new Vector3(0f, 0f, -4f);
            StartCoroutine(CollisionController());
        }
    }

    private void DetermineTheObstacleType(int[] objectList)
    {
        for (int i = 0; i < objectList.Length; i++)
        {
            objectList[i] = Random.Range(0, 3);
        }
        
        CheckPassExisted(objectList);
    }

    private void CheckPassExisted(int[] obstacleList)
    {
        for (int i = 0; i < obstacleList.Length; i++)
        {
            if (obstacleList[i] == 1 || obstacleList[i] == 2)
            {
                _passControl = 1;
            }
        }

        if (_passControl == 0)
        {
            Debug.Log("Something Wrong!");
            obstacleList[0] = 1;
        }
        
        AttachTheObstacles(obstacleList);
    }
    
    private void AttachTheObstacles(int[] obstacleList)
    {
        for (int i = 0; i < obstacleList.Length; i++)
        {
            if (obstacleList[i] == 0)
            {
                GameObject newObstacle = Instantiate(
                    obstacleNoPassPrefab, 
                    lastObstacles[i].transform.position + new Vector3(0f, 0f, 20f),
                    Quaternion.identity);
                lastObstacles[i] = newObstacle;
            }
            
            else if (obstacleList[i] == 1)
            {
                GameObject newObstacle = Instantiate(
                    obstacleUnderPassPrefab, 
                    lastObstacles[i].transform.position + new Vector3(0f, 0f, 20f), 
                    Quaternion.identity);
                lastObstacles[i] = newObstacle;
            }
            
            else if (obstacleList[i] == 2)
            {
                GameObject newObstacle = Instantiate(
                    obstacleOverPassPrefab, 
                    lastObstacles[i].transform.position + new Vector3(0f, 0f, 20f), 
                    Quaternion.identity);
                lastObstacles[i] = newObstacle;
            }   
        }
    }

    IEnumerator TriggerController()
    {
        yield return new WaitForSeconds(1f);
        _triggerController = true;
    }

    IEnumerator CollisionController()
    {
        yield return new WaitForSeconds(5f);
        copMovement.speed = 3f;
        yield return new WaitForSeconds(2f);
        copMovement.speed = 7f;
    }
}
