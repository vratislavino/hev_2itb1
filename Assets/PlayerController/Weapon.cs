using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public event Action<Weapon> AmmoChanged;
    public event Action<Weapon> ReloadStarted;
    public event Action<Weapon> ReloadEnded;
    public event Action<float> ReloadProgressChanged;

    [SerializeField]
    protected WeaponDisplay weaponDisplay;

    protected int pocetNaboju;

    public int PocetNaboju {
        get { return pocetNaboju; }
        protected set { 
            pocetNaboju = value;
            AmmoChanged?.Invoke(this);
        }
    }

    [SerializeField]
    protected int maxPocetNaboju;

    public int MaxPocetNaboju => maxPocetNaboju;

    [SerializeField]
    protected float shootCooldown;
    protected float currentShootCooldown;

    [SerializeField]
    protected float casPrebijeni;
    protected float currentCasPrebijeni;

    [SerializeField]
    protected GameObject bulletPrefab;

    [SerializeField]
    protected Transform bulletSpawn;

    [SerializeField]
    protected string weaponName;

    public string WeaponName => weaponName;

    [SerializeField]
    protected Sprite weaponImage;
    
    public Sprite WeaponImage => weaponImage;

    // Start is called before the first frame update
    void Start()
    {
        Reload();
    }


    // Update is called once per frame
    protected virtual void Update()
    {
        ProcessTimers();
        ProcessShootingInput();
        ProcessReloadInput();
    }


    private void ProcessTimers()
    {
        currentShootCooldown -= Time.deltaTime;

        if (currentCasPrebijeni > 0)
        {
            currentCasPrebijeni -= Time.deltaTime;
            ReloadProgressChanged?.Invoke(currentCasPrebijeni / casPrebijeni);
            if (currentCasPrebijeni <= 0)
                Reload();
        }
    }

    protected virtual void ProcessShootingInput()
    { // process zpracování støelby pro semi-auto zbranì

        if (Input.GetButtonDown("Fire1"))
        {
            if (PocetNaboju > 0 && currentShootCooldown <= 0 && currentCasPrebijeni <= 0)
            {
                Shoot();
            }
        }
    }

    private void ProcessReloadInput()
    { // implementace tady, protože je stejný pro všechny zbranì, po pøestávce :)
        if(Input.GetKeyDown(KeyCode.R))
        {
            if(currentCasPrebijeni <= 0 && PocetNaboju != maxPocetNaboju)
            {
                ReloadStarted?.Invoke(this);
                currentCasPrebijeni = casPrebijeni;
            }
        }
    }

    protected void Reload() {
        PocetNaboju = maxPocetNaboju;
        ReloadEnded?.Invoke(this);
    }

    protected virtual void Shoot()
    {
        currentShootCooldown = shootCooldown;
        PocetNaboju--;

        var bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);

        var bulletRigid = bullet.GetComponent<Rigidbody>();
        bulletRigid.AddForce(transform.forward * 0.1f, ForceMode.Impulse);

     }

}