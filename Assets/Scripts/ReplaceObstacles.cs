using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ReplaceObstacles : MonoBehaviour
{
    
    [SerializeField] private GameObject obstacleOverPassPrefab;
    [SerializeField] private GameObject obstacleUnderPassPrefab;
    [SerializeField] private GameObject obstacleNoPassPrefab;

    [SerializeField] private GameObject[] lastObstacles;
    [SerializeField] private int[] obstacleTypeList; // ( 0-> NoPass, 1-> UnderPass, 2-> OverPass)

    private int _passControl;

    private int _passType;
    private int _obstacleIndex;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Gate"))
        {
            DetermineTheObstacleType();
        }
    }

    private void DetermineTheObstacleType()
    {
        for (int i = 0; i < obstacleTypeList.Length; i++)
        {
            obstacleTypeList[i] = Random.Range(0, 3);
        }
        
        CheckPassExisted();
        AttachTheObstacles(obstacleTypeList);
    }

    private void CheckPassExisted()
    {
        for (int i = 0; i < obstacleTypeList.Length; i++)
        {
            if (obstacleTypeList[i] == 1 || obstacleTypeList[i] == 2)
            {
                _passControl += 1;
            }
        }

        if (_passControl == 0)
        {
            _passType = Random.Range(1, 3);
            _obstacleIndex = Random.Range(0, 3);
            
            Debug.Log(_passType);
            Debug.Log(_obstacleIndex);
            
            obstacleTypeList[_obstacleIndex] = _passType;
        }
    }
    
    private void AttachTheObstacles(int[] obstacleList)
    {
        for (int i = 0; i < obstacleList.Length; i++)
        {
            if (obstacleList[i] == 0)
            {
                GameObject newObstacle = Instantiate(
                    obstacleNoPassPrefab, 
                    lastObstacles[i].transform.position + new Vector3(0f, 0f, 25f),
                    Quaternion.identity);
                lastObstacles[i] = newObstacle;
            }
            
            else if (obstacleList[i] == 1)
            {
                GameObject newObstacle = Instantiate(
                    obstacleUnderPassPrefab, 
                    lastObstacles[i].transform.position + new Vector3(0f, 0f, 25f), 
                    Quaternion.identity);
                lastObstacles[i] = newObstacle;
            }
            
            else if (obstacleList[i] == 2)
            {
                GameObject newObstacle = Instantiate(
                    obstacleOverPassPrefab, 
                    lastObstacles[i].transform.position + new Vector3(0f, 0f, 25f), 
                    Quaternion.identity);
                lastObstacles[i] = newObstacle;
            }   
        }
    }
    
}
