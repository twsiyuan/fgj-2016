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

	public bool HasNextLevel{
		get{ 
			return this.currentLevel + 1 < this.levelData.LevelCount;
		}
	}

	public void NextLevel(){
		if (!this.HasNextLevel) {
			Debug.LogError ("No Levels, 賣鬧喔");
		} else {
			this.currentLevel += 1;
			this.LoadCurrentLevel ();
		}
	}

	void StartLevel(){
		this.currentLevel = this.startLevel;
		this.LoadCurrentLevel ();
	}

	void LoadCurrentLevel(){

		var scene = this.levelData [this.currentLevel];
		#if UNITY_EDITOR
		for (var ii = 0; ii < SceneManager.sceneCount; ii++){
			var s = SceneManager.GetSceneAt(ii);
			if (s.isLoaded && s.name == scene){
				return;
			}
		}

		#endif

		StartCoroutine (LoadCurrentLevelRoutine ());
		SceneManager.LoadScene (scene);
	}

	IEnumerator LoadCurrentLevelRoutine ()
	{
		float fadeTime = GetComponent<Fade> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
	}

	void Awake(){
		GameObject.DontDestroyOnLoad (this.gameObject);
		singleton = this; 
	}

	void Start(){
		this.StartLevel ();
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.L)) {
			this.NextLevel ();
		}
	}
}
