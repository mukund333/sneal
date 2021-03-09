using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnealUltra.Assets._Project.Scripts.Weapon;
using SnealUltra.Assets._Project.Scripts.Mixins;

public class MachineGunPlaySound : MixinBase
{
	
	
	public	 float lastSfxTime;

  
    public override void Action()
	{
        PlayGunSFX();
	}
	
   private void PlayGunSFX()
	{
		if ( Time.time - this.lastSfxTime > 1f / 15)
		{
			SoundManager.instance.PlayClip("machinegun", transform.position.x);
			this.lastSfxTime = Time.time;
		}
	}
}
