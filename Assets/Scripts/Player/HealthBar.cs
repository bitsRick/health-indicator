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

        public void UpdateValueHealthBar(float health)
        {
            _currentValueHealthBar = health;
        }
        
        public void SetValueHealthBar(float maxHealth,float currentValue)
        {
            _sliderHealthBar.maxValue = maxHealth;
            _sliderHealthBar.value = currentValue;
        }
        
        private void Update()
        {
            _sliderHealthBar.value = Mathf.MoveTowards(
                _sliderHealthBar.value,
                _currentValueHealthBar, 
                Time.deltaTime * _healthBarFillingRate);
        }
    }
}