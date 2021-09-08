using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SnealUltra.Assets._Project.Scripts.Enemy;
using SnealUltra.Assets._Project.Scripts.Projectile;

namespace SnealUltra.Assets._Project.Scripts.Projectile
{
	[RequireComponent(typeof(Collider2D))]
	public class ProjectileManager : MonoBehaviour
	{
		//[SerializeField]ProjectileDatabase projectileDatabase;
		[Header("Projectile Settings")]

		[SerializeField]ProjectileData projectileData;
		
		Rigidbody2D body2d;


		private SpriteRenderer spriteRenderer; 
		public int damage = 1;
		
		public float bulletSpeed = 2f;
		public float time = 0.1f;
		
		[Header("Spred Projectile Settings")]

		public bool IsSpreadProjectile = false;
		public int numberOfProjectiles;
		public Vector2 startPoint;
		private float angle;
		




		
		
		


		private void Awake()
		{
			body2d = GetComponent<Rigidbody2D>();
			damage = projectileData.bulletDamage;
			bulletSpeed = projectileData.bulletSpeed;
			time = projectileData.bulletLifeTime;
			spriteRenderer = GetComponent<SpriteRenderer>();
			
		}
		void Start()
		{
			spriteRenderer.sprite = projectileData.bulletSprite;
		}


		void FixedUpdate()
		{
            body2d.AddForce(-transform.right * bulletSpeed);
          				//	Debug.Log(""+IsSpreadProjectile);


            StartCoroutine("OnDisableUnObjects");
            //BulletDistance();
        }

		
		public void BulletConfig()
		{


			body2d.velocity = new Vector2(0, 0);
		}

		private void OnTriggerEnter2D(Collider2D col)
		{
			if (!col.CompareTag("Player"))
			{
				if (col.CompareTag("Enemy"))
				{
					if (col.gameObject.GetComponent<EnemyManager>().IsImmortal == false)
					{
						col.gameObject.GetComponent<EnemyManager>().Damage(damage);
					}

					if (projectileData.bulletType != ProjectileData.Type.SniperBullet)
					{
						Hit();
					}
						
					
					//Debug.Log("enemy hit" + col.gameObject.name);
				}
				//	if (col.CompareTag("tile"))
				//	{
				//		col.getcomponent<tile>().damage(this.dmg);
				//		Hit();
				//	}
				//	if (col.CompareTag("menuelement"))
				//	{
				//		col.getcomponent<menuelementinteractable>().hit();
				//		Hit();
				//	}
				if (!col.isTrigger )
				{
					//Hit();
				}
			}
		}


		private void Hit()
		{
			//if (this.projectile.pType == ProjectileSpec.Type.Round)
			//{
			////	PoolManager.instance.GetObject("BulletHit", this.thisTransform.position, this.thisTransform.rotation).GetComponent<SpriteAnim>().PlayAnim(0, UnityEngine.Random.Range(50, 60), 0, true);
			//}
			//SoundManager.instance.PlayClip("Hit", this.thisTransform.position.x);

			if(IsSpreadProjectile==true)
			{
				 startPoint = transform.position;
				 SpawnProjectile(numberOfProjectiles);
				
				
			
			}

			gameObject.SetActive(false);

		}

		public void ObjectReuse()
		{
			BulletConfig();
			PoolManager.instance.ReturnObjectToPool(gameObject);

		}

		private void OnBecameInvisible()
		{
			gameObject.SetActive(false);
		}

		IEnumerator OnDisableUnObjects()
		{
			yield return new WaitForSeconds(time);
			
			if(IsSpreadProjectile==true)
			{
				 startPoint = transform.position;
				 SpawnProjectile(numberOfProjectiles);
				
				
			
			}
			
			gameObject.SetActive(false);
			
			StopCoroutine("OnDisableUnObjects");
		}
		
		
		private void SpawnProjectile(int _numberOfProjectiles)
		{
			 angle =  UnityEngine.Random.Range(0, 44);

			
			float angleStep = 360f / _numberOfProjectiles;
		 //angle = 10;
		
			for(int i =0 ; i <= _numberOfProjectiles-1;i++)
			{
				//float projectileDirXPosition  = startPoint.x + Mathf.Sin((angle * Mathf.PI)/180)*radius;
				//float projectileDirYPosition  = startPoint.y + Mathf.Cos((angle * Mathf.PI)/180)*radius;
			
				//Vector2 projectileVector = new Vector2(projectileDirXPosition,projectileDirYPosition);
				//Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * projectileSpeed;
			
				//GameObject tmpObj = PoolManager.instance.GetObject("SpreadBullet", startPoint, Quaternion.identity);

				//GameObject tmpObj = Instantiate(ProjectilePrefab,startPoint,Quaternion.identity);
				//tmpObj.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDirection.x,projectileMoveDirection.y);
			
				PoolManager.instance.GetObject("SpreadBullet",startPoint, Quaternion.Euler(0f, 0f,angle));

				angle += angleStep;
			}
		}
		

	}
}