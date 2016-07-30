using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Levels" , menuName = "TeamA/Data Setting" , order = 1)]
public class LevelData : ScriptableObject 
{
	public string[] LevelNames{
		get{ return this.levelNames; }
	}

	public string GetNextLevel(string name){
		var index = this.GetLevelIndex (name);
		return this.GetNextLevel (index);
	}

	public string GetNextLevel(int index){
		if (index + 1 >= this.levelNames.Length || index + 1 < 0) {
			return null;
		}
		return this.levelNames[index + 1];
	}

	public int GetLevelIndex(string name){
		return System.Array.IndexOf (this.levelNames, name);
	}

	[HideInInspector]
	[SerializeField]
	string[] levelNames = new string[0];
}
