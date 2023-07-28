using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Player
{
    public class HealthBar:MonoBehaviour
    {
        [SerializeField] private Slider _sliderUIBar; 
        [SerializeField] private float _fillingRateUIBar;

        private float _currentValue;
        private Coroutine _fillingUiBarRoutine;

        public void UpdateValue(float value)
        {
            if(_fillingUiBarRoutine != null)
                StopCoroutine(_fillingUiBarRoutine);

            _fillingUiBarRoutine = StartCoroutine(FadeIn(value));
        }

        public void SetValue(float maxValue,float currentValue)
        {
            _sliderUIBar.maxValue = maxValue;
            _sliderUIBar.value = currentValue;
        }

        private IEnumerator FadeIn(float value)
        {
            _currentValue = value;
            
            while (_sliderUIBar.value != _currentValue)
            {
                _sliderUIBar.value = Mathf.MoveTowards(
                _sliderUIBar.value,
                _currentValue, 
                Time.deltaTime * _fillingRateUIBar);

                yield return null;
            }
        }
    }
}