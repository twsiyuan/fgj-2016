using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomEditor(typeof(LevelData))]
[CanEditMultipleObjects]
public class ShopMenuEditor : Editor
{
	ReorderableList list;

	void OnEnable()
	{
		var serProp = this.serializedObject.FindProperty("levelNames");
		this.list = new ReorderableList(serProp.serializedObject, serProp, true, true, true, true);
		this.list.drawElementCallback = this.DrawListElement;
		this.list.drawHeaderCallback = this.DrawListHeader;
	}

	void DrawListHeader(Rect rect)
	{
		var spacing = 10f;
		var arect = rect;
		arect.height = EditorGUIUtility.singleLineHeight;

		arect.x += 15;
		arect.width = 100;
		EditorGUI.LabelField(arect, "Name");
		arect.x += arect.width + spacing ;

	}

	void DrawListElement(Rect rect, int index, bool isActive, bool isFocused)
	{
		var spacing = 10f;
		var arect = rect;
		var serElem = this.list.serializedProperty.GetArrayElementAtIndex(index);
		arect.height = EditorGUIUtility.singleLineHeight;

		arect.width = 100;
		EditorGUI.PropertyField(arect, serElem, GUIContent.none);
		arect.x += arect.width + spacing;
	}

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		this.serializedObject.Update();

		var property = list.serializedProperty;
		property.isExpanded = EditorGUILayout.Foldout(property.isExpanded, property.displayName);
		if (property.isExpanded)
		{
			this.list.DoLayoutList();
		}

		this.serializedObject.ApplyModifiedProperties();
	}
}