using Infinity.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Infinity.Puzzle {

    /// <summary>
    /// Reference to the stage generator
    /// </summary>
    public class Interactable : MonoBehaviour {

        [Title("Interactable")]
        [SerializeField] protected PuzzleType puzzleType;
        public PuzzleType PuzzleType => puzzleType;
    }
}