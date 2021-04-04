using SnealUltra.Assets._Project.Scripts.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnealUltra.Assets._Project.Scripts.Enemy
{
    public class Follower : EnemyManager
	{
		public float Speed;

		
		public float turnRate;


		public Transform target;


		public Vector2 sizeMinMax;


		private Rigidbody2D rb2d;


		private float lastColTime;

		SpriteRenderer spriteRenderer;

		[SerializeField] private PlayerShield playerShield;
		
		//sprite scale
		public float distance;
		public float divided;
		public float spriteSize=2;
		 public float acc;

		public override void OnEnable()
		{
			playerShield = FindObjectOfType<PlayerShield>();
			try
			{
				target = FindObjectOfType<PlayerMovement>().transform;
			}
			catch (Exception ex)
			{
			}
			//float num = UnityEngine.Random.Range(this.sizeMinMax.x, this.sizeMinMax.y);
			//this.thisTrans.localScale = new Vector3(num, num, 1f);
			this.rb2d = base.GetComponent<Rigidbody2D>();
			//base.StartCoroutine(this.Behave());
		}


		public override void Start(){
			base.Start();
			try
			{
				target = FindObjectOfType<PlayerMovement>().transform;
			}
			catch (Exception ex)
			{
			}
			rb2d = GetComponent<Rigidbody2D>();
			spriteSize = 2;
	}

	
	
	private void Update()
	{
		//SpriteScaler();
		
		distance = Vector3.Distance(target.position, transform.position);
	}
	
	private void FixedUpdate()
	{
		Vector2 dir = target.position - thisTrans.position;
				float angle = Mathf.Atan2(dir.y, dir.x) * 57.29578f;
				Quaternion rot = Quaternion.AngleAxis(angle, new Vector3(0f, 0f, 1f));
				thisTrans.rotation = Quaternion.Slerp(thisTrans.rotation, rot, Time.deltaTime * turnRate);
				rb2d.velocity =  thisTrans.right * Speed;

			Debug.Log(playerShield.IsShieldOn);

	}


	

	/*private IEnumerator Behave(){
		
			while (gameObject.activeInHierarchy)
			{
				if (!target)
				{
					break;
				}
				Vector2 dir = target.position - thisTrans.position;
				float angle = Mathf.Atan2(dir.y, dir.x) * 57.29578f;
				Quaternion rot = Quaternion.AngleAxis(angle, new Vector3(0f, 0f, 1f));
				thisTrans.rotation = Quaternion.Slerp(thisTrans.rotation, rot, Time.deltaTime * turnRate);
				rb2d.velocity =  thisTrans.right * Speed;
				yield return 0;
			}
			yield return 0;
			yield break;
		}*/


		 private void SpriteScaler()
			{
				acc = Mathf.Clamp(acc, 0f, 1f);
		 
				if(distance <= 8 && distance >= 5){
					acc = distance /10f;
					spriteSize = (float)System.Math.Round(acc,1);
				
				}
		
		 
				transform.localScale = new Vector3(spriteSize,spriteSize,1);

			}
	
		private void OnCollisionEnter2D(Collision2D col){
			if (col.collider.CompareTag("Player"))
			{
				if(playerShield.IsShieldOn)
                {
					col.collider.GetComponent<PlayerShield>().DamageToShield(1);
                }
                else
                {
					col.collider.GetComponent<PlayerStats>().Damage(1);
				}
				
				//childCamera.instance.initializeCameraShake(0.4f, 0.05f);
				//ExplosionManager.instance.SpawnDynamicExplosion(col.contacts[0].point, new Vector2(1f, 2f), new Vector2(0.25f, 1.5f), 32, new Vector2(0.02f, 0.1f));


				Kill();

			}
		}

		

	}
}