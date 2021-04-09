using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnealUltra.Assets._Project.Scripts.Mixins;

public class RifleGun : MixinBase
{
    public CurrentWeaponData weaponDefination;



    public override void Action()
	{
      
        Shoot();
	}
	
	 private void Shoot()
     {
		 weaponDefination.dragCheckData.playrDrag = false;
		 
		int num2 = Choose(-1, 1, new int[0]);

        PoolManager.instance.GetObject("RiffleBullet", weaponDefination.GetPlayerShootPoint(), Quaternion.Euler(0f, 0f, weaponDefination.GetPlayerRotation().eulerAngles.z + num2));
		
		//childCamera.instance.initializeCameraShake(4, 0.05f);
     }
}
