using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelController : MonoBehaviour {

	static LevelController singleton = null;

	[SerializeField]
	LevelData levelData = null;

	[SerializeField]
	int startLevel = 0;

	int currentLevel;

	public static LevelController Singleton{
		get{ 
			return singleton;
		}
	}

	public void NextLevel(){
		this.currentLevel += 1;
		this.LoadCurrentLevel ();
	}

	void StartLevel(){
		this.currentLevel = this.startLevel;
		this.LoadCurrentLevel ();
	}

	void LoadCurrentLevel(){
		SceneManager.LoadScene (this.levelData[this.currentLevel]);
	}

	void Awake(){
		GameObject.DontDestroyOnLoad (this.gameObject);
		singleton = this; 
	}

	void Start(){
		this.StartLevel ();
	}
}
