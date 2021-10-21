using Infinity.Shared;
using UnityEngine;

namespace Infinity.Data {
    [System.Serializable]
    public class PieceData {
        public PieceType PieceType => pieceType;
        public LineDirection LineDirection => lineDirection;

        [SerializeField] private PieceType pieceType;
        [SerializeField] private LineDirection lineDirection;
    }
}
