using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBoot : MonoBehaviour
{
	private SceneChanger sceneChanger;

    void Start()
    {
			sceneChanger = GetComponent<SceneChanger>();
			BootGame.CheckFiles();
			if(BootGame.ALLOk==true)
			sceneChanger.DataControllerScene();
    }

 
}
