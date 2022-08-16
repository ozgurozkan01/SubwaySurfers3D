using System;
using UnityEngine;
using UnityEngine.UI;
public class ScoreController : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private PowerUpController powerUpCont;
    [HideInInspector] public int _score;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            IncreaseScore();    
        }
    }
    

    private void IncreaseScore()
    {
        if (powerUpCont.doubleCoingActivate)
        {
            _score += 2;
        }
        
        else if (!powerUpCont.doubleCoingActivate)
        {
            _score += 1;
        }
        scoreText.text = "" + _score;
    }
}
