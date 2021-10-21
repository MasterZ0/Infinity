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

        #region Public data
        public Sprite Background => Backgrounds[background];
        public List<PieceData> InitialPieces => initialPieces;
        public int[,] ItemsGrid => itemsGrid;

        public const int GridX = 8;
        public const int GridY = 16;
        #endregion

        #region Serialized data
        [Title("Stage Settings")]
        [DropdownData(nameof(Backgrounds))]
        [SerializeField] private int background;

        [TableList]
        [SerializeField] private List<PieceData> initialPieces;

        [InfoBox("About Color:\n\n<color=grey>Black:</color> Empty\n<color=yellow>Yellow:</color> Light\n<color=cyan>Cyan:</color> Power\n<color=orange>Orange:</color> Circle\n<color=magenta>Magenta</color> Square\n<color=lime>Green:</color> Horizontal Hexagon\n<color=#FF4040>Red:</color> Vertical Hexagon")]
        [TableMatrix(HorizontalTitle = "Stage slots", DrawElementMethod = "DrawColoredEnumElement", RowHeight = 32, RespectIndentLevel = true)]
        [SerializeField] private int[,] itemsGrid = new int[GridX, GridY];

        private static List<Background> Backgrounds => GameValuesSO.GameSettings.Backgrounds;
        #endregion

        #region Drawer methods
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
                3 => new Color(1f, 0.5f, 0f),
                4 => Color.magenta,
                5 => Color.green,
                6 => Color.red,
                _ => Color.white,
            };
        }
#endif
        #endregion
    }
}
