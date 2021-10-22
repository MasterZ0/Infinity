using Infinity.ApplicationManager;
using Infinity.Data;
using Infinity.Puzzle;
using Infinity.SaveSystem;
using Infinity.Shared;
using Infinity.System;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Infinity.MainMenu
{

    /// <summary>
    /// Generate the levels to display and load the next scene
    /// </summary>
    public class StageWindow : MonoBehaviour {

        [Title("StageWindow")]
        [SerializeField] private StageDisplay stageDisplay;

        private void Start() {
            GenerateButtonStage();
        }

        private void GenerateButtonStage() {
            List<StageSO> stages = GameValuesSO.GameSettings.Stages;

            PlayerData playerData = SaveManager.LoadGame();
            int completedLevel = 0;
            if (playerData != null) {
                completedLevel = playerData.completedLevels;
            }

            for (int i = 0; i < stages.Count; i++) {
                ObjectPool.SpawnPoolObject(stageDisplay, parent: transform).Init(stages[i], i <= completedLevel, LoadLevel);
            }
        }

        private void LoadLevel(StageSO stage) {
            PuzzleController.SetLoadedStage(stage);
            GameManager.LoadNewScene(GameScene.Gameplay);
        }
    }
}