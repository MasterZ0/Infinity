using Infinity.ApplicationManager;
using Infinity.Data;
using Infinity.Puzzle;
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
            GenerateStage();
        }

        private void GenerateStage() {
            List<StageSO> stages = GameValuesSO.GameSettings.Stages;
            foreach (StageSO stage in stages) {
                ObjectPool.SpawnPoolObject(stageDisplay, parent: transform).Init(stage, false, LoadLevel);
            }
        }

        private void LoadLevel(StageSO stage) {
            PuzzleController.SetLoadedStage(stage);
            GameManager.LoadNewScene(GameScene.Gameplay);
        }
    }
}