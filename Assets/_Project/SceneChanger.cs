using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneChanger : MonoBehaviour
{
     public void StartGame() {  
        SceneManager.LoadScene("StartGameScene");  
    }  
	 public void Play() {  
        SceneManager.LoadScene("PlayableScene");  
    } 
	 public void EndGame() {  
        SceneManager.LoadScene("EndGameScene");  
    } 
}
