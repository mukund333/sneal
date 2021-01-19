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

		public override void Start()
		{
			spriteRenderer = GetComponent<SpriteRenderer>();

			try
			{
				target = FindObjectOfType<PlayerController>().transform;
			}
			catch (Exception ex)
			{

			}
			rb2d = GetComponent<Rigidbody2D>();
		}


		public override void OnEnable()
		{
			try
			{
				target = PlayerStats.instance.transform;
			}
			catch (Exception ex)
			{
			}
			//float num = UnityEngine.Random.Range(sizeMinMax.x, sizeMinMax.y);
			//thisTrans.localScale = new Vector3(num, num, 1f);
			rb2d = GetComponent<Rigidbody2D>();
			StartCoroutine(Behave());
		}


		private IEnumerator Behave()
		{
			while (gameObject.activeInHierarchy)
			{
				if (!target)
				{
					break;
				}
				Vector2 dir = target.position - thisTrans.position;
				float angle = Mathf.Atan2(dir.y, dir.x) * 57.29578f;
				Quaternion rot = Quaternion.AngleAxis(angle, new Vector3(0f, 0f, 1f));
				thisTrans.rotation = Quaternion.Slerp(thisTrans.rotation, rot, Time.fixedDeltaTime * turnRate);
				rb2d.velocity = thisTrans.right * Speed;
				yield return 0;
			}
			yield return 0;
			yield break;
		}


		private void OnCollisionEnter2D(Collision2D col)
		{
			if (col.collider.CompareTag("Player"))
			{
				col.collider.GetComponent<PlayerStats>().Damage(5);
				//CameraController.instance.initializeCameraShake(3f, 0.05f);
				//ExplosionManager.instance.SpawnDynamicExplosion(col.contacts[0].point, new Vector2(1f, 2f), new Vector2(0.25f, 1.5f), 32, new Vector2(0.02f, 0.1f));


				Kill();

			}
		}

		// Token: 0x0400009A RID: 154

	}
}