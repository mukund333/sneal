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
		private ProjectileSpec projectile;


		private ProjectileDatabase projectileDatabase;

		public int dmg = 1;

		Rigidbody2D body2d;
		public float bulletSpeed = 250f;
		public float speed = 0f;

		private void Awake()
		{
			body2d = GetComponent<Rigidbody2D>();
			projectileDatabase = ProjectileDatabase.instance;
			dmg = 1;
		}
		void Start()
		{

		}


		void FixedUpdate()
		{
			body2d.AddForce(-transform.right * bulletSpeed);
			speed = body2d.velocity.magnitude;

			StartCoroutine("OnDisableUnObjects");
		}

		public void Init(int projectileIndex)
		{
			projectile = projectileDatabase.GetProjectileByIndex(projectileIndex);
		}
		public void BulletConfig()
		{


			body2d.velocity = new Vector2(0, 0);
		}





		//void OnObjectReuse()
		//{
		//	BulletConfig();
		//	PoolManager.instance.ReturnObjectToPool(this);

		//}




		private void OnTriggerEnter2D(Collider2D col)
		{
			if (!col.CompareTag("Player"))
			{
				if (col.CompareTag("Enemy"))
				{

					col.gameObject.GetComponent<EnemyManager>().Damage(dmg);

					Hit();
					Debug.Log("enemy hit" + col.gameObject.name);
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
				if (!col.isTrigger)
				{
					Hit();
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
			yield return new WaitForSeconds(2);
			gameObject.SetActive(false);
			StopCoroutine("OnDisableUnObjects");

		}

	}
}