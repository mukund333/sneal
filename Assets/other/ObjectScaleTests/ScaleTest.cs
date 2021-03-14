using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTest : MonoBehaviour
{
	 public float acc;
	 
    // public AnimationCurve accCurve;
	 
	 public float distance;
	 
	public float divided;
	
	public float spriteSize=1;
	
	
	 
	 //this.acc += 1f / this.accSpeed * Time.fixedDeltaTime;
     //this.rb2d.velocity = transform.right * (this.speed * this.accCurve.Evaluate(this.acc));
	 //acc = Mathf.Clamp(acc, 0f, 1f);
	 
	 private void Update()
	 {
		
		Scaler();
		
	 }
	 
	 private void Scaler()
	 {
		 acc = Mathf.Clamp(acc, 0f, 1f);
		 
		 if(distance <= 10 && distance >= 5){
			  acc = distance /10f;
			  spriteSize = (float)System.Math.Round(acc,1);
			
		 }
		
		 
		transform.localScale = new Vector3(spriteSize,spriteSize,1);

	 }
	
}
