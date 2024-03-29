﻿using System;
using System.Collections.Generic;
using UnityEngine;

using KeyMappingValues = Gameplay.InputManagement.InputMapper.KeyMappingValues;

namespace Gameplay.InputManagement
{
    public class InputManager : MonoBehaviour
    {
        private static InputManager _instance;

        public InputMapper inputMapping;
        
        private readonly Dictionary<string, KeyMappingValues> _keyValues = new();

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            SetKeyValues();
        }

        public static void SetKeyValues()
        {
            var inputMappingDictionary = _instance._keyValues;
            
            foreach (var key in _instance.inputMapping.visibleMapping)
            {
                if (!inputMappingDictionary.ContainsKey(key.id))
                {
                    inputMappingDictionary.Add(key.id, key.value);
                }
                else
                {
                    inputMappingDictionary[key.id] = key.value;
                }
            }
        }

        public static int GetKey(string key)
        {
            return Convert.ToInt32(Input.GetKey(_instance._keyValues[key].positiveKey.value));
        }

        public static int GetAxis(string key)
        {
            return Convert.ToInt32(Input.GetKey(_instance._keyValues[key].positiveKey.value)) - 
                   Convert.ToInt32(Input.GetKey(_instance._keyValues[key].negativeKey.value));
        }
        
    }
}