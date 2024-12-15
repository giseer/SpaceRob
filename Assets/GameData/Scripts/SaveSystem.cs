using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
	public static SaveSystem Instance { get; private set; }

	private string savePath;

	private void Awake() 
	{     
    	if (Instance != null && Instance != this) 
    	{ 
    	    Destroy(this); 
    	} 
    	else 
    	{ 
	        Instance = this; 
    	}
	    
		savePath = Application.persistentDataPath + "/gameData.json";
	}

	public void SaveGameData(GameData newGameData)
	{
		string json = JsonUtility.ToJson(newGameData,true);
		File.WriteAllText(savePath, json);
	}

	public GameData LoadGameData()
	{
		if(File.Exists(savePath))
		{
			string json = File.ReadAllText(savePath);
			return JsonUtility.FromJson<GameData>(json);
		}
		
		return null;
	}
}
