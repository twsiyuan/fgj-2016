using UnityEngine;
using System.Collections;

public class EnabledController : ValueController
{
	public Behaviour[] targets = new Behaviour[0];

	public float valueThreshold = .9f;
	public bool doEnabled = false;


	private float t = 0;

	void Awake ()
	{
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
			var en = false;
			if (t >= this.valueThreshold) {
				en = this.doEnabled;
			} else {
				en = !this.doEnabled;
			}

			foreach (var target in this.targets) {
				target.enabled = en;
			}
		}
	}

	void Reset ()
	{
	}
}
