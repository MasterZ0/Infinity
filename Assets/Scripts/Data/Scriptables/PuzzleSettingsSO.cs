using Sirenix.OdinInspector;
using UnityEngine;

namespace Infinity.Data
{

    /// <summary>
    /// Note to developers: Please describe what this class does.
    /// </summary>
    [CreateAssetMenu(fileName = "PuzzleSettings", menuName = "Scriptable Objects/Data/Puzzle Settings")]
    public class PuzzleSettingsSO : ScriptableObject {

        public float MinimumDropDistance => minimumDropDistance;
        public float PieceReturningSpeed => pieceReturningSpeed;

        [Title("Puzzle Settings")]
        [Range(0, 1)]
        [SerializeField] private float minimumDropDistance = .5f;
        [Range(0, 20)]
        [SerializeField] private float pieceReturningSpeed = 10f;
    }
}
