using System;
using UnityEngine;
using UnityEngine.UI;
public class ScoreController : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private PowerUpController powerUpCont;
    [HideInInspector] public int _score;
    [SerializeField] private CoinMovingMagnetPlayer magnetPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            magnetPlayer.isCoinMoving = false;
            Destroy(other.gameObject);
            IncreaseScore();
        }
        
        if (other.gameObject.CompareTag("Coin") && _score % 50 == 0 && _score != 0)
        {
            powerUpCont.SpawnPowerUp();
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
