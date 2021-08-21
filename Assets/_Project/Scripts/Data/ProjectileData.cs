using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet", menuName = "BulletData")]
public class ProjectileData : ScriptableObject
{
    public enum Type
    {

        PistolBullet,

        RifleBullet,

        ShotGunBullet,

        MachineGunBullet,
		
		SniperBullet,
		
		SpreadBullet

        //LaserGun,

        //RocketLauncher,

        //GrenadeLauncher
    }

    [Header("Bullet Attributes")]


    public string BulletName;

    public Type bulletType;

    public Sprite bulletSprite;

    public int bulletDamage;

    public float bulletSpeed;

    public float bulletLifeTime;

}
