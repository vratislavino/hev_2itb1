using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField]
    private float maxSpread = 0.2f;

    protected override void Shoot()
    {
        for(int i = 0; i < 5; i++)
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);

            var bulletRigid = bullet.GetComponent<Rigidbody>();
            bulletRigid.AddForce(GetRandomDirection() * 0.1f, ForceMode.Impulse);
        }

        currentShootCooldown = shootCooldown;
        PocetNaboju--;
    }

    private Vector3 GetRandomDirection()
    {
        Vector3 direction = transform.forward;

        direction.x += Random.Range(-maxSpread, maxSpread); 
        direction.y += Random.Range(-maxSpread, maxSpread); 
        direction.z += Random.Range(-maxSpread, maxSpread);

        return direction;
    }

}
