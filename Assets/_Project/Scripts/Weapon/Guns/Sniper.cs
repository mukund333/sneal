﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnealUltra.Assets._Project.Scripts.Mixins;


public class Sniper : MixinBase
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

        PoolManager.instance.GetObject("SniperBullet", weaponDefination.GetPlayerShootPoint(),Quaternion.Euler(0f, 0f, weaponDefination.GetPlayerRotation().eulerAngles.z + num2));
     }
}
