using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Camera))]
public class SimpleCamera : MonoBehaviour {

	[SerializeField]
	Transform target;

	Camera cam;

	void Awake(){
		cam = this.GetComponent<Camera> ();
	}

	void Update () {
		var pos = cam.transform.position;
		pos.x = target.transform.position.x;
		cam.transform.position = pos;
	}
}
