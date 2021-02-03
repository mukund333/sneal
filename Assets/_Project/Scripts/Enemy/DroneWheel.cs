using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneWheel : MonoBehaviour
{
   [SerializeField] Transform Pivot;
	[SerializeField] Transform ThisTransform = null;

						
	
	//Distance to maintain from pivot
	[SerializeField] float PivotDistance = 5f;
	[SerializeField] float RotSpeed = 10f;
	
	[SerializeField] float RotZ = 0f;
	
	[SerializeField] float Angle;
	
	
	
	
	void Awake()
	{
		ThisTransform = GetComponent<Transform>();
			
	}
	
  
    void Update()
    {
        RotZ += RotSpeed * Time.deltaTime;
		
		// RotZ +=Angle;
		 
		 RotZ = RotZ % 360;
		
		//actualAngle=Mathf.Repeat(inputAngle,360);
		
		Quaternion ZRot = Quaternion.Euler(0f,0f,RotZ+Angle);
		
		ThisTransform.rotation = ZRot;
		
		//Adjust position
		Vector3 position = Pivot.position + ThisTransform.rotation * Vector3.right * -PivotDistance;
		ThisTransform.position = position;
		
    }
}
