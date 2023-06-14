using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalRunner : Runner
{
    protected override void Hit() {
        ResetRunner();
    }

    protected override void Move() {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
