using System.Collections;
using UnityEngine;
using Util.GameEvents;
using Util.Variables;

namespace Pong
{
    public class MBCountdown : MonoBehaviour
    {
        private ICountdown _countdown = null;

        [SerializeField]
        private VoidEvent countdownBeginEvent = null;

        [SerializeField]
        private IntEvent countdownTickEvent = null;

        [SerializeField]
        private VoidEvent countdownCompleteEvent = null;

        private int _currentCount { get; set; }

        public bool IsComplete => _countdown.IsComplete;

        [SerializeField]
        private FloatReference countdownTime = null;

        private void Awake()
        {
            if(countdownTime != null)
                _countdown = new Countdown(countdownTime.Value);
        }

        private void OnEnable()
        {
            _countdown.OnCountdownTick += TickUpdated;
            _countdown.OnCountdownReset += UpdateCountdown;
            _countdown.OnCountdownComplete += TriggerOnComplete;
        }

        public void StartCountdown()
        {
            ResetCountdown();
            countdownBeginEvent?.Raise();

            if(_countdown != null)
                StartCoroutine(ActiveCountdown());
        }

        private IEnumerator ActiveCountdown()
        {
            while (!_countdown.IsComplete)
            {
                _countdown?.Tick(Time.deltaTime);
                yield return null;
            }
        }

        private void TickUpdated(float tick)
        {
            int convertedTick = Mathf.CeilToInt(tick);

            if (convertedTick != _currentCount)
            {
                _currentCount = convertedTick;
                countdownTickEvent?.Raise(_currentCount);
            }
        }

        public void ResetCountdown() => _countdown?.Reset();

        public void UpdateCountdown() => countdownTickEvent?.Raise(_currentCount);

        private void TriggerOnComplete() => countdownCompleteEvent?.Raise();

        private void OnDisable()
        {
            _countdown.OnCountdownTick -= TickUpdated;
            _countdown.OnCountdownReset -= UpdateCountdown;
            _countdown.OnCountdownComplete -= TriggerOnComplete;
        }
    }
}