using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnealUltra.Assets._Project.Scripts.Mixins;

public class Test : MonoBehaviour
{
	
	public MixinBase fireWeapon;
   
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
		{
			if(fireWeapon.Check())
            {
                fireWeapon.Action();
            }
		}
    }  
}
