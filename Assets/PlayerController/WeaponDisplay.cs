using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class WeaponDisplay : MonoBehaviour
{
    [SerializeField]
    Image weaponImage;

    [SerializeField]
    TMP_Text weaponName;

    [SerializeField]
    TMP_Text ammo;

    [SerializeField]
    Image reloadProgress;

    [SerializeField]
    WeaponManager weaponManager;

    private void Awake() {
        weaponManager.WeaponChanged += OnWeaponChanged;
        
        foreach(var weapon in weaponManager.Weapons) {
            weapon.AmmoChanged += OnAmmoChanged;
            weapon.ReloadStarted += OnReloadStarted;
            weapon.ReloadProgressChanged += OnReloadProgressChanged;
            weapon.ReloadEnded += OnReloadEnded;

        }
    }

    private void OnReloadEnded(Weapon weapon) {
        reloadProgress.gameObject.SetActive(false);
        ammo.gameObject.SetActive(true);
    }

    private void OnReloadProgressChanged(float progress) {
        reloadProgress.fillAmount = progress;
    }

    private void OnReloadStarted(Weapon weapon) {
        reloadProgress.gameObject.SetActive(true);
        ammo.gameObject.SetActive(false);
    }

    private void OnAmmoChanged(Weapon weapon) {
        ammo.text = $"{weapon.PocetNaboju}/{weapon.MaxPocetNaboju}";
    }

    private void OnWeaponChanged(Weapon weapon) {
        weaponImage.sprite = weapon.WeaponImage;
        this.weaponName.text = weapon.WeaponName;
        ammo.text = $"{weapon.PocetNaboju}/{weapon.MaxPocetNaboju}";
    }
}
