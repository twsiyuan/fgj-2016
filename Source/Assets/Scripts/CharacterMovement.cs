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

	[Header("System")]
	[SerializeField]
	float physicalThreshold = 10f;

	[SerializeField]
	float physicalGravityScale = 10;

	[SerializeField]
	bool run = false;

	public bool PhysicalMode
	{
		get{ return this.physicalMode;}
		set{
			this.physicalMode = value;
			this.GetComponent<Rigidbody2D>().gravityScale = value ? this.physicalGravityScale : 0;
		}
	}

	bool physicalMode = true;

	void Awake ()
	{
		this.layerMask = LayerMask.GetMask ("Ground");
	}

	void Start()
	{
		var footPoint = Vector2.zero;
		var footDist = 0f;
		this.ComputeDistance (this.transform as RectTransform, out footPoint, out footDist );
		this.PhysicalMode = footDist >= this.physicalThreshold;
	}

	void Update ()
	{
		var trans = transform as RectTransform;

		// Move
		if (this.run && !this.PhysicalMode) {
			var dx = this.speed * Time.deltaTime;
			var pos = trans.anchoredPosition;
			pos.x += dx;
			trans.anchoredPosition = pos;
		}

		// Set to ground
		{
			var footPoint = Vector2.zero;
			var footDist = 0f;
			this.ComputeDistance (this.transform as RectTransform, out footPoint, out footDist );

			this.PhysicalMode = footDist >= this.physicalThreshold;
			if (!physicalMode) {
				trans.anchoredPosition = footPoint;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D c){
		Debug.LogFormat ("{0}", c == null ? "NONE" : c.tag);
		this.run = c == null || c.gameObject.tag != "Obstacle";
	}

	void ComputeDistance(RectTransform trans, out Vector2 footPoint, out float footDistance)
	{
		var height = trans.rect.height;
		var pos = trans.anchoredPosition + new Vector2( 0, height);
		var dir = groundRay;

		var hitInfo = Physics2D.Raycast (pos, dir, groundDistance, this.layerMask);
		var dist = hitInfo.collider == null ? 0 : hitInfo.distance;

		footPoint = pos + dir * dist;
		footDistance = hitInfo.collider == null ? float.PositiveInfinity : dist - height;
	}
}
