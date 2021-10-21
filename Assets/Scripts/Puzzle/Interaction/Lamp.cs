using Infinity.Shared;
using UnityEngine;

namespace Infinity.Puzzle {

    public class Lamp : Interactable, IEnergyConnection {

        [SerializeField] private Animator animator;

        private bool isEnergized;

        private void OnEnable() {
            PuzzleController.OnDesativePower += OnDesactivePower;
            PuzzleController.OnUpdateAnimations += OnUpdateAnimations;
        }

        private void OnDisable() {
            PuzzleController.OnDesativePower -= OnDesactivePower;
            PuzzleController.OnUpdateAnimations -= OnUpdateAnimations;
        }
        public void OnDesactivePower() {
            isEnergized = false;
        }

        public void SendEnergy() {
            isEnergized = true;
        }

        public void OnUpdateAnimations() {
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