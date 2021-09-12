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

	[SerializeField] private int score;
	[SerializeField] private int highscore;
	[SerializeField] private Text scoreText;

	
	public int coins;
	
	
	public Text coinText;
	
	ScoreDatabase scoreDB;
	
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
		scoreDB = GetComponent<ScoreDatabase>();
		LoadCoins();
		LoadHighScore();
		
		dataController = FindObjectOfType<DataController>();
		highscore = scoreDB.HighScore;
		playerStats = FindObjectOfType<PlayerStats>();
		playerStats.OnPlayerDeath += EndGame;
		
	}

	public void EndGame(){

		SaveSystem.SaveCoins(coinDB.Coin);
		
		if(score>highscore)
		{
			SaveSystem.SaveHighScore(score);
		}
		
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
	
	
	
	private void LoadCoins()
	{
		coinDB.Coin = SaveSystem.LoadCoins();
		CoinDisplay(coinDB.Coin);

	}
	
	public void ScorePlus()
	{
		this.score++;
		this.scoreText.text = this.score.ToString();
	}
	
	private void LoadHighScore()
	{
		scoreDB.HighScore = SaveSystem.LoadHighScore();
	}
	

	 
}
