using UnityEngine;

public class PowerUpController : MonoBehaviour
{

    [SerializeField] private GameObject doubleCoinPrefab;
    [SerializeField] private GameObject coinMagnetPrefab;
    [SerializeField] private DetermineObstacleOrTrain determineObstacleOrTrain;
    [SerializeField] private ScoreController scoreController;
    
    [SerializeField] private float _powerUpDuration;
    private float _timerForCoinMagnet;
    private float _timerForDoubleCoin;

    private int powerUpType; // 1-> magnet, 2-> doubleCoin
    
    [HideInInspector] public bool coinMagnetActivate;
    [HideInInspector] public bool doubleCoingActivate;
    private bool _isTimingForCoinMagnet;
    private bool _isTimingForDoubleCoin;
    private bool _powerUpSpawnController = true;

    private int _lineNumber;
    
    void Awake()
    { 
        _timerForCoinMagnet = _powerUpDuration;
        _timerForDoubleCoin = _powerUpDuration;
    }
    
    void Update()
    {
        SpawnPowerUp();
        TimerForPowerUpDuration();
    }

    
    private void DetermineLineOfPowerUp()
    {
        _lineNumber = Random.Range(0, 3);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DoubleCoin"))
        {
            Debug.Log("player have collided");
            _isTimingForDoubleCoin = true;
            doubleCoingActivate = true;
            Destroy(collision.gameObject);
        }
        
        else if (collision.gameObject.CompareTag("CoinMagnet"))
        {
            Debug.Log("player have collided");
            _isTimingForCoinMagnet = true;
            coinMagnetActivate = true;
            Destroy(collision.gameObject);
        }
    }

    private void DeterminePowerUpType()
    {
        powerUpType = Random.Range(1, 3);
    }

    private void CreatePowerUp()
    {
        DeterminePowerUpType();
        DetermineLineOfPowerUp();
        
        // Magnet
        if (powerUpType == 1)
        {
            GameObject newCoinMagnet = Instantiate(
                coinMagnetPrefab,
                determineObstacleOrTrain.lastObjects[_lineNumber].transform.position + new Vector3(0F, 1.55F, 13F)
                , Quaternion.identity);
        }
        
        //DoubleCoin 
        else if (powerUpType == 2)
        {
            GameObject newDoubleCoin = Instantiate(
                coinMagnetPrefab, 
                determineObstacleOrTrain.lastObjects[_lineNumber].transform.position + new Vector3(0f, 1.55f, 13f), 
                Quaternion.identity);
                 
        }
    }
    
    private void TimerForPowerUpDuration()
    {
        if (_isTimingForCoinMagnet)
        {
            _timerForCoinMagnet -= Time.deltaTime;

            if (_timerForCoinMagnet <= 0)
            {
                _timerForCoinMagnet = 0;
                coinMagnetActivate = false;
                _isTimingForCoinMagnet = false;
            }
        }
        
        
        if (_isTimingForDoubleCoin)
        {
            _timerForDoubleCoin -= Time.deltaTime;

            if (_timerForCoinMagnet <= 0)
            {
                _timerForDoubleCoin = 0;
                doubleCoingActivate = false;
                _isTimingForDoubleCoin = false;
            }
        }
    }

    private void SpawnPowerUp()
    {
        if (scoreController._score % 5 == 0 && _powerUpSpawnController && scoreController._score != 0)
        {
            CreatePowerUp();
            _powerUpSpawnController = false;
        }
    }
}
