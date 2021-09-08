using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using SnealUltra.Assets._Project.Scripts.Player;

public class GameMaster : MonoBehaviour
{
    private static GameMaster _instance;
	
	private DataController dataController;

	public int coins;
	public int score;
	
	public Text scoreText;
	public Text coinText;
	
	CoinDatabase coinDB;
	//public event Action OnGameRestart;

	public event Action OnGameEnd;

	//public event Action OnReturnToMenu;
	[SerializeField]
	PlayerStats playerStats;

	public static GameMaster instance{
		get
		{
			if (GameMaster._instance == null)
			{
				GameMaster._instance = UnityEngine.Object.FindObjectOfType<GameMaster>();
			}
			return GameMaster._instance;
		}
	}

	private void Start(){
		coinDB = GetComponent<CoinDatabase>();
	//	LoadCoins();
		dataController = FindObjectOfType<DataController>();

		playerStats = FindObjectOfType<PlayerStats>();
		playerStats.OnPlayerDeath += EndGame;
		
	}

	public void EndGame(){

		SaveSystem.SaveCoins(coinDB.Coin);
		this.OnGameEnd();

	}

	public void CoinsPlus()
	{
		coinDB.Coin++;
		CoinDisplay(coinDB.Coin);
		//Debug.Log(""+coinDB.Coin);

	}
	
	private void CoinDisplay(int coins)
	{
		this.coinText.text = coins.ToString();
	}
	
	public void ScorePlus()
	{
		this.score++;
		this.scoreText.text = this.score.ToString();
	}
	
	private void LoadCoins()
	{
		coinDB.Coin = SaveSystem.LoadCoins();
		CoinDisplay(coinDB.Coin);

	}

	 
}
