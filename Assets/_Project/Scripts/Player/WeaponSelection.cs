using SnealUltra.Assets._Project.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    public CurrentPlayerComponentData playerData;
    public EquipPlayerWeapon equipPlayerWeapon;
    public Recoil recoil;
  

    
    private void Awake()
    {
       
       
        playerData = GetComponent<CurrentPlayerComponentData>();
        equipPlayerWeapon = GetComponent<EquipPlayerWeapon>();
        recoil = GetComponent<Recoil>();
       
    }

    private void Start()
    {
        SelectEquipWeapon();
    }


    void SelectEquipWeapon()
    {
        
       
        equipPlayerWeapon.EquipWeapon(playerData.GetWeaponByName());

      
    }
}
