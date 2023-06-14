using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreLivesRunner : NormalRunner
{
    [SerializeField]
    private int maxLives = 2;

    private int currentLives;

    protected override void Start() {
        base.Start();
        currentLives = maxLives;
    }

    protected override void Hit() {
        currentLives--;
        if(currentLives == 0) {
            currentLives = maxLives;
            base.Hit();
        }
    }
}
