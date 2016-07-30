using UnityEngine;
using UnityEngine.UI;

using System.Collections;

[ExecuteInEditMode]
public class ColliderAutoSize : MonoBehaviour {

	RectTransform trans;
	BoxCollider2D boxc;
	Vector3[] corners = new Vector3[4];

	void Awake(){
		this.trans = this.GetComponent<RectTransform> ();
		this.boxc = this.GetComponent<BoxCollider2D>();;
	}

	void Update () {
		if (this.trans != null && this.boxc != null){
			
				trans.GetWorldCorners (corners);

			var width = Mathf.Abs(corners[2].x - corners [0].x);
			var height = Mathf.Abs (corners[1].y - corners[3].y);

			this.boxc.size = new Vector2 (width, height);


		}
	}
}
