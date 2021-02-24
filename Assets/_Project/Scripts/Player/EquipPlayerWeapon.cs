using SnealUltra.Assets._Project.Scripts.Mixins;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnealUltra.Assets._Project.Scripts.Player
{
    public class EquipPlayerWeapon : MonoBehaviour
    {
        //public string startGunName;
        public PlayerPhysics recoil;
       
        public Transform weaponSlot;
        private GameObject currentWeapon;
        public CurrentPlayerComponentData playerData;
        public bool isAutoTiggering;
		
		 public MixinBase fireWeapon;
        

        void Start()
        {
            EquipWeapon(playerData.GetWeaponByName());
            recoil = GetComponent<PlayerPhysics>();
        }

        void Update()
        {
            if (playerData.isPassWeapon == true)
            {
                EquipWeapon(playerData.GetWeaponByName());
                //recoil.currentWeaponData = playerData.GetWeaponDataByName();
                playerData.isPassWeapon = false;

            }

            if (isAutoTiggering==true)
            {
                fireWeapon.CheckAndAction();
            }
            else
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    //if (fireWeapon.Check())
                    //{
                    //    fireWeapon.Action();
                    //}
                    fireWeapon.CheckAndAction();
                }
            }
           

            if (Input.GetKeyDown(KeyCode.E))
            {
                
            }
        }      

        public void EquipWeapon(GameObject weaponPrefab)
        {
           
            if (currentWeapon != null)
                Destroy(currentWeapon);
            currentWeapon = Instantiate(weaponPrefab, weaponSlot);
            fireWeapon = currentWeapon.GetComponent<CallMixinActions>();
           
            
        }

    }

    
   
}