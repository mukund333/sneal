using System;
using UnityEngine;


	
	public class ProjectileDatabase : MonoBehaviour
	{
	[SerializeField] ProjectileData[] BulletData;

        [SerializeField]int gunNumber;

        [SerializeField]private GameObject player;

        [SerializeField] private CurrentPlayerComponentData playerWeapon;

       public bool isWeaponChange = false;
        private void OnEnable()
        {
           

            player = GameObject.Find("player");
           



        }
        private void Awake()
        {
            playerWeapon = FindObjectOfType<CurrentPlayerComponentData>();
        }

        private void Start()
        {
             gunNumber = playerWeapon.weaponNumber;
        }

        private void Update()
        {
            if (!isWeaponChange)
            {
                ChangeBulletData();
            }
            isWeaponChange = true;

           
        }
        private void ChangeBulletData() {
            gunNumber = playerWeapon.weaponNumber;
        }



    }
