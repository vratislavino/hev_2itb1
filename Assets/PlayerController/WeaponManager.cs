using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WeaponManager : MonoBehaviour
{
    public event Action<Weapon> WeaponChanged;

    private List<Weapon> weapons;

    public List<Weapon> Weapons {
        get { 
            if(weapons == null) {
                weapons = GetComponentsInChildren<Weapon>(true).ToList();
            }    
            return weapons; 
        }
    }

    void Start()
    {
        ActivateWeapon(0);
    }

    private void ActivateWeapon(int index) {
        foreach(var weapon in Weapons) {
            weapon.gameObject.SetActive(false);
        }

        Weapons[index].gameObject.SetActive(true);
        WeaponChanged?.Invoke(Weapons[index]);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            ActivateWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            ActivateWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            ActivateWeapon(2);
        }
    }
}
