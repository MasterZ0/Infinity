using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Infinity.Data {

    /// <summary>
    /// Note to developers: Please describe what this class does.
    /// </summary>
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Scriptable Objects/Data/Game Settings")]
    public class GameSettingsSO : ScriptableObject {

        public List<StageSO> Stages => stages;
        public List<Background> Backgrounds => backgrounds;

        [Title("GameSettings")]
        [ListDrawerSettings(ShowIndexLabels = true)]
        [SerializeField] private List<StageSO> stages;
        [SerializeField] private List<Background> backgrounds;
    }
}
