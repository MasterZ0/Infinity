using Infinity.Data;
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

        private StageSO currentStage;
        private void Awake() {
            MainCamera = mainCamera;
            stageGenerator.GenerateStage(GameValuesSO.GameSettings.Stages[0]);
        }
    }
}