using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpUnlockDatabase : MonoBehaviour
{
   [SerializeField] PowerUpUnlockData powerUpUnlockData;
   
   [SerializeField] PowerupPickup powerupPickup;

	

   
   void Awake()
   {
	   powerupPickup = GetComponent<PowerupPickup>();
	   
	   powerUpUnlockData.LoadUnlockData();
	   
	   if(powerUpUnlockData.zeroBuy)
	   {
		   powerupPickup.enabled = false;
	   }
   }
}
