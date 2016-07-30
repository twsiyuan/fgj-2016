using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
	readonly Vector2 groundRay = new Vector2 (0, -1);
	const float groundDistance = 800;
	int layerMask = 0;

	[Header("Speed")]
	[SerializeField]
	float speed = 80;

	[SerializeField]
	bool run = false;


	void Awake ()
	{
		this.layerMask = LayerMask.GetMask ("Ground");
	}

	void Update ()
	{
		var trans = transform as RectTransform;

		// Move
		if (this.run) {
			var dx = this.speed * Time.deltaTime;
			var pos = trans.anchoredPosition;
			pos.x += dx;
			trans.anchoredPosition = pos;
		}

		// Set to ground
		{
			var pos = trans.anchoredPosition + new Vector2( 0, trans.rect.height);
			var dir = groundRay;

			var hitInfo = Physics2D.Raycast (pos, dir, groundDistance, this.layerMask);
			if (hitInfo.collider != null) {
				var cpos = pos + dir * hitInfo.distance;
				//var cpos = hitInfo.collider.bounds.ClosestPoint (new Vector3 (pos.x, pos.y, 0));
				trans.anchoredPosition3D = cpos;
			}
		}
	}
}
