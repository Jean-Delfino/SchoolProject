using System;
using TMPro;
using UnityEngine;

namespace Utils.CSV
{
    public class VersatileText : MonoBehaviour
    {
        [SerializeField] private string textKey;
        
        private TextMeshProUGUI _text;
        public void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
            GameVersatileTextsController.Subscribe(this);
        }

        private void OnDestroy()
        {
            GameVersatileTextsController.Unsubscribe(this);
        }

        public void SetText()
        {
            var newText = GameVersatileTextsLocator.Localize(textKey);
            if(newText == null) return;
            
            _text.text = newText;
        }
    }
}