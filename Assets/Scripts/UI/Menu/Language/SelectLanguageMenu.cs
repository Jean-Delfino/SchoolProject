using UnityEngine;
using Utils.CSV;

namespace UI.Menu.Language
{
    public class SelectLanguageMenu : MonoBehaviour
    {
        public void ChangeLanguage(int desiredLanguage)
        {
            GameVersatileTextsController.ChangeActualLanguage(desiredLanguage);
        }
    }
}
