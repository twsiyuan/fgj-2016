using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NextLevelTrigger : MonoBehaviour
{
	void Awake(){
		var img = this.GetComponent<Image> ();
		if (img != null) {
			img.enabled = false;
		}
	}
	
	void OnTriggerEnter2D (Collider2D c){
		if (c.gameObject.layer == LayerMask.NameToLayer("Player")) {
			LevelController.Singleton.NextLevel ();
		}
	}
}
