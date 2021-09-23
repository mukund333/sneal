using UnityEngine;
using System.IO;
using System;

public static class BootGame
{
	private static string[] fileNameList = new string[]{"abc.moon","kdc.moon","coins.moon","playerHealthUpgrade.moon","highScore.moon"};
	
	public static bool ALLOk = false;
	
		
	public static void CheckFiles()
	{
		int allfilesCount = 0; 
		
		for(int i=0;i<fileNameList.Length;i++){
		
			string path = Application.persistentDataPath+fileNameList[i];
		
			if(File.Exists(path))
			{
				Debug.Log("file found "+fileNameList[i]);
				allfilesCount++;
			
			}else{
				Debug.Log("file doesn't exist " + fileNameList[i]);
				CreateFile(fileNameList[i]);
				break;	
			}
		}
		
		if(allfilesCount==fileNameList.Length){
				Debug.Log("all files exsist ..... Load Next scene");
				ALLOk=true;
				
		}
	}
	
	private static void CreateFile(string fileName)
	{
		string path = Application.persistentDataPath+fileName; 	
		FileStream stream = new FileStream(path,FileMode.Create);
		stream.Close();
		CheckFiles();
	}
	
	
	
}
