using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Infinity.Data {

    public enum EnvironmentState {
        Develop,
        Release,
        Staging
    }

    /// <summary>
    /// Storage all data and variables
    /// </summary>
    [CreateAssetMenu(fileName = "GameValues", menuName = "Scriptable Objects/Data/Game Values")]
    public class GameValuesSO : SerializedScriptableObject {

        [SerializeField] private EnvironmentState environment = EnvironmentState.Develop;
        [DictionaryDrawerSettings(DisplayMode = DictionaryDisplayOptions.OneLine)]
        [SerializeField] private Dictionary<EnvironmentState, EnvironmentSettingsSO> datas = new Dictionary<EnvironmentState, EnvironmentSettingsSO>();

        public static event Action OnChangeEnvironment = delegate { };
        public static EnvironmentSettingsSO EnvironmentSettings => Datas[Environment];
        public static GameSettingsSO GameSettings => Datas[Environment].GameSettings;
        public static PuzzleSettingsSO PuzzleSettings => Datas[Environment].PuzzleSettings;
        public static EnvironmentState Environment { get; private set; }
        public static Dictionary<EnvironmentState, EnvironmentSettingsSO> Datas { get; private set; }
        
        public void OnValidate() => Initialize();
        
        public void Initialize() {
            Environment = environment;
            Datas = datas;
            OnChangeEnvironment();
        }
    }
}
