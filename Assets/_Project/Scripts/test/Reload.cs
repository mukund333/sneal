using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
	public int ammo;
	public int ammoPerShot;

    public float reloadTimer;
    public float reloadTime;
    public bool isReloading=false;

    public int intialSizeOfAmmo;

    
   
    void Start()
    {
        //      ammo=10;
        //ammoPerShot=1;
        intialSizeOfAmmo = ammo;
    }

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
		{
            Shoot();
		}

        ReloadGun();

    }

    private void Shoot()
    {
        if (ammo > 0)
        {
            ammo -= ammoPerShot;
            Debug.Log(ammo);
        }
        else
        {
            isReloading = true;
        }
    }


    private void ReloadGun()
    {
        if (ammo == 0)
            isReloading = true;



        if (isReloading)
        {
            reloadTime += Time.deltaTime;
            if (reloadTime > reloadTimer)
            {
                ammo = intialSizeOfAmmo;
                reloadTime = 0;
                isReloading = false;
            }
        }
    }
}

