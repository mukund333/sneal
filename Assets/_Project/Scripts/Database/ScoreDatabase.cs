using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDatabase : MonoBehaviour
{
	[SerializeField] int _highscore=1;
	[SerializeField] int MaxHighScore = 100000000;
	
	public int HighScore{
		
		get{
			return _highscore;
		}
		
		set{
			
			_highscore = Mathf.Clamp(value, 1, MaxHighScore);
		}
	}
}
