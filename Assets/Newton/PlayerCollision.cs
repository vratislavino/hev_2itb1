using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCollision : MonoBehaviour
{
    public event Action<int> LivesChanged;

    private int lives = 3;
    private bool immortal = false;
    private int immortalTimeAfterHit = 1;

    [SerializeField]
    private GameObject shield;

    [SerializeField]
    private GameObject deathScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void BecomeMortal() {
        immortal = false;
        shield.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.collider.enabled = false;
        if (!immortal)
        {
            shield.SetActive(true);
            immortal = true;
            Invoke("BecomeMortal", immortalTimeAfterHit);
            lives--;
            // vydat událost o zmìnì životù
            LivesChanged?.Invoke(lives);

            CheckAlive();
        }
    }

    private void CheckAlive()
    {
        if(lives == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        deathScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
