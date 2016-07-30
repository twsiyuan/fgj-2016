using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Levels" , menuName = "TeamA/Data Setting" , order = 1)]
public class LevelData : ScriptableObject 
{
	public string this[int index]{
		get{ 
			return this.levelNames [index];
		}
	}

	public int LevelCount{
		get{ 
			return this.levelNames.Length;
		}
	}

	public int GetLevelIndex(string name){
		return System.Array.IndexOf (this.levelNames, name);
	}

	[HideInInspector]
	[SerializeField]
	string[] levelNames = new string[0];
}
