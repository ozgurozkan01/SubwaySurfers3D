using UnityEngine;

public class DestroyPowerUp : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private PowerUpController powerUpCont;
    private float _passedAmount;
    
    // Update is called once per frame
    void Start()
    {
        player = GetComponent<GameObject>();
        player = GameObject.FindWithTag("Player");

        powerUpCont = GetComponent<PowerUpController>();
        powerUpCont = FindObjectOfType<PowerUpController>();
    }

    private void Update()
    {
        if (player.transform.position.z >= (transform.position.z + 3f))
        {
            DestroyPowerUpPlayerPassed();
        }
    }

    private void DestroyPowerUpPlayerPassed()
    {
            Destroy(gameObject);
            if (gameObject.tag == "CoinMagnet")
            {
                powerUpCont._coinMagnetSpawnController = true;
            }
            
            else if (gameObject.tag == "DoubleCoin")
            {
                powerUpCont._doubleCoinSpawnController = true;
            }
    }
}
