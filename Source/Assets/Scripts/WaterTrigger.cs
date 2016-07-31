using UnityEngine;
using System.Collections;

public class WaterTrigger : MonoBehaviour
{

	void Update ()
	{
		//Debug.Log ("Scale: " + GetComponent<RectTransform> ().localScale.x);
		if (GetComponent <RectTransform> ().localScale.x <= 0.35)
			GetComponent<BoxCollider2D> ().enabled = false;
		else
		{
			GetComponent<BoxCollider2D> ().enabled = true;
		}
	}
}
