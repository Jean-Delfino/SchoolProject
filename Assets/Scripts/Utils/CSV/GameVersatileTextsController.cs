using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utils.CSV
{
    public class GameVersatileTextsController : MonoBehaviour
    {
        [SerializeField] private VersatileTextsFiles files;

        private static readonly List<VersatileText> VersatileTexts = new();
        public void Awake()
        {
            GameVersatileTextsLocator.InitializeTexts(files);
            ChangeActualLanguage(files.actualLanguage);
        }

        public void ChangeActualLanguage(int newLanguage)
        {
            files.actualLanguage = newLanguage; //This saves the file in memory
            GameVersatileTextsLocator.ChangeActualLanguage(files.actualLanguage);
            SetAllTexts();
        }
        
        public void SetAllTexts()
        {
            foreach (var text in VersatileTexts)
            {
                text.SetText();
            }
        }

        public static void Subscribe(VersatileText text)
        {
            VersatileTexts.Add(text);
        }
        
        public static void Unsubscribe(VersatileText text)
        {
            VersatileTexts.Remove(text);
        }
    }
}