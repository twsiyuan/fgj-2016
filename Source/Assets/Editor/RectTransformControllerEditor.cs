using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomEditor(typeof(RectTransformController), true)]
[CanEditMultipleObjects]
public class RectTransformControllerEditor : ValueControllerEditor
{
	float t = 0f;

	public SerializedProperty startPos;
	public SerializedProperty startSize;

	public SerializedProperty endPos;
	public SerializedProperty endSize;

	void Awake(){
		startPos = serializedObject.FindProperty ("startPos");
		startSize = serializedObject.FindProperty ("startSize");
		endPos = serializedObject.FindProperty ("endPos");
		endSize = serializedObject.FindProperty ("endSize");
	}

	public override void OnInspectorGUI ()
	{
		this.DrawDefaultInspector ();

		serializedObject.Update ();
		EditorGUILayout.BeginHorizontal ();
		if (GUILayout.Button ("Save Start")) {
			startPos.vector2Value = ((target as RectTransformController).transform as RectTransform).anchoredPosition;
			startSize.vector2Value = ((target as RectTransformController).transform as RectTransform).sizeDelta;
		}

	//	EditorGUILayout.EndHorizontal ();
	//	EditorGUILayout.BeginHorizontal ();
		if (GUILayout.Button ("Save End")) {
			endPos.vector2Value = ((target as RectTransformController).transform as RectTransform).anchoredPosition;
			endSize.vector2Value = ((target as RectTransformController).transform as RectTransform).sizeDelta;
		}

		EditorGUILayout.EndHorizontal ();
		serializedObject.ApplyModifiedProperties ();

		this.RenderDebug ();
	}

}