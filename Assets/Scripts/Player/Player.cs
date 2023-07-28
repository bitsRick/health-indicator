using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Player
{
    [RequireComponent(typeof(HealthBar))]
    public class Player : MonoBehaviour
    {
        private const float MinimumHealth = 0f;
        private const float MaximumHealth = 100f;

        [SerializeField] private HealthBar _healthBar;
        
        private UnityAction<float> _updatedBarValue;
        private float _currentHealth = 50f;

        private void OnEnable()
        {
            _updatedBarValue += _healthBar.UpdateValue;
        }

        private void Start()
        {
            _healthBar.SetValue(MaximumHealth,_currentHealth);
        }

        private void OnDisable()
        {
            _updatedBarValue -= _healthBar.UpdateValue;
        }

        public void AddHealth(float addHealth = 10f) => 
            UpdateHealth(addHealth);

        public void AddDamage(float addDamage = 10f) => 
            UpdateHealth(-addDamage);

        private void UpdateHealth(float updateValue)
        {
            _currentHealth += updateValue;
            _currentHealth = Mathf.Clamp(_currentHealth,MinimumHealth,MaximumHealth);
            _updatedBarValue?.Invoke(_currentHealth);
        }
    }
}
