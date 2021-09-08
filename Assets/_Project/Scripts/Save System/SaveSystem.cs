using UnityEngine;
using System.IO;
using System;
using UnityEngine.SceneManagement; 

using System.Runtime.Serialization.Formatters.Binary;



public static class SaveSystem 
{
	//private static string  gameDataFileName = "coins.moon";
	
    public static void SaveCoins(int coinsData)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath+"coins.moon";
		//string filePath = Path.Combine(Application.streamingAssets,gameDataFileName);
		FileStream stream = new FileStream(path,FileMode.Create);
			
		int coins = coinsData;
		
		formatter.Serialize(stream,coins);
		stream.Close();
	}
	
	public static int LoadCoins()
	{
		string path = Application.persistentDataPath+"coins.moon";
		
		if(File.Exists(path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path,FileMode.Open);
			
			int coins = formatter.Deserialize(stream) as int? ?? throw new NullReferenceException();
			stream.Close();
			 return coins;
			
		}else{
			Debug.LogError("Save file not found in"+path);
			return 0;
		}
	}
}
