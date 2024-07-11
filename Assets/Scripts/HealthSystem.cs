using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    public event EventHandler OnMaxHPChanged;
    public event EventHandler OnDamaged;
    public event EventHandler OnHealed;
    public event EventHandler OnDied;

    private int currentHP;
    [SerializeField] private int maxHP;

    private void Awake()
    {
        currentHP = maxHP;
    }

    public void Damage(int damageAmount)
    {
        currentHP -= damageAmount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        OnDamaged?.Invoke(this, EventArgs.Empty);

        if (IsDead())
        {
            OnDied?.Invoke(this, EventArgs.Empty);
        }
    }
    public bool IsDead()
    {
        return currentHP == 0;
    }
    public bool IsFullHealth()
    {
        return currentHP == maxHP;
    }

    public int GetCurrentHP()
    {
        return currentHP;
    }
    public int GetMaxHP()
    {
        return maxHP;
    }

    public float GetCurrentHPNormalized()
    {
        return (float)currentHP / maxHP;
    }

    public void SetHealthAmountMax(int maxHealth, bool updateHealthAmount)
    {
        maxHP = maxHealth;

        if (updateHealthAmount)
        {
            currentHP = maxHealth;
        }

        OnMaxHPChanged?.Invoke(this, EventArgs.Empty);
    }
    public void Heal(int healAmount)
    {
        currentHP += healAmount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        OnHealed?.Invoke(this, EventArgs.Empty);
    }
    public void HealFull()
    {
        currentHP = maxHP;

        OnHealed?.Invoke(this, EventArgs.Empty);
    }
}
