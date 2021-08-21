using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnealUltra.Assets._Project.Scripts.Enemy;
namespace SnealUltra.Assets._Project.Scripts.Projectile
{

	[RequireComponent(typeof(Collider2D))]
	public class SpreadProjectileTrigger : MonoBehaviour
	{
		[SerializeField]ProjectileData projectileData;
		Rigidbody2D body2d;
		private SpriteRenderer spriteRenderer; 
		public int damage = 1;
		public float time = 0.1f;
		 
		[Header("Projectile Settings")]
			public int numberOfProjectiles;
			public float projectileSpeed =5f;
			public GameObject ProjectilePrefab;

		[Header("Projectile Settings")]
			public Vector2 startPoint;
			private const float radius = 5f;
			public float angle;
			
			public bool isSpreadOn;
			
		
			private void Awake()
			{
				body2d = GetComponent<Rigidbody2D>();
				damage = projectileData.bulletDamage;
				//projectileSpeed = projectileData.bulletSpeed;
				time = projectileData.bulletLifeTime;
				spriteRenderer = GetComponent<SpriteRenderer>();
			}
			
			void Start()
			{
				spriteRenderer.sprite = projectileData.bulletSprite;
			}
			
			void FixedUpdate()
			{
          

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
			
			/*if(IsSpreadProjectile==true)
			{
				for (int i = 0; i < 5; i++)
				{
					float num = UnityEngine.Random.Range(-25, 25);
					
					Instantiate(SpreadBullet, this.transform.position,  Quaternion.Euler(0f, 0f, transform.rotation.z + num));
					
					//PoolManager.instance.GetObject("ShotGunBullet", weaponDefination.GetPlayerShootPoint(), Quaternion.Euler(0f, 0f, weaponDefination.GetPlayerRotation().eulerAngles.z + num));
				} 
			}*/
			
			startPoint = transform.position;
			angle =  Random.Range(0, 44);
			SpawnProjectile(numberOfProjectiles);
			
			gameObject.SetActive(false);
			
			StopCoroutine("OnDisableUnObjects");
		}

		private void SpawnProjectile(int _numberOfProjectiles)
	{
		float angleStep = 360f / _numberOfProjectiles;
		 //angle = 10;
		
		for(int i =0 ; i <= _numberOfProjectiles-1;i++)
		{
			float projectileDirXPosition  = startPoint.x + Mathf.Sin((angle * Mathf.PI)/180)*radius;
			float projectileDirYPosition  = startPoint.y + Mathf.Cos((angle * Mathf.PI)/180)*radius;
			
			Vector2 projectileVector = new Vector2(projectileDirXPosition,projectileDirYPosition);
			Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * projectileSpeed;
			
			GameObject tmpObj = PoolManager.instance.GetObject("SpreadBullet", startPoint, Quaternion.identity);

			//GameObject tmpObj = Instantiate(ProjectilePrefab,startPoint,Quaternion.identity);
			tmpObj.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDirection.x,projectileMoveDirection.y);
			
			angle += angleStep;
		}
	}
	}
}