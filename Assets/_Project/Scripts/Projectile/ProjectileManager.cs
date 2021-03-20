using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SnealUltra.Assets._Project.Scripts.Enemy;

namespace SnealUltra.Assets._Project.Scripts.Projectile
{
	[RequireComponent(typeof(Collider2D))]
	public class ProjectileManager : MonoBehaviour
	{
		//[SerializeField]ProjectileDatabase projectileDatabase;
		[SerializeField]ProjectileData projectileData;

		Rigidbody2D body2d;


		private SpriteRenderer spriteRenderer; 
		public int damage = 1;
		
		public float bulletSpeed = 2f;
		public float time = 0.1f;


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
			gameObject.SetActive(false);
			StopCoroutine("OnDisableUnObjects");

		}

		

	}
}