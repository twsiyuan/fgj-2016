using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelController : MonoBehaviour {

	public AudioSource dieAudio;

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

	public CharacterMovement Player {
		get;
		set;
	}

	public bool HasNextLevel{
		get{ 
			return this.currentLevel + 1 < this.levelData.LevelCount;
		}
	}

	public void DieAndRestartLevel(){
		if (this.Player != null) {
			this.Player.enabled = false;
		}
		dieAudio.Play ();
		this.LoadCurrentLevel (Color.red, true);
	}

	public void Replay ()
	{
		this.currentLevel = 0;
		this.LoadCurrentLevel ();
	}

	public void ResetLevel ()
	{
		if (!this.HasNextLevel)
		{
			Replay ();
		}
		else
		{
			DieAndRestartLevel ();
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

	void LoadCurrentLevel(bool reload = false){
		this.LoadCurrentLevel (Color.black);
	}

	void LoadCurrentLevel(Color fadeColor, bool reload = false){

		var scene = this.levelData [this.currentLevel];

		#if UNITY_EDITOR
		if (!reload){
			for (var ii = 0; ii < SceneManager.sceneCount; ii++){
				var s = SceneManager.GetSceneAt(ii);
				if (s.isLoaded && s.name == scene){
					return;
				}
			}
		}
		#endif

		StartCoroutine (LoadCurrentLevelRoutine (scene, fadeColor));

	}

	IEnumerator LoadCurrentLevelRoutine (string scene, Color fadeColor)
	{
		SceneManager.LoadScene (scene);

		float fadeTime = GetComponent<Fade> ().BeginFade (1, fadeColor);
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
		} else if (Input.GetKeyDown (KeyCode.R)) {
			this.DieAndRestartLevel ();
		}
	}
}
