﻿using SnealUltra.Assets._Project.Scripts.Mixins;
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
          PoolManager.instance.GetObject("PistolBullet", weaponDefination.GetPlayerPosition(), Quaternion.Euler(0f, 0f, weaponDefination.GetPlayerRotation().eulerAngles.z));   
     }
   
}
