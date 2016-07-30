using UnityEngine;
using System.Collections;

public class PositionController : ValueController
{
	public Vector3 endPos;

	private float t = 0;
	private Vector3 startPos;

	void Awake ()
	{
		startPos = transform.localPosition;
	}

	public override float Value
	{
		get
		{
			return t;
		}

		set
		{
			t = Mathf.Clamp01 (value);
			transform.localPosition = Vector3.Lerp (startPos, endPos, t);
		}
	}

	void Reset ()
	{
		endPos = transform.localPosition;
	}
}
