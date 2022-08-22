using System;
using UnityEngine;
using UnityEngine.UI;
public class ScoreController : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private PowerUpController powerUpCont;
    [HideInInspector] public int _score;
    [SerializeField] private CoinMovingMagnetPlayer magnetPlayer;
    [SerializeField] private PlaneController planeController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            magnetPlayer.isCoinMoving = false;
            Destroy(other.gameObject);
            IncreaseScore();
            
                    
            if (_score % 50 == 0 && _score != 0)
            {
                powerUpCont.SpawnPowerUp();
            }
            
            else if (_score % 75 == 0 && _score != 0)
            {
                planeController.UpdatePlatformPosition();
            }
        }
    }
    

    private void IncreaseScore()
    {
        if (powerUpCont.doubleCoinActivate)
        {
            _score += 2;
        }
        
        else if (!powerUpCont.doubleCoinActivate)
        {
            _score += 1;
        }
        scoreText.text = "" + _score;
    }
}
