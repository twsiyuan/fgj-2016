using UnityEngine;
using System.Collections;

public class ZoomTransformInput : MonoBehaviour {

	public Transform target = null;

	public Vector3 startScale = new Vector3 (1, 1, 1);
	public Vector3 endScale = new Vector3(10, 10, 10);

	public float zoomSpeed = 1f;
	public ZoomMode zoomMode = ZoomMode.Default; 

	public float t = 0;

	void Reset()
	{
		this.target = this.transform;
	}

	void Update () {
		var d = Input.GetAxis("Mouse ScrollWheel");
		switch(this.zoomMode){
		case ZoomMode.OnlyZoomIn:
			d = Mathf.Max (d, 0);
			break;
		case ZoomMode.OnlyZoomOut:
			d = Mathf.Min (d, 0);
			break;
		}

		this.t = Mathf.Clamp01 (this.t + d * Time.deltaTime);

		target.localScale = Vector3.Lerp (this.startScale, this.endScale, this.t);
	}

	public enum ZoomMode{
		Default,
		OnlyZoomIn,
		OnlyZoomOut,
	}
}
