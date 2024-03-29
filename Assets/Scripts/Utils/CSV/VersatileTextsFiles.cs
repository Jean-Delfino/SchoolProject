﻿using UnityEngine;

namespace Utils.CSV
{
    [CreateAssetMenu(fileName = "Localization", menuName = "Resources/VersatileTextsFiles")]
    public class VersatileTextsFiles : ScriptableObject
    {
        public TextAsset[] files;

        public int actualLanguage = 0;
    }
}