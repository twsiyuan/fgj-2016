using UnityEngine;
using UnityEngine.UI;

using System.Collections;

[ExecuteInEditMode]
public class ColliderAutoSize : MonoBehaviour {

	RectTransform trans;
	BoxCollider2D collider;

	void Awake(){
		this.trans = this.GetComponent<RectTransform> ();
		this.collider = this.GetComponent<BoxCollider2D>();;
	}

	void Update () {
		if (this.trans != null && this.collider != null){
			this.collider.size = trans.sizeDelta;
		}
	}
}
