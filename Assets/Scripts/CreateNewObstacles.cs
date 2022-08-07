using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class CreateNewObstacles : MonoBehaviour
{
    
    [SerializeField] private GameObject obstacleOverPassPrefab;
    [SerializeField] private GameObject obstacleUnderPassPrefab;
    [SerializeField] private GameObject obstacleNoPassPrefab;
    [SerializeField] private GameObject[] lastObstacles;
    [SerializeField] private int[] obstacleTypeList = new int[3]; // ( 0-> NoPass, 1-> UnderPass, 2-> OverPass)
    [SerializeField] private CopMovement copMovement;
    [SerializeField] private DestroyPlatform destroyPlatform;
    private GameObject[] _platformHolder;

    
    private int _obstacleIndex;
    private int _obstacleType;
    private int _passControl;
    
    private bool _triggerController = true;

    void Awake()
    {
        _platformHolder = new GameObject[3];
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Gate") && _triggerController)
        {
            PlatformFunctionCollection();
            _triggerController = false;
        }
        StartCoroutine(TriggerController());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            copMovement.CatchThePlayer();
            StartCoroutine(CollisionController());
        }
    }

    private void PlatformFunctionCollection()
    {
        DetermineTheObstacleType(obstacleTypeList);
        destroyPlatform.DestroyPlatformFunctionsCollection();
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
            _obstacleIndex = Random.Range(0, 3);
            _obstacleType = Random.Range(1, 3);
            obstacleList[_obstacleIndex] = _obstacleType;
        }

        _passControl = 0;
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
                
                _platformHolder[i] = lastObstacles[i];
                lastObstacles[i] = newObstacle;
                destroyPlatform.newPassedPlatform[i] = _platformHolder[i];
            }
            
            else if (obstacleList[i] == 1)
            {
                GameObject newObstacle = Instantiate(
                    obstacleUnderPassPrefab, 
                    lastObstacles[i].transform.position + new Vector3(0f, 0f, 20f), 
                    Quaternion.identity);
                
                _platformHolder[i] = lastObstacles[i];
                lastObstacles[i] = newObstacle;
                destroyPlatform.newPassedPlatform[i] = _platformHolder[i];
            }
            
            else if (obstacleList[i] == 2)
            {
                GameObject newObstacle = Instantiate(
                    obstacleOverPassPrefab, 
                    lastObstacles[i].transform.position + new Vector3(0f, 0f, 20f), 
                    Quaternion.identity);

                _platformHolder[i] = lastObstacles[i];
                lastObstacles[i] = newObstacle;
                destroyPlatform.newPassedPlatform[i] = _platformHolder[i];
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
        copMovement.speed = 5f;
        yield return new WaitForSeconds(1.5f);
        copMovement.speed = 7f;
    }
}
