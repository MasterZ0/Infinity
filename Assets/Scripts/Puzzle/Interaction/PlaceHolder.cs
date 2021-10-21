using Infinity.Data;
using Infinity.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Infinity.Puzzle {

    /// <summary>
    /// Note to developers: Please describe what this MonoBehaviour does.
    /// </summary>
    public class PlaceHolder : Interactable, ISlot {

        #region Properties
        public Vector2 Position => transform.position;
        public float MinimumDropDistance => GameValuesSO.PuzzleSettings.MinimumDropDistance;
        #endregion

        private bool filled;

        private void OnDisable() {
            filled = false;
        }

        public bool Drop(Vector2 itemPosition, PieceType pieceType) {

            // Check type
            if (pieceType.ToString() != puzzleType.ToString() && puzzleType != PuzzleType.Empty) {
                return false;
            }

            // Is filled or is over the minimum distance
            if (filled || Vector2.Distance(Position, itemPosition) > MinimumDropDistance) {
                return false;
            }

            filled = true;
            return true;
        }

        public void RemovePiece() {
            filled = false;
        }
    }
}