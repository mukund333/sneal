using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
	
	
	
	private SceneChanger sceneChanger;
	
    void Start()
    {	Debug.Log("Coins :"+SaveSystem.LoadCoins());
		Debug.Log("HighScore :"+SaveSystem.LoadHighScore());

        DontDestroyOnLoad(gameObject);
		sceneChanger = GetComponent<SceneChanger>();
		sceneChanger.StartGame();


    }
	
	void Update()
	{

	}

    public int IntializeCoins()
    {
        return SaveSystem.LoadCoins();
    }
}
