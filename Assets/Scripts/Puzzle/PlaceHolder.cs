using Infinity.Data;
using Infinity.Shared;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infinity.Interactable
{

    /// <summary>
    /// Note to developers: Please describe what this MonoBehaviour does.
    /// </summary>
    public class PlaceHolder : MonoBehaviour, ISlot {

        [Title("Piece")]
        [SerializeField] private bool initialSlot;
        [SerializeField] private PieceType slotPieceType;

        #region Properties
        public bool InitialSlot => initialSlot;
        public Vector2 Position => transform.position;
        public float MinimumDropDistance => GameValuesSO.GameSettings.MinimumDropDistance;
        #endregion

        private bool filled;
        public bool Drop(Vector2 itemPosition, PieceType pieceType) {

            // Check item
            if (pieceType != slotPieceType) {
                return false;
            }

            // Check distance
            if (Vector2.Distance(Position, itemPosition) > MinimumDropDistance) {
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