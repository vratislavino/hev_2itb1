using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smg : Weapon
{

    protected override void ProcessShootingInput()
    {
        if (Input.GetButton("Fire1"))
        {
            if (PocetNaboju > 0 && currentShootCooldown <= 0 && currentCasPrebijeni <= 0)
            {
                Shoot();
            }
        }
    }

}
