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
		SaveFile(coinsData,"coins.moon");
	}
	
	public static int LoadCoins()
	{
		return LoadFile("coins.moon");
		
	}
	
	public static void SaveHighScore(int highScoreData)
	{
		SaveFile(highScoreData,"highScore.moon");
	}
	
	
	public static int LoadHighScore()
	{
		return LoadFile("highScore.moon");
	}
	
	
	public static void SavePlayerHealthUpgrade(int playerHealthUpgradeData)
	{
		SaveFile(playerHealthUpgradeData,"playerHealthUpgrade.moon");
	}
	
	public static int LoadPlayerHealthUpgrade()
	{
		return LoadFile("playerHealthUpgrade.moon");
	}
	
	
	
	private static void SaveFile(int intData,string fileName)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath+fileName;
		//string filePath = Path.Combine(Application.streamingAssets,gameDataFileName);
		FileStream stream = new FileStream(path,FileMode.Open);	
		formatter.Serialize(stream,intData);
		stream.Close();
	}
	
	public static int LoadFile(string fileName)
	{
		string path = Application.persistentDataPath+fileName;
		if(File.Exists(path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path,FileMode.Open);
				
			if(new FileInfo(path).Length == 0){
				stream.Close();
				return 1;
			}else{
				int intData = formatter.Deserialize(stream) as int? ?? throw new NullReferenceException();
				stream.Close();
				return intData;
			}
			
		}else{
			Debug.LogError("Save file not found in"+path);
			return 0;
		}
	}
	
	
}
