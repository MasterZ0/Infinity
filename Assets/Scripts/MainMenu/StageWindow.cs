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
            Debug.Log("null game values " + GameValuesSO.GameSettings == null);
            List<StageSO> stages = GameValuesSO.GameSettings.Stages;

            int completedLevel = SaveManager.Data.completedLevels;

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