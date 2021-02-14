using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SnealUltra.Assets._Project.Scripts.Player;

namespace SnealUltra.Assets._Project.Scripts.Enemy
{
    public class EnemyManager : MonoBehaviour
	{
		public int damage;


		public int baseHealth;


		public float pickupDropChance = 50f;


		public Vector2 debrisAmount;


		public Vector2 coinAmount;


		public LayerMask explosionMask;


		protected PlayerStats player;


		public int curHealth;


		protected Transform thisTrans;

		//protected GameMaster gm;


		private int coinID;


		private int debrisID;


		private WaitForEndOfFrame waitForFrame = new WaitForEndOfFrame();



		public virtual void Awake()
		{

			thisTrans = transform;
			
		}


		public virtual void Start()
		{
			curHealth = baseHealth;
			
			//this.gm = GameMaster.instance;
			thisTrans = transform;
			try
			{
				player = PlayerStats.instance;
			}
			catch
			{
			}
				this.coinID = PoolManager.instance.GetPoolID("Coin");
			//this.debrisID = PoolManager.instance.GetPoolID("Debris");
		}


		public void Damage(int dmg)
		{
			curHealth -= dmg;
			//StartCoroutine(this.HitImmobalize());
			if (curHealth <= 0)
			{
				Kill();
			}
			//else
			//{
			//	//base.startcoroutine(base.spriteflash());
			//}
		}


		public virtual void Kill()
		{
			//	if (!this.gm.IsGameOver())
			//	{
			//		this.gm.ScorePlus();
			//	}
				this.curHealth = this.baseHealth;
			//	if (UnityEngine.Random.Range(0f, 100f) < this.pickupDropChance)
			//	{
			//		PoolManager.instance.GetObject("Pickup", this.thisTrans.position, new Quaternion(0f, 0f, 0f, 0f));
			//	}
			//	ExplosionManager.instance.SpawnDynamicExplosion(this.thisTrans.position, new Vector2(1f, 2f), new Vector2(0.25f, 0.95f), 32, new Vector2(0.05f, 0.2f));
			//	CameraController.instance.initializeCameraShake(4f, 0.1f);
			//	SoundManager.instance.PlayClip("Explosion", this.thisTrans.position.x);
			//	this.DispenseDebris();
			//	this.DispenseGears();
	//DispenseCoins();
			gameObject.SetActive(false);
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00004F98 File Offset: 0x00003198
		public IEnumerator HitImmobalize()
		{
			float time = 0.1f;
			float timer = 0f;
			Vector3 pos = thisTrans.position;
			while (timer < time)
			{
				timer += Time.deltaTime;
				yield return waitForFrame;
				thisTrans.position = pos;
			}
			yield break;
		}


		//public void DispenseDebris()
		//{
		//	int num = (int)UnityEngine.Random.Range(this.debrisAmount.x, this.debrisAmount.y);
		//	int num2 = UnityEngine.Random.Range(0, 360);
		//	for (int i = 0; i < num; i++)
		//	{
		//		Quaternion rot = Quaternion.Euler(0f, 0f, (float)(num2 + 360 / num * i));
		//		Debris component = PoolManager.instance.GetObject(this.debrisID, this.thisTrans.position, rot).GetComponent<Debris>();
		//	}
		//}


		//public void DispenseGears()
		//{
		//	int num = (int)UnityEngine.Random.Range(this.gearAmount.x, this.gearAmount.y);
		//	for (int i = 0; i < num; i++)
		//	{
		//		PoolManager.instance.GetObject(this.gearID, base.transform.position, Quaternion.identity);
		//	}
		//}
		
		public void DispenseCoins()
		{
			//int num = (int)UnityEngine.Random.Range(this.coinAmount.x, this.coinAmount.y);
			int num =2;
			for (int i = 0; i < num; i++)
			{
				PoolManager.instance.GetObject(this.coinID, base.transform.position, Quaternion.identity);
			}
			
			
		}


		/*private void disable()
		{
			gameObject.SetActive(false);
		}*/


		public virtual void OnEnable()
		{
		}



	}
}