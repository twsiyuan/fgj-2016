using UnityEngine;
using System.Collections;


public class Teleport : MonoBehaviour {

	public GameObject there; // 要移動到的目的地

	void OnTriggerEnter2D (Collider2D c){
		if (c.gameObject.layer == LayerMask.NameToLayer( "Player")) {
			c.transform.position = this.there.transform.position;
		}
	}
}
