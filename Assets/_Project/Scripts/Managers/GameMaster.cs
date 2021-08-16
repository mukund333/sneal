using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using SnealUltra.Assets._Project.Scripts.Player;

public class GameMaster : MonoBehaviour
{
    private static GameMaster _instance;
	
	public int coins;
	public int score;
	
	public Text scoreText;
	public Text coinText;

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
		playerStats = FindObjectOfType<PlayerStats>();
		playerStats.OnPlayerDeath += EndGame;
		
	}

	public void EndGame(){


		this.OnGameEnd();

	}

	public void CoinsPlus()
	{
		this.coins++;
		this.coinText.text = this.coins.ToString();
	}
	
	public void ScorePlus()
	{
		this.score++;
		this.scoreText.text = this.score.ToString();
	}

	 
}
