using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Infinity.Data
{

    /// <summary>
    /// Note to developers: Please describe what this class does.
    /// </summary>
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Scriptable Objects/Data/Game Settings")]
    public class GameSettingsSO : ScriptableObject {

        public float MinimumDropDistance => minimumDropDistance;
        public float PieceReturningSpeed => pieceReturningSpeed;

        public List<StageSO> Stages => stages;

        [Title("GameSettings")]
        [ListDrawerSettings(ShowIndexLabels = true)]
        [SerializeField] private List<StageSO> stages;
        [Range(0, 10)]
        [SerializeField] private float minimumDropDistance;
        [Range(0, 10)]
        [SerializeField] private float pieceReturningSpeed;
    }
}
