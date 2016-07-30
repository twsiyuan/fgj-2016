using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class InitVelocity : MonoBehaviour {

	public Vector2 velocity;

	// Use this for initialization
	void Start () {
		var rigi = this.GetComponent<Rigidbody2D> ();
		rigi.velocity = this.velocity;
	}
}
