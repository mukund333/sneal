using SnealUltra.Assets._Project.Scripts.Mixins;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckVelocityMagnitude : MonoBehaviour
{
   
    private Rigidbody2D rb2d;
  
    float forceSpeed;

    
	
	public CurrentPlayerComponentData playerData;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }  
    private void Update()
    {
        forceSpeed = VelocityMagnitude();

       // recoilData.rigidbodyData = forceSpeed;
	   playerData.SetRigidBodyData(forceSpeed);
	   
		
		
    }

    private float VelocityMagnitude()
    {
        float v = (float)System.Math.Round(rb2d.velocity.magnitude, 1);
        return v;
    }
	

}
