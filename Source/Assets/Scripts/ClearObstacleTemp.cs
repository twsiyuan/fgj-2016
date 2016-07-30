using UnityEngine;
using System.Collections;

public class ClearObstacleTemp : ValueController {

	[SerializeField]
	Collider2D[] colliders = new Collider2D[0];

	[SerializeField]
	CharacterMovement character;

	float t = 0;
	public override float Value {
		get {
			return t;
		}
		set {
			t = value;

			var en = t >= 0.9f;

			foreach (var c in this.colliders) {
				if (c.enabled == en) {
					c.tag = "Untagged";
				} else {
					c.tag = "Obstacle";
				}
			}

			if (en) {
				character.ResetObstacles ();
			}
		}
	}
}
