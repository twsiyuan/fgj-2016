using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomEditor(typeof(ValueController), true)]
[CanEditMultipleObjects]
public class ValueControllerEditor : Editor
{
	float t = 0f;


	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI ();
		RenderDebug ();
	}

	protected virtual void RenderDebug(){
		EditorGUILayout.Space ();

		EditorGUILayout.LabelField ("Debug", EditorStyles.boldLabel);
		EditorGUI.BeginChangeCheck ();
		t = EditorGUILayout.Slider ("Value", t, 0, 1);
		if (EditorGUI.EndChangeCheck ()) {
			foreach (ValueController v in this.targets) {
				v.Value = t;
			}
		}
	}

	/*protected virtual void OnDestroy(){
		if (!EditorApplication.isPlaying && !EditorApplication.isPlayingOrWillChangePlaymode && !EditorApplication.isCompiling)
		{
			foreach (ValueController v in this.targets) {
				v.Value = 0;
			}
		}
	}*/
}