using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin2D : MonoBehaviour
{
    Animator coinAnimator;

    private void Start() {
        this.coinAnimator= GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        var player = collision.GetComponent<PlayerCoins>();
        if(player != null) {
            player.AddCoin();
            Debug.Log("DEstroying");
            this.coinAnimator.SetTrigger("Destroy");
            Destroy(gameObject, 1);
        }
    }
}
