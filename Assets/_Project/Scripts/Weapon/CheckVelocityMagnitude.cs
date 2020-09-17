using SnealUltra.Assets._Project.Scripts.Mixins;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckVelocityMagnitude : MonoBehaviour
{
   
    private Rigidbody2D rb2d;
  
    int forceSpeed;

    
	
	public PlayerData playerData;

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

    private int VelocityMagnitude()
    {
        return (int)rb2d.velocity.magnitude;
    }
	

}
