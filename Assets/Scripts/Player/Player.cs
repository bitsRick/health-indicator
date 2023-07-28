using System;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public event UnityAction<float> updatedValueHealth;

        public float MaximumHealth { get; private set; }
        public float MinimumHealth { get; private set; }
        public float CurrentHealth { get; private set; }

        private void Start()
        {
            MaximumHealth = 100f;
            MinimumHealth = 0f;
            CurrentHealth = 50f;
        }

        public void AddHealth(float addHealth = 10f) =>
            UpdateHealth(addHealth);

        public void AddDamage(float addDamage = 10f) =>
            UpdateHealth(-addDamage);

        private void UpdateHealth(float updateValue)
        {
            CurrentHealth += updateValue;
            CurrentHealth = Mathf.Clamp(CurrentHealth, MinimumHealth, MaximumHealth);
            updatedValueHealth?.Invoke(CurrentHealth);
        }
    }
}