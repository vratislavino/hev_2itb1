using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKolize : MonoBehaviour
{
    private PlayerState playerState;

    private void Awake() {
        playerState = GetComponent<PlayerState>();
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.CompareTag("Enemy")) {
            
            var enemyState = collision.collider.GetComponent<PlayerState>();
            if (enemyState.PlayerStateEnum == playerState.PlayerStateEnum)
                return;

            if (playerState.PlayerStateEnum == StateEnum.Rock) {
                 // TODO: doøešit podmínky 
            }
        }
    }
}
