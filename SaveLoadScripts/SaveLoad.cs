using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveLoad
{
    public static List<GameData> savedGames = new List<GameData>(6);
	
	

	public static void Save()
	{
		if (!File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "savedGames.gd"))
		{
			Debug.Log("File doesnt exist");
			savedGames.Add(GameData.current);
		}
		else
		{
			savedGames[StartMenuController.currentsavefile] = GameData.current;	
		}

		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + Path.DirectorySeparatorChar + "savedGames.gd");
		bf.Serialize(file,savedGames);
		file.Close();
	}

	public static void Load()
	{
		if (File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "savedGames.gd"))
		{

			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + Path.DirectorySeparatorChar + "savedGames.gd", FileMode.Open);
			savedGames = (List<GameData>)bf.Deserialize(file);
			file.Close();
		}
	}
}
