using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(HealthBar))]
    public class Player : MonoBehaviour
    {
        private const float MaxAddHealth = 10f;
        private const float MaxAddDamage = 10f;
        private const float MinimumHealthHero = 0f;

        [SerializeField] private HealthBar _healthBar;

        private float _maxHealth = 100f;
        private float _currentHealth = 50f;

        public void AddHealth()
        {
            _currentHealth += MaxAddHealth;

            if (_currentHealth > _maxHealth) 
                _currentHealth = _maxHealth;
        }

        public void AddDamage()
        {
            _currentHealth -= MaxAddDamage;
        
            if (_currentHealth < MinimumHealthHero)
                _currentHealth = MinimumHealthHero;
        }

        private void Start()
        {
            _healthBar.SetValueHealthBar(_maxHealth,_currentHealth);
        }

        private void Update()
        {
            _healthBar.UpdateValueHealthBar(_currentHealth);
        }
    }
}
