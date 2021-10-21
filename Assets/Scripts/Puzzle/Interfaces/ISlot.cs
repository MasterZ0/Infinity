using Infinity.Shared;
using UnityEngine;

namespace Infinity.Puzzle {
    public interface ISlot {

        public Vector2 Position { get; }

        /// <returns>Successful</returns>
        public bool Drop(Vector2 itemPosition, PieceType pieceType);
        public void RemovePiece();
    }
}
