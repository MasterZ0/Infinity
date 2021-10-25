using Infinity.Shared;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Infinity.Data {

    /// <summary>
    /// Store all available stage
    /// </summary>
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Scriptable Objects/Data/Game Settings")]
    public class GameSettingsSO : ScriptableObject {

        public StageSO TestStages => stages[testStage];
        public List<StageSO> Stages => stages;
        public List<Background> Backgrounds => backgrounds;

        [Title("Game Settings")]

        [DropdownData(nameof(stages))]
        [SerializeField] private int testStage;
        [ListDrawerSettings(ShowIndexLabels = true)]
        [SerializeField] private List<StageSO> stages;
        [SerializeField] private List<Background> backgrounds;

        [OnInspectorInit]
        private void OnValidate() {
            List<StageSO> copyStages = stages;
            for (int i = 0; i < copyStages.Count; i++) {
                if (copyStages[i] == null) {
                    stages.RemoveAt(i);
                    OnValidate();
                    return;
                }
            }
        }
    }
}
