using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlatformAutoMove : ValueController
{
    private Rigidbody2D rigidbody2D;
    private BoxCollider2D boxCollider2D;

    public Vector2 force;

    public float sliderValue;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        rigidbody2D.isKinematic = true;
//        rigidbody2D.AddRelativeForce(force);
    }

    public override float Value
    {
        get
        {
//            Debug.Log(sliderValue);
            return sliderValue;
        }
        set
        {
            sliderValue = Mathf.Clamp01 (value);

//            Debug.Log(sliderValue);

            var adjustedSliderValue = sliderValue - 0.5f;

            var adjustedForce = force * adjustedSliderValue;

            if (Mathf.Abs(sliderValue - 0.5f) <= Mathf.Epsilon)
            {
                rigidbody2D.isKinematic = true;
            }
            else
            {
                rigidbody2D.isKinematic = false;
                rigidbody2D.AddRelativeForce(adjustedForce);
            }
        }
    }
}
