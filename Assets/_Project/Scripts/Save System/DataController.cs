using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
	
	
	
	private SceneChanger sceneChanger;
	
    void Start()
    {	Debug.Log(""+SaveSystem.LoadCoins());

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
