﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.InputManagement
{
    [CreateAssetMenu(menuName = "Game Design/Input System/Input mapper")]
    public class InputMapper : ScriptableObject
    {
        public List<KeyMapping> visibleMapping;

        [Serializable]
        public class KeyMapping
        {
            public string id;
            public KeyMappingValues value;
        }
        
        [Serializable]
        public class KeyMappingValues
        {
            public Key positiveKey;
            public Key negativeKey;
        }
        
        [Serializable]
        public class Key
        {
            public string value;
            public string keyName;
        }
    }
}