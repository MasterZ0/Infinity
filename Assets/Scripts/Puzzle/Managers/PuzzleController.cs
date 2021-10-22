using Infinity.Audio;
using Infinity.Data;
using Infinity.SaveSystem;
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
        [SerializeField] private Animator animator;

        private static List<Lamp> lamps;
        private static StageSO currentStage;
        private static Action<Vector2> onPlayerWin;

        public static event Action OnDesativePower = delegate { };
        public static event Action OnActivePower = delegate { };
        public static event Action OnUpdateAnimations = delegate { };

        private List<StageSO> Stages => GameValuesSO.GameSettings.Stages;

        private const string PlayerWin = "PlayerWin";

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
                onPlayerWin(lamp.transform.position);
                SoundEffects.PlaySFX(SFX.Win);
            }
            else {
                SoundEffects.PlaySFX(SFX.LightOn);
            }
        }

        public static void LampTurnOff(Lamp lamp) {
            lamps.Add(lamp);
            SoundEffects.PlaySFX(SFX.LightOff);
        }
        #endregion

        #region Events
        private void OnPlayerMove() {
            OnDesativePower();
            OnActivePower();
            OnUpdateAnimations();
        }

        private void OnPlayerWin(Vector2 position) {
            transform.position = position;
            animator.Play(PlayerWin);
        }

        public void OnTransitionEnd() {
            stageGenerator.ClearStage();
            SetNextStage();
            GenerateStage();
        }
        #endregion

        #region Private Methods
        private void SetNextStage() {
            int index = Stages.IndexOf(currentStage) + 1;

            if (index == Stages.Count) {
                index = 0;
            }
            else if (index > SaveManager.Data.completedLevels) {
                SaveManager.SaveGame(index);
            }

            currentStage = Stages[index];
        }

        private void GenerateStage() {
            lamps = stageGenerator.GenerateStage(currentStage);
        }
        #endregion
    }
}