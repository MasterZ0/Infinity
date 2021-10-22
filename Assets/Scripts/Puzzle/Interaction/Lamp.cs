using Infinity.Shared;
using UnityEngine;

namespace Infinity.Puzzle {

    /// <summary>
    /// Game objective
    /// </summary>
    public class Lamp : Interactable, IPowerConnection {

        [SerializeField] private Animator animator;

        private bool isEnergized;
        private bool wasEnergized;

        private void OnEnable() {
            PuzzleController.OnDesativePower += OnDesactivePower;
            PuzzleController.OnUpdateAnimations += OnUpdateAnimations;
        }

        private void OnDisable() {
            PuzzleController.OnDesativePower -= OnDesactivePower;
            PuzzleController.OnUpdateAnimations -= OnUpdateAnimations;
            wasEnergized = false;
            isEnergized = false;
        }
        public void OnDesactivePower() {
            wasEnergized = isEnergized;
            isEnergized = false;
        }

        public void SendPower() {
            isEnergized = true;
        }

        public void OnUpdateAnimations() {
            if (isEnergized != wasEnergized) {

                animator.SetBool(Animations.Energized, isEnergized);

                if (isEnergized) {
                    PuzzleController.LampTurnOn(this);
                }
                else {
                    PuzzleController.LampTurnOff(this);
                }
            }            
        }
    }
}