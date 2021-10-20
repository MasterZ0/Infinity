using Infinity.Shared;
using UnityEngine;

namespace Infinity.Interactable {
    public interface ISlot {

        public bool InitialSlot { get; }
        public Vector2 Position { get; }

        /// <returns>Successful</returns>
        public bool Drop(Vector2 itemPosition, PieceType pieceType);
        public void RemovePiece();
    }
}
