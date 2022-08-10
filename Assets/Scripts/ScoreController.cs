using UnityEngine;
using UnityEngine.UI;
public class ScoreController : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int _score;
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
        _score += 1;
        scoreText.text = "" + _score;
    }
}
