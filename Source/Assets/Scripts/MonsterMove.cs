using UnityEngine;
using System.Collections;


public class MonsterMove : MonoBehaviour {

	public float speed = 10.0f; //怪物移動速度
	public bool slip = true;
	public int initDir = 1;

	int dir = 1;

	void Awake(){
		dir = initDir;
	}
	void DoSlip(){
		var x = !this.slip ? 1 : this.dir > 0 ? 1 : -1;
		var s = this.transform.localScale;
		this.transform.localScale = new Vector3 (x, s.y, s.z);
	}

	void Start()
	{
		this.DoSlip ();
	}

	void Update(){
		var trans = this.transform;
		var pos = trans.position;

		pos.x += this.dir * this.speed * Time.deltaTime;
		trans.position = pos;

		this.DoSlip ();
	}

	void OnTriggerEnter2D (Collider2D c){
		if (c.gameObject.layer == LayerMask.NameToLayer( "Ground")) {
			this.dir *= -1;
		}
	}
}
