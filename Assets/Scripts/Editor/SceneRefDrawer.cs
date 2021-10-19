using UnityEngine;
using UnityEditor;
using Infinity.Shared;

namespace Infinity.Editor {

    [CustomPropertyDrawer(typeof(SceneRef))]
    public class SceneRefDrawer : PropertyDrawer {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            SceneAsset oldScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(property.stringValue);

            EditorGUI.BeginChangeCheck();
            string name = ObjectNames.NicifyVariableName(property.name);
            SceneAsset newScene = EditorGUILayout.ObjectField(name, oldScene, typeof(SceneAsset), false) as SceneAsset;

            if (EditorGUI.EndChangeCheck()) {
                string newPath = AssetDatabase.GetAssetPath(newScene);
                property.stringValue = newPath;
            }
        }
    }
}
