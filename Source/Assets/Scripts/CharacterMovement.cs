using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
	public float velocity;

	private Collider2D coll;
	private float x, y;

	void Awake ()
	{
		coll = GetComponent <BoxCollider2D> ();
		x = transform.localPosition.x;
		y = transform.localPosition.y;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		Debug.Log ("Triggered");
		velocity *= -1;
		//transform.localPosition = new Vector3 (x + velocity, y, 0);
	}

	void Update ()
	{
		x = transform.localPosition.x;
		/*if (coll.isTrigger)
		{
			x *= -1;
			Debug.Log ("Triggered");
		}*/
		transform.localPosition = new Vector3 (x + velocity, y, 0);
	}
}
