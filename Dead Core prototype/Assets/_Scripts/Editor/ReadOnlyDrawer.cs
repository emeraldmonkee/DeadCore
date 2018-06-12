using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Grabbed from:: https://answers.unity.com/questions/489942/how-to-make-a-readonly-property-in-inspector.html
// https://answers.unity.com/questions/1118530/how-to-draw-the-default-script-label-in-a-customed.html

[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label)
    {
        string valueStr;

        switch (prop.propertyType)
        {
            case SerializedPropertyType.Integer:
                valueStr = prop.intValue.ToString();
                break;
            case SerializedPropertyType.Boolean:
                valueStr = prop.boolValue.ToString();
                break;
            case SerializedPropertyType.Float:
                valueStr = prop.floatValue.ToString("0.#####") + "f";
                break;
            case SerializedPropertyType.String:
                valueStr = prop.stringValue;
                break;
            case SerializedPropertyType.Enum:
                valueStr = prop.enumDisplayNames[prop.enumValueIndex].ToString();
                break;
            case SerializedPropertyType.ObjectReference:
                EditorGUI.BeginDisabledGroup(true);
                EditorGUI.ObjectField(position, prop);
                EditorGUI.EndDisabledGroup();
                return;

            default:
                valueStr = prop.propertyType.ToString() + " not supported!";
                break;
        }

        GUI.enabled = false;
        EditorGUI.LabelField(position, label.text, valueStr);
        GUI.enabled = true;

    }
}