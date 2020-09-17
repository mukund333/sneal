using SnealUltra.Assets._Project.Scripts.Core;
using SnealUltra.Assets._Project.Scripts.Weapon;
using System.Collections;
using UnityEngine;

namespace SnealUltra.Assets._Project.Scripts.Player
{
    public class PlayerController : Behave
    {
        public string startGun = "Pistol";

        private Rigidbody2D rb2d;
        public int forceSpeed = 0;
        public bool fire = false;

        private Transform shootPoint;
        private Transform sprite;

        private ShootFunction shootFunction;

        private delegate void ShootFunction();

        [Header("Pistol Reload Settings")]

        public int ammo;
        public int ammoPerShot;
        public float reloadTimer;
        public float reloadTime;
        public bool isReloading = false;
        public int intialSizeOfAmmo;

        [Header("Pistol Type Settings")]
        //public Type startGun;

        public WeaponStruct currentWeapon;

        private void Awake()
        {

            intialSizeOfAmmo = ammo;
        }

        private void Start()
        {
            shootPoint = transform.GetChild(0);
            sprite = transform.GetChild(1);

            rb2d = GetComponent<Rigidbody2D>();
            rb2d.drag = currentWeapon.drag;

            EquipWeaponByName(startGun);
        }

        //private void GameStarted()
        //{
        //    this.EquipWeaponDirect(WeaponDatabase.instance.GenerateWeapon());
        //}

        public void EquipWeaponByName(string name)
        {
            currentWeapon = WeaponDatabase.instance.GetWeaponByName(name);
            WeaponStruct.Type wepType = currentWeapon.wepType;

            switch (wepType)
            {
                case WeaponStruct.Type.Pistol:
                    shootFunction = new ShootFunction(StandardGun);
                    break;

                case WeaponStruct.Type.Rifle:
                    shootFunction = new ShootFunction(Rifle);
                    break;

                case WeaponStruct.Type.ShotGun:
                    shootFunction = new ShootFunction(ShotGun);
                    break;

                case WeaponStruct.Type.MachineGun:
                    shootFunction = new ShootFunction(MachineGun);
                    break;
            }
        }

        private void Update()
        {
            forceSpeed = CheckVelocityMagnitude();

            GunTrigger();

            Reload();
        }

        private void GunTrigger()
        {
            if (Time.time > currentWeapon.lastShotTime & forceSpeed == 0)//gun trigger
            {
                fire = true;
                currentWeapon.lastShotTime = Time.time;
            }
        }

        private int CheckVelocityMagnitude()
        {
            return (int)rb2d.velocity.magnitude;
        }

        private void FixedUpdate()
        {
            Shoot();
        }

        private void Shoot()
        {
            if (fire == true && isReloading == false)
            {
                fire = false;

                GunRecoil();

                shootFunction();
            }
        }

        private void GunRecoil()
        {
            rb2d.drag = currentWeapon.drag;
            rb2d.AddForce(transform.right * currentWeapon.thrust, ForceMode2D.Impulse);
        }

        private void Reload()
        {
            if (isReloading)
            {
                reloadTime += Time.deltaTime;
                if (reloadTime > reloadTimer)
                {
                    ammo = intialSizeOfAmmo;
                    reloadTime = 0;
                    isReloading = false;
                }
            }
        }

        public void EquipWeaponDirect(WeaponStruct wep)
        {

            currentWeapon = wep;
            WeaponStruct.Type wepType = currentWeapon.wepType;

            if (wepType != WeaponStruct.Type.Pistol)
            {
                if (wepType != WeaponStruct.Type.ShotGun)
                {
                    if (wepType == WeaponStruct.Type.Rifle)
                    {
                        shootFunction = new ShootFunction(Rifle);
                    }
                }
                else
                {
                    shootFunction = new ShootFunction(ShotGun);
                }
            }
            else
            {
                shootFunction = new ShootFunction(MachineGun);
            }
        }
        
        private void StandardGun()
        {
            PoolManager.instance.GetObject("Projectile", shootPoint.position, Quaternion.Euler(0f, 0f, sprite.rotation.eulerAngles.z));
        }

        private void Rifle()
        {
            if (ammo == 1)
                StartCoroutine(ChangeDrag(currentWeapon.drag, 3.5f, 0.01f));

            if (ammo > 0)
            {
                ammo -= ammoPerShot;

                int num2 = Choose(-1, 1, new int[0]);

                PoolManager.instance.GetObject("Projectile", shootPoint.position, Quaternion.Euler(0f, 0f, sprite.rotation.eulerAngles.z + num2));
            }
            else
            {
                isReloading = true;
            }
        }

        private void ShotGun()
        {
            for (int i = 0; i < 5; i++)
            {
                float num = Random.Range(-currentWeapon.spread, currentWeapon.spread);
                PoolManager.instance.GetObject("Projectile", shootPoint.position, Quaternion.Euler(0f, 0f, sprite.rotation.eulerAngles.z + num));
            }
        }

        private void MachineGun()
        {

            float num = Random.Range(-currentWeapon.spread, currentWeapon.spread);
            PoolManager.instance.GetObject("Projectile", shootPoint.position, Quaternion.Euler(0f, 0f, sprite.rotation.eulerAngles.z + num));
        }

        IEnumerator ChangeDrag(float v_start, float v_end, float duration)
        {
            float elapsed = 0.0f;
            while (elapsed < duration)
            {
                currentWeapon.drag = Mathf.Lerp(v_start, v_end, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
            }
            currentWeapon.drag = v_end;
        }
    }
}