using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKolize : MonoBehaviour
{
    private PlayerState playerState;

    public PlayerState PlayerState => playerState;

    private void Awake() {
        playerState = GetComponent<PlayerState>();
    }

    private void OnTriggerEnter(Collider other) {
        var enemyState = other.GetComponent<PlayerState>();
        if (enemyState.PlayerStateEnum == playerState.PlayerStateEnum)
            return;

        // vyhr·l by enemy?
        bool wouldEnemyWin = WouldEnemyWin(enemyState.PlayerStateEnum);

        if (wouldEnemyWin) {
            Debug.Log("Hr·Ë prohr·l!");
            Time.timeScale = 0;
        } else {
            Destroy(enemyState.gameObject);
        }

    }

    public bool WouldEnemyWin(StateEnum enemy) {
        
        if (playerState.PlayerStateEnum == StateEnum.Rock)
            return enemy == StateEnum.Paper;

        if (playerState.PlayerStateEnum == StateEnum.Paper)
            return enemy == StateEnum.Scissors;

        if (playerState.PlayerStateEnum == StateEnum.Scissors)
            return enemy == StateEnum.Rock;

        return false;
    }
}
