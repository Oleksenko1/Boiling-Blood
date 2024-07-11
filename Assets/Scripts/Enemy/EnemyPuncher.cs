using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyPuncher : MonoBehaviour
{
    private HealthSystem healthSystem;

    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();

        healthSystem.OnDied += HealthSystem_OnDied;
    }

    private void HealthSystem_OnDied(object sender, EventArgs e)
    {
        Debug.Log(transform.name + " died");
        Destroy(gameObject);
    }
}
