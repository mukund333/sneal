using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SnealUltra.Assets._Project.Scripts.Enemy;

namespace SnealUltra.Assets._Project.Scripts.Player
{
	public class PlayerStats : MonoBehaviour
	{

		//public PlayerStruct curPlayer;
		//private PlayerController player;

		public PlayerData currentPlayer;
		private CurrentPlayerComponentData playerWeapon;
		public PlayerDatabase playerDatabase;

		public int baseHealth;
		public int curHealth;
	
		public event Action OnPlayerDeath;

		private static PlayerStats _instance;

		public static PlayerStats instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = FindObjectOfType<PlayerStats>();
				}
				return _instance;
			}
		}

		void Start()
		{
			playerWeapon = GetComponent<CurrentPlayerComponentData>();
			
			playerDatabase = FindObjectOfType<PlayerDatabase>();

			SetPlayer(0);
		}

		private void OnEnable()
		{
			curHealth = baseHealth;
		}

		public void Damage(int damage)
		{
			curHealth -= damage;
			//this.OnPlayerHit();
			//	base.StartCoroutine(base.SpriteFlash());
			//	CameraController.instance.initializeCameraShake(3f, 0.1f);
			//if (this.curHealth < this.baseHealth )
			//{
			//	base.StartCoroutine(this.Smoke());
			//}
			if (curHealth <= 0)
			{
				Kill();
			}
		}

		private void Kill()
		{
			Collider2D[] array = Physics2D.OverlapCircleAll(transform.position, 114f);

			if (array != null)
			{
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].CompareTag("Enemy"))
					{
						array[i].GetComponent<EnemyManager>().Damage(5);
					}
				}
			}

			OnPlayerDeath();
			gameObject.SetActive(false);
		}

		public void SetPlayer(int index)
		{
			//curPlayer = PlayerDatabase.instance.GetPlayer(index);
			//currentPlayer = PlayerDatabase.instance.GetPlayer(index);
			currentPlayer = playerDatabase.GetPlayer(index);
			baseHealth = currentPlayer.baseHealth;

			curHealth = baseHealth;
		}

		private void ResetPlayer()
		{
			SetPlayer(currentPlayer.index);			
		}

		public void Repair()
		{
			curHealth = baseHealth;
			Debug.Log("Repair");
		}

		public void Invincibility()
		{
			Debug.Log("Invincibility");
			//base.StartCoroutine(this._Invincibility());

		}

		public void Speed()
		{
			Debug.Log("speed");
			//base.StartCoroutine(this._Invincibility());

		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00007AEC File Offset: 0x00005CEC
		//private IEnumerator _Invincibility()
		//{
		//	Material mat = this.renderer.material;
		//	base.GetComponent<Collider2D>().enabled = false;
		//	for (int i = 0; i < 12; i++)
		//	{
		//		mat.color = new Color(1f, 1f, 1f, 0f);
		//		yield return new WaitForSeconds(0.12f);
		//		mat.color = new Color(1f, 1f, 1f, 1f);
		//		yield return new WaitForSeconds(0.12f);
		//	}
		//	base.GetComponent<Collider2D>().enabled = true;
		//	yield break;
		//}
	}
}