using SnealUltra.Assets._Project.Scripts.Mixins;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnealUltra.Assets._Project.Scripts.Player
{
    public class EquipPlayerWeapon : MonoBehaviour
    {
		public enum State
		{
			AutoFire,
			ManualFire


		}

		 public State state;
		 public bool isToggling =false;
        //public string startGunName;
        public PlayerPhysics recoil;
       
        public Transform weaponSlot;
        private GameObject currentWeapon;
        public CurrentPlayerComponentData playerData;
        public bool isAutoTiggering;
		public MixinBase fireWeapon;
		public ShootTouch shootTouch;
		public bool isShooting;
		public ToggleSwitch toggleSwitch;
		public Muzzle muzzle;
        

        void Start(){
			shootTouch   =  FindObjectOfType<ShootTouch>();
			toggleSwitch = FindObjectOfType<ToggleSwitch>();
			muzzle = GetComponentInChildren<Muzzle>();
            EquipWeapon(playerData.GetWeaponByName());
            recoil = GetComponent<PlayerPhysics>();
			isToggling =false;
			state = State.AutoFire;
			
        }

        void Update(){
			isShooting =false;
            if (playerData.isPassWeapon == true) {
                EquipWeapon(playerData.GetWeaponByName());
                //recoil.currentWeaponData = playerData.GetWeaponDataByName();
                playerData.isPassWeapon = false;

            }

			if(isToggling==true){
				ToggleFire();
				isToggling = false;
		
			}
			
			switch (state){
				
				case State.AutoFire:
					
						muzzle.IsMuzzle=true;
						FireWeapon();
					

                break;
				
				case State.ManualFire:
					isAutoTiggering =false;
					muzzle.IsMuzzle=false;
					
					if (Input.GetKey(KeyCode.Space))
					{
                    //if (fireWeapon.Check())
                    //{
                    //    fireWeapon.Action();
                    //}
                      FireWeapon();
					  muzzle.IsMuzzle=true;
                   }
				   
				   if (Input.GetKeyDown(KeyCode.E))
					{
						//bomb luncher
				
					}
               
				
				  if( shootTouch.IsDown())
					{
						FireWeapon();
					}
				
				 break;
				
			}	
			
        }      

        public void EquipWeapon(GameObject weaponPrefab){
           
            if (currentWeapon != null)
                Destroy(currentWeapon);
            currentWeapon = Instantiate(weaponPrefab, weaponSlot);
            fireWeapon = currentWeapon.GetComponent<CallMixinActions>();
           
            
        }

		public void FireWeapon(){
			 fireWeapon.CheckAndAction();
			 isShooting = true;
				
		}
		
		public bool IsShooting(){
			return isShooting && isShooting;
		}
		
		private void  ToggleFire(){
			if(toggleSwitch.isOn == true)
			{
				state = State.AutoFire;
			}else{
				
				state = State.ManualFire;
			}
			
		}
		
	}

    
   
}