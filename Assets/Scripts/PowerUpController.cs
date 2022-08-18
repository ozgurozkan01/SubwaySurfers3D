using UnityEngine;

public class PowerUpController : MonoBehaviour
{

    [SerializeField] private GameObject doubleCoinPrefab;
    [SerializeField] private GameObject coinMagnetPrefab;
    [SerializeField] private DetermineObstacleOrTrain determineObstacleOrTrain;
    
    [SerializeField] private float powerUpDuration;
    private float _timerForCoinMagnet;
    private float _timerForDoubleCoin;

    private int _powerUpType; // 1-> magnet, 2-> doubleCoin
    
    [HideInInspector] public bool coinMagnetActivate;
    [HideInInspector] public bool doubleCoinActivate;
    private bool _isTimingForCoinMagnet;
    private bool _isTimingForDoubleCoin;
    private bool _doubleCoinSpawnController = true;
    private bool _coinMagnetSpawnController = true;

    private int _lineNumber;
    
    void Start()
    {
        _timerForCoinMagnet = powerUpDuration;
        _timerForDoubleCoin = powerUpDuration;
    }
    
    void Update()
    {
        TimerForPowerUpDuration();
    }

    
    private void DetermineLineOfPowerUp()
    {
        _lineNumber = Random.Range(0, determineObstacleOrTrain.staticLineAmount);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DoubleCoin"))
        {
            _isTimingForDoubleCoin = true;
            doubleCoinActivate = true;
            Destroy(collision.gameObject);
        }
        
        else if (collision.gameObject.CompareTag("CoinMagnet"))
        {
            _isTimingForCoinMagnet = true;
            coinMagnetActivate = true;
            Destroy(collision.gameObject);
        }
    }

    private void DeterminePowerUpType()
    {
        _powerUpType = Random.Range(1, 3); // 1-> double coin, 2-> coin magnet
        Debug.Log(_powerUpType);
    }

    private void CreateDoubleCoinPowerUp()
    {
        GameObject newDoubleCoin = Instantiate(doubleCoinPrefab, determineObstacleOrTrain.staticLine[_lineNumber].transform.position + new Vector3(0f, 1.55f, 13f), transform.rotation);
    }

    private void CreateCoinMagnetPowerUp()
    {
        GameObject newCoinMagnet = Instantiate(coinMagnetPrefab,determineObstacleOrTrain.staticLine[_lineNumber].transform.position + new Vector3(0F, 1.55F, 13F), transform.rotation);
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
                _coinMagnetSpawnController = true;
            }
        }
        
        
        if (_isTimingForDoubleCoin)
        {
            _timerForDoubleCoin -= Time.deltaTime;

            if (_timerForDoubleCoin <= 0)
            {
                _timerForDoubleCoin = 0;
                doubleCoinActivate = false;
                _isTimingForDoubleCoin = false;
                _doubleCoinSpawnController = true;
            }
        }
    }

    public void SpawnPowerUp()
    {
        DeterminePowerUpType();
        DetermineLineOfPowerUp();
        if (_doubleCoinSpawnController && _powerUpType == 1)
        {
            CreateDoubleCoinPowerUp();
            _doubleCoinSpawnController = false;
        }
        
        else if (_coinMagnetSpawnController && _powerUpType == 2)
        { 
            CreateCoinMagnetPowerUp(); 
            _coinMagnetSpawnController = false;
        }
    }
}
