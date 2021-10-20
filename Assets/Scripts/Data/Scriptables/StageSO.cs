using Infinity.Shared;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using System.Collections.Generic;
using UnityEngine;

namespace Infinity.Data {

    /// <summary>
    /// Create a playable stage
    /// </summary>
    [CreateAssetMenu(fileName = "Stage", menuName = "Scriptable Objects/Stage")]
    public class StageSO : SerializedScriptableObject {

        public List<PieceType> InitialPieces => initialPieces;
        public int[,] ItemsGrid => itemsGrid;

        [Title("Stage Settings")]
        [SerializeField] private List<PieceType> initialPieces;

        [TableMatrix(HorizontalTitle = "Stage slots", DrawElementMethod = "DrawColoredEnumElement", RowHeight = 32, RespectIndentLevel = true)]
        [SerializeField] private int[,] itemsGrid = new int[GridX, GridY];

        public const int GridX = 8;
        public const int GridY = 16;

        #if UNITY_EDITOR
        private static int DrawColoredEnumElement(Rect rect, int value) {
            if (Event.current.type == EventType.MouseDown && rect.Contains(Event.current.mousePosition)) {
                value++;
                if (value > 6)
                    value = 0;
                GUI.changed = true;
                Event.current.Use();
            }

            UnityEditor.EditorGUI.DrawRect(rect.Padding(1), GetColor(value));

            return value;
        }

        private static Color GetColor(int value) {
            return value switch {
                0 => Color.black,
                1 => Color.yellow,
                2 => Color.cyan,
                3 => Color.green,
                4 => Color.magenta,
                5 => new Color(1f, 0.5f, 0f),
                6 => Color.red,
                _ => Color.white,
            };
        }
        #endif
    }
}
