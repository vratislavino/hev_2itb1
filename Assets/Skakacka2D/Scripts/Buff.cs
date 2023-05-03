using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff : MonoBehaviour
{
    protected float duration;
    private float remaining;

    protected float multiplier;
    protected BuffType buffType;
    protected int stacks = 0;

    public float GetMultiplier() {
        return Mathf.Pow(multiplier, stacks);
    }

    public void Collect(float duration, float multiplier, BuffType buffType) {
        this.duration = duration;
        this.multiplier = multiplier;
        this.buffType = buffType;

        this.remaining = duration;
        this.stacks++;
    }

    // Update is called once per frame
    void Update()
    {
        if(stacks > 0) {
            remaining -= Time.deltaTime;
            if(remaining <= 0) {
                stacks--;
                remaining = duration;
                if(stacks == 0) {
                    Destroy(this);
                }
            }
        }
    }
}

public enum BuffType
{
    Speed, Jump, Time
}
