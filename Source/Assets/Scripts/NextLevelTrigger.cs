using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NextLevelTrigger : MonoBehaviour
{
	public Sprite doorOpen;
	public float time = 2f;
	
	void OnTriggerEnter2D (Collider2D c)
	{
		if (c.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			c.GetComponent<CharacterMovement> ().enabled = false;
			StartCoroutine (NextLevelAnimation ());
		}
	}

	IEnumerator NextLevelAnimation ()
	{
	//	Debug.Log ("ANIM");
		GetComponent<Image> ().sprite = doorOpen;
		yield return new WaitForSeconds (time);
		LevelController.Singleton.NextLevel ();
	}
}
