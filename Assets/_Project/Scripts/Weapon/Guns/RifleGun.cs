using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnealUltra.Assets._Project.Scripts.Mixins;

public class RifleGun : MixinBase
{
    public CurrentWeaponData playerTransformData;



    public override void Action()
	{
      
        Shoot();
	}
	
	 private void Shoot()
     {
		int num2 = Choose(-1, 1, new int[0]);

        PoolManager.instance.GetObject("RiffleBullet", playerTransformData.GetPlayerPosition(), Quaternion.Euler(0f, 0f, playerTransformData.GetPlayerRotation().eulerAngles.z + num2));
     }
}
