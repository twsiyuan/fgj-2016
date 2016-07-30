using UnityEngine;
using System.Collections;

public class ScaleController : ValueController {

	//public Vector3 startScale = new Vector3 (1, 1, 1);
	public Vector3 endScale = new Vector3(10, 10, 10);

	float t = 0;
	private Vector3 startScale;

	void Awake ()
	{
		startScale = transform.localScale;
	}

	public override float Value
	{
		get{ return this.t; }
		set{ 
			this.t = Mathf.Clamp01(value);
		
			this.transform.localScale = Vector3.Lerp (this.startScale, this.endScale, this.t);
		}
	}

	void Reset(){
		this.endScale = this.transform.localScale;
	}
		
}
