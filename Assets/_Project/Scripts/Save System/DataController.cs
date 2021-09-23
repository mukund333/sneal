	using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


public class DataController : MonoBehaviour
{
	
	
	
	private SceneChanger sceneChanger;
	public bool debug;
	
	
    void Start()
    {	
		sceneChanger = GetComponent<SceneChanger>();
        DontDestroyOnLoad(gameObject);
		sceneChanger.StartGame();
    }

}
