using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
   private void CoinAcquired()
	{
		GameMaster.instance.ScorePlus();
		base.gameObject.SetActive(false);
	}
	
	private void OnCollisionEnter2D(Collision2D col){
			if (col.collider.CompareTag("Player"))
			{
				CoinAcquired();
			}
		}
}
