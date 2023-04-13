using UnityEngine;

namespace UI
{
    public class InteractionUI : MonoBehaviour
    {
        private static InteractionUI _instance = null;
        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
                return;
            }
            
            _instance = this;
        }

        private void ChangeUIState(bool state)
        {
            gameObject.SetActive(state);
        }
    }
}