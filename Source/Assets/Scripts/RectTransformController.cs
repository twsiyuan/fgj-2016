using UnityEngine;
using System.Collections;

public class RectTransformController : ValueController
{
	public Vector2 startPos;
	public Vector2 startSize;

	public Vector2 endPos;
	public Vector2 endSize;

	private float t = 0;

	private RectTransform trans{
		get{ return this.transform as RectTransform;}
	}

	void Awake ()
	{
		startPos = this.trans.anchoredPosition;
		startSize = this.trans.sizeDelta;
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

			this.trans.anchoredPosition = Vector2.Lerp(startPos, endPos, t);
			this.trans.sizeDelta = Vector2.Lerp(startSize, endSize, t);
		}
	}

	void Reset ()
	{
		endPos = this.trans.anchoredPosition;
		endSize = this.trans.sizeDelta;
	}
}
