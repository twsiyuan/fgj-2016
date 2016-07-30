using UnityEngine;
using UnityEngine.UI;

using System.Collections;

[ExecuteInEditMode]
public class ColliderAutoSize : MonoBehaviour {
	#if UNITY_EDITOR
	void Update () {
		var rect = this.GetComponent<RectTransform> ();
		var collider = this.GetComponent<BoxCollider2D>();
		if (rect != null && collider != null){
			collider.size = rect.sizeDelta;
		}
	}
	#endif
}
