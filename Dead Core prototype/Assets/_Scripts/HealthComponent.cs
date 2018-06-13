using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour, IDamageable<float>
{
    [SerializeField] private Image _healthBar;
    [SerializeField] protected float _startHealth;
    [SerializeField] protected float _maxHealth;
    [SerializeField, ReadOnly] protected float _currentHealth;

    private void Start()
    {
        _currentHealth = _startHealth;
    }

    /// <summary>
    /// Decreases the health of the entity
    /// </summary>
    /// <param name="amount"></param>
    public virtual void TakeDamage(float amount)
    {
        _currentHealth -= amount;

        if (_currentHealth <= 0)
        {
            Die();
            return;
        }

        RefreshHealthBar();
    }

    /// <summary>
    /// Increases the health of the entity
    /// </summary>
    /// <param name="amount"></param>
    public bool IncreaseHealth(float amount)
    {
        if (_currentHealth < _maxHealth)
        {
            _currentHealth += amount;
            if (_currentHealth >= _maxHealth)
            {
                _currentHealth = _maxHealth;
            }

            RefreshHealthBar();
            return true;
        }

        return false;
    }


    private void RefreshHealthBar()
    {
        _healthBar.fillAmount = _currentHealth / _startHealth;

        if (_healthBar.fillAmount >= 0.5f)
        {
            _healthBar.color = Color.green;
        }

        if (_healthBar.fillAmount >= 0.25f && _healthBar.fillAmount < 0.5f)
        {
            _healthBar.color = Color.yellow;
        }

        if (_healthBar.fillAmount < 0.25f)
        {
            _healthBar.color = Color.red;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
