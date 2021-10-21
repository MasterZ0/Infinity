using Infinity.Data;
using Infinity.Shared;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Infinity.Puzzle {

    /// <summary>
    /// Updates energy when the player makes a move
    /// </summary>
    public class PuzzleController : MonoBehaviour {

        [Title("PuzzleController")]
        [SerializeField] private GameEvent onPlayerMove;
        [SerializeField] private StageGenerator stageGenerator;

        private static List<Lamp> lamps;
        private static StageSO currentStage;
        private static Action onPlayerWin;

        public static event Action OnDesativePower = delegate { };
        public static event Action OnActivePower = delegate { };
        public static event Action OnUpdateAnimations = delegate { };

        #region Initialization
        private void Start() {
            onPlayerMove += OnPlayerMove;
            onPlayerWin = OnPlayerWin;

            if (!currentStage) {
                currentStage = GameValuesSO.GameSettings.TestStages;
            }

            GenerateStage();
        }

        private void OnDestroy() {
            onPlayerMove -= OnPlayerMove;
        }

        public static void SetLoadedStage(StageSO stage) {
            currentStage = stage;
        }
        #endregion

        #region Lamps
        public static void LampTurnOn(Lamp lamp) {
            lamps.Remove(lamp);

            if (lamps.Count == 0) {
                onPlayerWin();
            }
        }

        public static void LampTurnOff(Lamp lamp) {

            if (!lamps.Contains(lamp)) {
                lamps.Add(lamp);
            }
        }
        #endregion

        #region Events
        private void OnPlayerMove() {
            OnDesativePower();
            OnActivePower();
            OnUpdateAnimations();
        }

        private void OnPlayerWin() {

            // Call transition
            stageGenerator.ClearStage();
            SetNextStage();
            GenerateStage();
        }
        #endregion

        #region Private Methods
        private void SetNextStage() {
            List<StageSO> stages = GameValuesSO.GameSettings.Stages;
            int index = stages.IndexOf(currentStage) + 1;

            if (index == stages.Count) {
                index = 0;
            }

            currentStage = stages[index];
        }

        private void GenerateStage() {
            lamps = stageGenerator.GenerateStage(currentStage);
        }
        #endregion
    }
}