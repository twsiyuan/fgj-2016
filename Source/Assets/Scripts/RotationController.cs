using UnityEngine;
using System.Collections;
using System;

public class RotationController : ValueController
{
	public float endRotate;

	private float t = 0, startRotate;

	void Awake ()
	{
		startRotate = transform.localRotation.eulerAngles.z;
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
			Quaternion start = Quaternion.Euler (new Vector3 (0, 0, startRotate));
			Quaternion end = Quaternion.Euler (new Vector3 (0, 0, endRotate));
			transform.localRotation = Quaternion.Lerp (start, end, t);
		}
	}

	void Reset ()
	{
		endRotate = transform.localRotation.eulerAngles.z;
	}
}
