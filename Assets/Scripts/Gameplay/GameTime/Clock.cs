using System.Threading.Tasks;
using Utils;

using UnityEngine;

using TMPro;

/*
    If a minute is 60 seconds and minutesDilution is 20 seconds its mean that every
    20 seconds in the real life 1 minute in the game passes
*/

namespace Gameplay.GameTime
{
    public class Clock : Publisher
    {
        [SerializeField] Day dayPublisher = default;

        [SerializeField] TextMeshProUGUI clockReference = default;

        [SerializeField] private int minutesDilution = default;
        
        private int _actualSeconds = 0;
        private int _actualMinutes = 0;
        private int _actualHours = 0;

        public void AddSeconds(int time)
        {
            _actualSeconds += time;
            int countMinutes = UtilInt.CheckBound(ref _actualSeconds, minutesDilution);

            if (countMinutes < 1) return;

            AddMinutes(countMinutes);
        }

        public void AddMinutesVisual(int time)
        {
            _actualMinutes += time;
            _actualHours += UtilInt.CheckBound(ref _actualMinutes, 60);

            ChangeActualTime();
        }

        public void AddMinutes(int time)
        {
            if (time < 1) return;

            AddMinutesVisual(time);

            Notify(time);
        }

        public async void FastForwardTime(int clockTimeToPassInMin, int realWorldTimeInSec)
        {
            int tick = clockTimeToPassInMin / realWorldTimeInSec;
            int i;
            

            for (i = 0; i < realWorldTimeInSec; i++)
            {
                AddMinutes(tick);
                await Task.Delay(1 * 1000);
            }
        }

        public void SetTime(int hours, int minutes)
        {
            _actualHours = hours;
            _actualMinutes = minutes;

            ChangeActualTime();
        }

        public void ChangeDay()
        {
            dayPublisher.DayChange(1);
        }

        public void ChangeDay(int dayCount)
        {
            dayPublisher.DayChange(dayCount);
        }

        private void ChangeActualTime()
        {
            if (_actualHours > 24)
            {
                _actualHours = 0;
                ChangeDay();
            }

            clockReference.text =
                UtilStrings.ConvertPositiveNumberToFixedSize(_actualHours, 2) + ":" +
                UtilStrings.ConvertPositiveNumberToFixedSize(_actualMinutes, 2);
        }
    }
}
