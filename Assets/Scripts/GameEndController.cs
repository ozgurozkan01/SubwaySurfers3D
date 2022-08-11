﻿using UnityEngine;

public class GameEndController : MonoBehaviour
{
    [SerializeField] private PlayerStumble playerStumble;
    [SerializeField] private CopMovement copMovement;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerAnimationController playerAnimCont;
    [SerializeField] private CopAnimationController copAnimCont;

    [HideInInspector] public bool gameEndControl;
    void Update()
    {
        CheckGameEnded();
        GameEnded();
    }

    private void CheckGameEnded()
    {
        if (playerStumble.collisionNumber >= 2)
        {
            gameEndControl = true;
        }
    }
    
    void GameEnded()
    {
        if (gameEndControl)
        {
            playerMovement.speed = 0f;
            copMovement.speed = 0f;
            copMovement.gameObject.transform.position =
                playerMovement.gameObject.transform.position + new Vector3(0f, 0f, -1f);
            playerAnimCont.FallingAnimation();
            copAnimCont.CopGuardingAnimation();
        }
    }
}
