using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public CurrentPlayerComponentData playerData;
    public WeaponData currentWeaponData;

    void Start()
    {

        
        rb2d = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {

        currentWeaponData = playerData.GetWeaponDataByName();
        //Debug.Log("" + playerData.GetWeaponDataByName());

    }

   //public void SetData(WeaponData weaponData)
   // {
   //     currentWeaponData = weaponData;
   //     Debug.Log(""+currentWeaponData.name);
   // }
    private void FixedUpdate()
    {      
			if(playerData.GetIsRecoilingComplete()== true)
			{
				GunRecoil();
			}
    }
    private void GunRecoil()
    {
        rb2d.drag = currentWeaponData.drag;
        rb2d.AddForce(transform.right *currentWeaponData.thrust, ForceMode2D.Impulse);
    }
}
