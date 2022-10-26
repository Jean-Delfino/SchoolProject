using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Interactions
{
    public class NeedToFinishInteraction : MonoBehaviour
    {
        [SerializeField] private Button finishButton;
        
        public void Setup(Interaction interaction)
        {
            finishButton.onClick.RemoveAllListeners();
            finishButton.onClick.AddListener(() => StartCoroutine(interaction.CallEnd()));
        }
    }
}