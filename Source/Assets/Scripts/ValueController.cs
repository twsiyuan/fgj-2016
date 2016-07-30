using UnityEngine;
using System.Collections;

public abstract class ValueController : MonoBehaviour {

	public abstract float Value {
		get;
		set;
	}
}
