using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour
{
	public Texture2D fadeOutTexture;
	public float fadeSpeed;

	private int drawDepth = -1000;
	private float alpha = 1;
	private int fadeDir = -1;
	private Color fadeColor;

	void OnGUI ()
	{
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01 (alpha);

		GUI.color = new Color (this.fadeColor.r, this.fadeColor.g, this.fadeColor.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture);
	}

	public float BeginFade (int direction, Color fadeColor)
	{
		this.fadeDir = direction;
		this.fadeColor = fadeColor;

		var tex = new Texture2D (1, 1);
		tex.SetPixel (0, 0, fadeColor);

		this.fadeOutTexture = tex;
		return fadeSpeed;
	}

	void OnLevelWasLoaded ()
	{
		alpha = 1;
		BeginFade (-1, Color.black);
	}
}
