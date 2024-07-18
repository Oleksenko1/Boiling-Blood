using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Tooltip("Healtbar require to have 'bar' object with fill image of health")]
    [SerializeField] private HealthSystem healthSystem;

    private Image barImage;
    private void Start()
    {
        barImage = transform.Find("bar").GetComponent<Image>();
        UpdateFillAmount();
        healthSystem.OnDamaged += HealthSystem_OnDamaged;
        healthSystem.OnHealed += HealthSystem_OnHealed;
    }
    private void HealthSystem_OnDamaged(object sender, EventArgs e)
    {
        UpdateFillAmount();
    }
    private void HealthSystem_OnHealed(object sender, EventArgs e)
    {
        UpdateFillAmount();
    }
    private void UpdateFillAmount()
    {
        barImage.fillAmount = (float) healthSystem.GetCurrentHP() / healthSystem.GetMaxHP();
    }
}
