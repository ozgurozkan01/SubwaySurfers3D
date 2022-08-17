using UnityEngine;

public class CoinMovingMagnetPlayer : MonoBehaviour
{
    [SerializeField] private PowerUpController powerUpCont;
    [SerializeField] private GameObject spin;
    [SerializeField] private float speed;
    
    private CharacterController _controller;
    
    private Vector3 movementDirection;
    private float movementDirectionMagnitude;
    
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        spin = GameObject.FindGameObjectWithTag("Spin");
        powerUpCont = GameObject.FindObjectOfType<PowerUpController>();
    }
    
    void Update()
    {
        movementDirectionMagnitude = (spin.transform.position - transform.position).magnitude;
        CheckCoinMagnetActivate();
    }

    private void CheckCoinMagnetActivate()
    {
        if (powerUpCont.coinMagnetActivate)
        {
            CoinMoveToPlayer();
        }
    }

    private void CoinMoveToPlayer()
    {
        if (movementDirectionMagnitude <= 10f)
        {
            movementDirection = spin.transform.position - transform.position;
            _controller.Move(movementDirection * (speed * Time.deltaTime));
        }
    }
}
