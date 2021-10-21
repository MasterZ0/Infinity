using Infinity.ApplicationManager;
using Infinity.Data;
using Infinity.Shared;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infinity.Gameplay
{

    /// <summary>
    /// Note to developers: Please describe what this MonoBehaviour does.
    /// </summary>
    public class GameController : MonoBehaviour {
        [Title("GameController")]
        [SerializeField] private Camera mainCamera;
        [SerializeField] private StageGenerator stageGenerator;

        public static Camera MainCamera { get; private set; }

        private static StageSO currentStage;
        private void Start() {
            MainCamera = mainCamera;

            if (!currentStage) {
                currentStage = GameValuesSO.GameSettings.Stages[0];
            }
            stageGenerator.GenerateStage(currentStage);
        }

        public static void SetLoadedStage(StageSO stage) {
            currentStage = stage;
        }

        public void OnReturnToMainMenu() {
            GameManager.LoadNewScene(GameScene.MainMenu);
        }
    }
}