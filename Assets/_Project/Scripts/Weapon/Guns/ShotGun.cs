using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnealUltra.Assets._Project.Scripts.Weapon;
using SnealUltra.Assets._Project.Scripts.Mixins;

public class ShotGun : MixinBase
{
 
   public CurrentWeaponData weaponDefination;
	
    public override void Action()
	{
        Shoot();
	}
	
	 private void Shoot()
     {
		 		  weaponDefination.dragCheckData.playrDrag = false;

			for (int i = 0; i < 5; i++)
            {
                float num = Random.Range(-weaponDefination.GetSpread(), weaponDefination.GetSpread());
                PoolManager.instance.GetObject("ShotGunBullet", weaponDefination.GetPlayerShootPoint(), Quaternion.Euler(0f, 0f, weaponDefination.GetPlayerRotation().eulerAngles.z + num));
            } 
     }
}
