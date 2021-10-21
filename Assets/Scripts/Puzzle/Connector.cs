using Infinity.Shared;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Infinity.Puzzle {

    /// <summary>
    /// Note to developers: Please describe what this MonoBehaviour does.
    /// </summary>
    public class Connector : MonoBehaviour {

        [Title("Connection")]
        [SerializeField] private List<Line> lines;
        [SerializeField] private Animator animator;

        private readonly List<Line> availableLines = new List<Line>();
        private bool isEnergized;

        private void OnEnable() {
            PuzzleController.OnDesativePower += OnDesactivePower;
            PuzzleController.OnUpdateAnimations += OnUpdateAnimations;
        }

        private void OnDisable() {
            PuzzleController.OnDesativePower -= OnDesactivePower;
            PuzzleController.OnUpdateAnimations -= OnUpdateAnimations;
        }

        public void Init(LineDirection lineDirection) {

            foreach (Line line in lines) {

                if (lineDirection.HasFlag(line.LineDirection)) {
                    availableLines.Add(line);
                    line.SetConnector(this);
                }
                else {
                    line.gameObject.SetActive(false);
                }
            }
        }

        public void Drag() {
            animator.SetBool(Animations.Highlighted, true);
        }

        public void OnDesactivePower() {
            isEnergized = false;
            availableLines.ForEach(l => l.StopEnergy());
        }

        public void SendEnergy() {
            if (isEnergized) {
                return;
            }

            isEnergized = true;
            availableLines.ForEach(l => l.SendEnergy());
        }

        public void FitIn() {
            animator.SetBool(Animations.Highlighted, false);
            animator.SetBool(Animations.Moving, false);
        }

        internal void Moving() {
            animator.SetBool(Animations.Moving, true);
        }

        public void OnUpdateAnimations() {
            animator.SetBool(Animations.Energized, isEnergized);
        }
    }
}