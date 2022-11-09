using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu.Language
{
    public class SelectLanguageButton : MonoBehaviour
    {
        public void Awake()
        {
            GetComponent<Button>().onClick.
                AddListener(() => transform.parent.GetComponent<SelectLanguageMenu>().ChangeLanguage(transform.GetSiblingIndex()));
        }
    }
}
