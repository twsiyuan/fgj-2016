using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderReset : MonoBehaviour
{
	public Slider slider;
	private Vector3 pos;
	private RectTransform trans;
	private bool start, end;

	void Awake ()
	{
		trans = slider.GetComponent<RectTransform> ();
		pos = trans.localPosition;
		start = end = false;
	}

	void OnTriggerEnter2D (Collider2D coll)
	{
		//Debug.Log ("coll");
		if (coll.name == "BoxStart" || coll.name == "WaterStart")
		{
			start = true;
			Debug.Log (start);
			slider.value = 0f;
			trans.localPosition = pos;
			//Debug.Log ("slider: " + slider.value);
		}
		if (coll.name == "BoxEnd" || coll.name == "WaterEnd")
		{
			start = false;
			slider.value = 0f;
			trans.localPosition = pos;
			//Debug.Log ("slider: " + slider.value);
		}
	}

	void Update ()
	{
		if (!start)
		{
			slider.interactable = false;
		}
		else
		{
			slider.interactable = true;
		}
	}
}
