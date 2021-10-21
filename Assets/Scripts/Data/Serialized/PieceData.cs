using Infinity.Shared;
using UnityEngine;

namespace Infinity.Data {

    /// <summary>
    /// Store the piece settings
    /// </summary>
    [System.Serializable]
    public class PieceData {
        public PieceType PieceType => pieceType;
        public LineDirection LineDirection => lineDirection;

        [SerializeField] public PieceType pieceType;
        [SerializeField] private LineDirection lineDirection;
    }
}
