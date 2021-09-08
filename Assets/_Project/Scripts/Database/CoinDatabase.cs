using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDatabase : MonoBehaviour
{
	
	[SerializeField] int _coins = 1;
	[SerializeField] int MaxCoins = 100000000;
	
	public int Coin{
		
		get{
			return _coins;
		}
		
		set{
			
			_coins = Mathf.Clamp(value, 1, MaxCoins);
		}
	}
	
	
	
	
    
}
