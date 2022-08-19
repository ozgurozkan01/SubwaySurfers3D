using UnityEngine;

public class CoinMovingMagnetPlayer : MonoBehaviour
{
    [SerializeField] private PowerUpController powerUpCont;
    [SerializeField] private GameObject spin;
    [SerializeField] private float speed;

    [HideInInspector] public bool isCoinMoving;
    private CharacterController _controller;
    private Vector3 _movementDirection;
    private float _movementDirectionMagnitude;
    
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        spin = GameObject.FindGameObjectWithTag("Spin");
        powerUpCont = FindObjectOfType<PowerUpController>();
    }
    
    void Update()
    {
        _movementDirectionMagnitude = (spin.transform.position - transform.position).magnitude;
        CheckCoinMagnetActivate();
        ContinueToMoveTillReachPlayer();
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
        if (_movementDirectionMagnitude <= 10f)
        {
            isCoinMoving = true;
            CoinMovement();
        }
    }

    private void ContinueToMoveTillReachPlayer()
    {
        if (!powerUpCont.coinMagnetActivate && isCoinMoving)
        {
            CoinMovement();
        }
    }

    private void CoinMovement()
    {
        _movementDirection = spin.transform.position - transform.position;
        _controller.Move(_movementDirection * (speed * Time.deltaTime));
    }
}
