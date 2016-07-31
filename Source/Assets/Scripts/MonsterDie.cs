using UnityEngine;
using System.Collections;


public class MonsterDie : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D c){
		if (c.gameObject.layer == LayerMask.NameToLayer( "Player")) {
			LevelController.Singleton.DieAndRestartLevel ();
		}
	}
}
