using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnealUltra.Assets._Project.Scripts.Weapon;
using SnealUltra.Assets._Project.Scripts.Mixins;

public class MachineGunS : MixinBase
{
    
    public CurrentWeaponData weaponDefination;

  
    public override void Action()
	{
        Shoot();
	}
	
	 private void Shoot()
     {
		float num = Random.Range(-weaponDefination.GetSpread(), weaponDefination.GetSpread());
        PoolManager.instance.GetObject("Projectile", weaponDefination.GetPlayerPosition(), Quaternion.Euler(0f, 0f,weaponDefination.GetPlayerRotation().eulerAngles.z + num));
     }
}
