using System;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(JustReadableAttribute))]
public class JustReadableDrawer : PropertyDrawer
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
                valueStr = prop.floatValue.ToString("0.00000");
                break;
            case SerializedPropertyType.String:
                valueStr = prop.stringValue;
                break;
            case SerializedPropertyType.Enum:
                valueStr = prop.enumNames[prop.enumValueIndex];
                break;
            case SerializedPropertyType.Vector3:
                valueStr = prop.vector3Value.ToString();
                break;
            case SerializedPropertyType.Vector2:
                valueStr = prop.vector2Value.ToString();
                break;
            case SerializedPropertyType.Quaternion:
                valueStr = prop.quaternionValue.ToString();
                break;
            case SerializedPropertyType.ObjectReference:
                try
                {
                    valueStr = prop.objectReferenceValue.ToString();
                }
                catch (NullReferenceException)
                {
                    valueStr = "None (Game Object)";
                }
                break;
            default:
                valueStr = "(not supported)";
                break;
        }

        EditorGUI.LabelField(position, label.text, valueStr);
    }
}