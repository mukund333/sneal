using SnealUltra.Assets._Project.Scripts.Mixins;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol :MixinBase
{
    public CurrentWeaponData weaponDefination;

    public override void Action()
	{
        Shoot();
	}
	
	 private void Shoot()
     {
		  weaponDefination.dragCheckData.playrDrag = false;
          PoolManager.instance.GetObject("PistolBullet", weaponDefination.GetPlayerShootPoint(), Quaternion.Euler(0f, 0f, weaponDefination.GetPlayerRotation().eulerAngles.z));   
     }
   
}
