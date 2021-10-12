using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupUpgradeDatabase : MonoBehaviour
{
   [SerializeField] PickupUpgradeData pickupUpgradeData;
   
   
   private void Start(){
	   LoadPlayerHealth();
   }
   
   
   
   private void LoadPlayerHealth()
   {
	  pickupUpgradeData.MaxPlayerHealth = SaveSystem.LoadPlayerHealthUpgrade();   
   }
   
  
   
   
   
   
   private void LoadSheildHealth()
   {}
   
   private void LoadSheildTime()
   {}
   
}
