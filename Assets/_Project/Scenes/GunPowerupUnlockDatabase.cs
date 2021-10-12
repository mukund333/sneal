using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPowerupUnlockDatabase : MonoBehaviour
{
	
	
	[SerializeField] GunPowerupUnlockData gunPowerupUnlockData;
	[SerializeField] GunPickupSpawner gunPickupSpawner;
	
	void Awake()
   {
	   gunPickupSpawner = GetComponent<GunPickupSpawner>();
	   
	   gunPowerupUnlockData.LoadUnlockData();
	   
	   if(gunPowerupUnlockData.zeroBuy)
	   {
		   gunPickupSpawner.enabled = false;
	   }
   }
}
