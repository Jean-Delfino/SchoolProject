using System;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.InputManagement
{
    public class InputRebindingUI : MonoBehaviour
    {
        [SerializeField] private Button finishRebindingButton;

        private void Awake()
        {
            finishRebindingButton.onClick.AddListener(FinishRebinding);
        }

        private static void FinishRebinding()
        {
            InputManager.SetKeyValues();
        }
    }
}