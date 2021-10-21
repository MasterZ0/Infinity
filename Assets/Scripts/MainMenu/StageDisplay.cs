using Infinity.Data;
using Sirenix.OdinInspector;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Infinity.MainMenu
{

    /// <summary>
    /// Store the stage information and call the StageWindow when your button is pressed
    /// </summary>
    public class StageDisplay : MonoBehaviour {

        [Title("Stage Display")]
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private GameObject padlock;
        [SerializeField] private Image background;
        [SerializeField] private Button button;

        private Action<StageSO> onCaseStart;
        private StageSO stage;
        public void Init(StageSO stage, bool locked, Action<StageSO> callback) {
            background.sprite = stage.Background;
            padlock.SetActive(locked);
            button.interactable = !locked;
            this.stage = stage;
            titleText.text = stage.name;

            onCaseStart = callback;
        }

        public void OnClick() {
            onCaseStart.Invoke(stage);
        }
    }
}