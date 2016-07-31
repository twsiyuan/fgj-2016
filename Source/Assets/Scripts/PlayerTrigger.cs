using UnityEngine;
using System.Collections;

public class PlayerTrigger : MonoBehaviour {

	public Behaviour[] targets = new Behaviour[0];
	public bool doEn = true;

	void OnTriggerEnter2D (Collider2D c){
		if (c.gameObject.layer == LayerMask.NameToLayer( "Player")) {
			foreach (var bev in targets) {
				bev.enabled = doEn;
			}
		}
	}
}
