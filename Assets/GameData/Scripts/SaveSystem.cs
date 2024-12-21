using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
	public static SaveSystem Instance { get; private set; }

	public enum GameMode
	{
		Normal,
		Endless
	}
	
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
	    
	    
	}

	public string ChooseSavePathByGameMode(GameMode mode)
	{
		switch (mode)
		{
			case GameMode.Normal:
				savePath = Application.persistentDataPath + "/NormalGameData.json";
				break;
			case GameMode.Endless:
				savePath = Application.persistentDataPath + "/EndlessGameData.json";
				break;
			default:
				Debug.LogError("GameMode not supported: " + mode);
				break;
		}

		return savePath;
	}

	public void SaveGameData(GameData newGameData, GameMode mode)
	{
		ChooseSavePathByGameMode(mode);
		
		string json = JsonUtility.ToJson(newGameData,true);
		File.WriteAllText(savePath, json);
	}

	public GameData LoadGameData(GameMode mode)
	{
		ChooseSavePathByGameMode(mode);
		
		if(File.Exists(savePath))
		{
			string json = File.ReadAllText(savePath);
			return JsonUtility.FromJson<GameData>(json);
		}
		
		return null;
	}
}
