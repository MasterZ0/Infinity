using Sirenix.OdinInspector;
using UnityEngine;

namespace Infinity.Data
{

    /// <summary>
    /// Everything about the puzzle 
    /// </summary>
    [CreateAssetMenu(fileName = "PuzzleSettings", menuName = "Scriptable Objects/Data/Puzzle Settings")]
    public class PuzzleSettingsSO : ScriptableObject {

        public float MinimumDropDistance => minimumDropDistance;
        public float PieceReturningSpeed => pieceReturningSpeed;
        public Vector2 Start => start;
        public Vector2 Spacement => spacement;
        public float MaxX => maxX;

        [Title("Puzzle Settings")]
        [Range(0, 1)]
        [SerializeField] private float minimumDropDistance = .5f;
        [Range(0, 20)]
        [SerializeField] private float pieceReturningSpeed = 10f;

        [Title("Initial pieces spacing")]
        [SerializeField] private Vector2 start;
        [SerializeField] private Vector2 spacement;
        [SerializeField] private float maxX;
    }
}
