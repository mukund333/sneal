using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countdown : MonoBehaviour
{
    public float timeRemaining = 10f;
	public bool isPowerGun= false;
	public bool isPowerGunRunning = false;
	

    void Update()
    {
       
		
		if(isPowerGun == true)
		{
			
			timeRemaining =10f;
			isPowerGunRunning = true;
			isPowerGun = false;
		}
		
		
		
		if(isPowerGunRunning)
		StartpPowerGun();
		
		
		
		
    }
	
	private void StartpPowerGun()
	{
		
		if (timeRemaining > 0)
		{
			timeRemaining -= Time.deltaTime;
			
		}else{
			isPowerGunRunning = false;
		}
	}
	
	IEnumerator TimerCoroutine()
	{
		yield return null;
	}
	
	
}
