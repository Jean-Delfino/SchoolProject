using UnityEngine;

using Utils;

using TMPro;

namespace Gameplay.GameTime 
{ 
    public class Day : Publisher{
        [SerializeField] private TextMeshProUGUI daysReference = default;
        
        private int _daysCount = 1;
        public void DayChange(int addition){
            _daysCount += addition;
            daysReference.text = _daysCount.ToString();

            Notify(addition);
        }
    }
}
