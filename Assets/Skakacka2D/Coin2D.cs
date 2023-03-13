using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin2D : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        var player = collision.GetComponent<PlayerCoins>();
        if(player != null) {
            player.AddCoin();
            Destroy(gameObject);
        }
    }
}
