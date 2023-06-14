using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusRunner : NormalRunner
{
    [SerializeField]
    private float maxAngle;

    [SerializeField]
    private float angleChange;

    bool goingLeft = false;
    float deviation = 0;

    protected override void Move() {
        base.Move();
        
        if(goingLeft) {
            transform.Rotate(Vector3.up * angleChange * Time.deltaTime);
            deviation += angleChange * Time.deltaTime;
            if(deviation > maxAngle) {
                goingLeft = !goingLeft;
            }
        } else {
            transform.Rotate(-Vector3.up * angleChange * Time.deltaTime);
            deviation -= angleChange * Time.deltaTime;
            if (deviation < -maxAngle) {
                goingLeft = !goingLeft;
            }
        }


    }
}
