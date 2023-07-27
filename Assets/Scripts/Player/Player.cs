using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(HealthBar))]
    public class Player : MonoBehaviour
    {
        private const float MinimumHealthHero = 0f;

        [SerializeField] private HealthBar _healthBar;

        private float _maxHealth = 100f;
        private float _currentHealth = 50f;

        private void Start()
        {
            _healthBar.SetValueHealthBar(_maxHealth,_currentHealth);
        }

        public void AddHealth(float addHealth = 10f) => 
            UpdateValueHealth(_currentHealth += addHealth);

        public void AddDamage(float addDamage = 10f) => 
            UpdateValueHealth(_currentHealth -= addDamage);

        private void UpdateValueHealth(float updateValue)
        {
            _currentHealth = updateValue;
            
            if (_currentHealth > _maxHealth) 
                _currentHealth = _maxHealth;
            else if(_currentHealth < MinimumHealthHero)
                _currentHealth = MinimumHealthHero;

            _healthBar.UpdateValueHealthBar(_currentHealth);
        }
    }
}
