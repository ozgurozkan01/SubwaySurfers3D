﻿using UnityEngine;
using System.Collections;
public class CopPositionController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private CopMovement copMovement;
    [SerializeField] private float lerpMultiplier;
    [SerializeField] private GameEndController gameEnd;
    [SerializeField] private PlayerStumble playerStumble;

    public void CatchThePlayer()
    {
        gameObject.transform.position = Vector3.Lerp(
            gameObject.transform.position,
            player.gameObject.transform.position + new Vector3(0f, 0f, -2.25f),
            lerpMultiplier);

        if (!gameEnd.gameEndControl)
        {
            StartCoroutine(MovingAwayFromPlayer());
        }
    }
    
    IEnumerator MovingAwayFromPlayer()
    {
        yield return new WaitForSeconds(5f);
        copMovement.speed = 5f;
        yield return new WaitForSeconds(1.5f);
        copMovement.speed = 8f;
        playerStumble.collisionNumber = 0;
    }
}
