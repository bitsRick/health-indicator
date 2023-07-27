using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Player
{
    public class HealthBar:MonoBehaviour
    {
        [SerializeField] private Slider _sliderHealthBar; 
        [SerializeField] private float _healthBarFillingRate;

        private float _currentValueHealthBar;
        private Coroutine _coroutineUpdateHealthBar;

        public void UpdateValueHealthBar(float health) => 
            _coroutineUpdateHealthBar = StartCoroutine(FadeIn(health));

        public void SetValueHealthBar(float maxHealth,float currentValue)
        {
            _sliderHealthBar.maxValue = maxHealth;
            _sliderHealthBar.value = currentValue;
        }

        private IEnumerator FadeIn(float currentValueHealth)
        {
            _currentValueHealthBar = currentValueHealth;
            
            while (_sliderHealthBar.value != _currentValueHealthBar)
            {
                _sliderHealthBar.value = Mathf.MoveTowards(
                _sliderHealthBar.value,
                _currentValueHealthBar, 
                Time.deltaTime * _healthBarFillingRate);

                yield return null;
            }
            
            StopCoroutine(_coroutineUpdateHealthBar);
        }
    }
}