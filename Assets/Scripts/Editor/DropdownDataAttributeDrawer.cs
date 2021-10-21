using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using Sirenix.Utilities.Editor;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Infinity.Shared;

namespace Infinity.UnityEditor {

    public class DropdownDataAttributeDrawer : OdinAttributeDrawer<DropdownDataAttribute, int> {

        private int currentIndex;
        private string[] names;
        private string error;
        private Dictionary<string, int> values = new Dictionary<string, int>();

        protected override void Initialize() {

            ValueResolver<object> optionsValue = ValueResolver.Get<object>(Property, Attribute.Collection);
            error = optionsValue.ErrorMessage;

            if (!string.IsNullOrEmpty(error))
                return;

            object[] options = (optionsValue.GetValue() as IEnumerable).Cast<object>().ToArray();

            // Error 
            if (options == null) {
                error = "Please, use a collection";
                return;
            }

            if (options.Length == 0) {
                error = "The collection is empty";
            }

            // Get field names
            names = options.Select(n => n.ToString()).ToArray();

            // Validate
            if (ValueEntry.SmartValue >= options.Length) {
                ValueEntry.SmartValue = 0;
            }

            // Fill Dictionary and set current Index
            for (int i = 0; i < names.Length; i++) {
                values.Add(names[i], i);
            }

            if (Attribute.OrderByName) {
                string currentName = names[ValueEntry.SmartValue];
                names = names.OrderBy(n => n).ToArray();

                for (int i = 0; i < names.Length; i++) {
                    if (names[i] == currentName) {
                        currentIndex = i;
                        break;
                    }
                }
            }
            else {
                currentIndex = ValueEntry.SmartValue;
            }
        }

        protected override void DrawPropertyLayout(GUIContent label) {

            if (!string.IsNullOrEmpty(error)) {
                SirenixEditorGUI.ErrorMessageBox(error);
                CallNextDrawer(label);
                return;
            }

            EditorGUILayout.BeginHorizontal();

            int value = SirenixEditorFields.Dropdown(label, currentIndex, names);
            if (value != currentIndex) {
                currentIndex = value;
                string name = names[value];
                ValueEntry.SmartValue = values[name];
            }

            if (Attribute.ShowRefreshButton) {
                if (GUILayout.Button("↺", GUILayout.Width(30))) {
                    values.Clear();
                    Initialize();
                }
            }
            
            EditorGUILayout.EndHorizontal();
        }
    }
}