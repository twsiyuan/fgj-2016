using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ObstacleMove : MonoBehaviour
{
	public Slider slider;
	public Sprite box, stair;
	void Update ()
	{
		if (slider.value >= 0.9)
		{
			GetComponent<EdgeCollider2D> ().enabled = true;
			GetComponent<EdgeCollider2D> ().offset = new Vector2 (-60, -180);
			GetComponent <BoxCollider2D> ().enabled = false;
			GetComponent<Image> ().sprite = stair;
		}
		else
		{
			GetComponent<EdgeCollider2D> ().enabled = false;
			GetComponent<BoxCollider2D> ().enabled = true;
			GetComponent<Image> ().sprite = box;
		}
	}
}