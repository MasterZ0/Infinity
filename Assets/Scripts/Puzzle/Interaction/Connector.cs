using Infinity.Audio;
using Infinity.Shared;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Infinity.Puzzle {

    /// <summary>
    /// Manage the connection lines and power distribution between them
    /// </summary>
    public class Connector : MonoBehaviour, IEnergyConnection {

        [Title("Connection")]
        [SerializeField] private List<Line> lines;
        [SerializeField] private Animator animator;

        private readonly List<Line> availableLines = new List<Line>();
        private bool isEnergized;
        private bool dropConnector;

        #region Initialization
        private void OnEnable() {
            PuzzleController.OnDesativePower += OnDesactivePower;
            PuzzleController.OnUpdateAnimations += OnUpdateAnimations;
        }

        private void OnDisable() {
            PuzzleController.OnDesativePower -= OnDesactivePower;
            PuzzleController.OnUpdateAnimations -= OnUpdateAnimations;
            availableLines.Clear();
        }

        /// <summary> Set available lines </summary>
        public void Init(LineDirection lineDirection) {

            foreach (Line line in lines) {

                bool hasFlag = lineDirection.HasFlag(line.LineDirection);
                line.gameObject.SetActive(hasFlag);
                if (hasFlag) {
                    availableLines.Add(line);
                    line.SetConnector(this);
                }
            }
        }
        #endregion

        #region Public methods
        public void Drag() {
            animator.SetBool(Animations.Highlighted, true);
            availableLines.ForEach(l => l.ActiveLine(false));
        }

        public void Moving() {
            animator.SetBool(Animations.Moving, true);
        }

        /// <summary>
        /// Set animations and active lines
        /// </summary>
        /// <param name="drop">Play sound effect</param>
        public void FitIn(bool drop) {
            availableLines.ForEach(l => l.ActiveLine(true));
            animator.SetBool(Animations.Highlighted, false);
            animator.SetBool(Animations.Moving, false);
            dropConnector = drop;
        }

        public void SendEnergy() {
            if (isEnergized) {
                return;
            }

            isEnergized = true;
            availableLines.ForEach(l => l.SendEnergy());
        }
        #endregion

        #region Events
        private void OnDesactivePower() {
            isEnergized = false;
            availableLines.ForEach(l => l.StopEnergy());
        }

        private void OnUpdateAnimations() {
            animator.SetBool(Animations.Energized, isEnergized);

            if (dropConnector) {
                dropConnector = false;
                SoundEffects.PlaySFX(isEnergized ? SFX.DropEnergy : SFX.DropWithoutEnergy);
            }
        }
        #endregion
    }
}