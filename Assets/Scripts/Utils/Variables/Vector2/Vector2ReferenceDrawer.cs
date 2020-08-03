using UnityEditor;
using UnityEngine;

namespace Util.Variables
{
    [CustomPropertyDrawer(typeof(Vector2Reference))]
    public class Vector2ReferenceDrawer : PropertyDrawer
    {
        private const float PADDING = 5f;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            bool useConstant = property.FindPropertyRelative("useConstant").boolValue;

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            var dropdownRect = new Rect(position.position, new Vector2(16f, position.height));

            if (EditorGUI.DropdownButton(dropdownRect, new GUIContent(GetTexture()),
                FocusType.Keyboard, GUIStyle.none))
            {
                GenericMenu menu = new GenericMenu();
                menu.AddItem(new GUIContent("Constant"), useConstant, () => SetProperty(property, true));
                menu.AddItem(new GUIContent("Variable"), !useConstant, () => SetProperty(property, false));

                menu.ShowAsContext();
            }

            position.position += new Vector2(dropdownRect.width + PADDING, 0f);
            position.size -= new Vector2(dropdownRect.width + PADDING, 0f);

            if (useConstant)
            {
                EditorGUI.PropertyField(position, property.FindPropertyRelative("constantValue"), GUIContent.none);
            }
            else
            {
                EditorGUI.ObjectField(position, property.FindPropertyRelative("variableValue"), GUIContent.none);
            }

            EditorGUI.EndProperty();
        }

        private Texture GetTexture()
        {
            var texture = Resources.Load<Texture>("icn_dropdown_menu");

            return texture ? texture : null;
        }

        private void SetProperty(SerializedProperty property, bool value)
        {
            var propRelative = property.FindPropertyRelative("useConstant");
            propRelative.boolValue = value;
            property.serializedObject.ApplyModifiedProperties();
        }
    }
}