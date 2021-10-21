using Infinity.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Infinity.Puzzle {

    public class Interactable : MonoBehaviour {

        [Title("Interactable")]
        [SerializeField] protected PuzzleType puzzleType;
        public PuzzleType PuzzleType => puzzleType;
    }
}