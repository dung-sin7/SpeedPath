using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceived : MonoBehaviour
{
    [SerializeField] private float percentDamaged = 0f;
    [SerializeField] private float maxDamaged = 100f;
    [SerializeField] private bool isDead = false;

    public bool IsDead => isDead;

    private void Awake()
    {
        this.Reborn();
    }

    public void Reborn()
    {
        this.percentDamaged = 0f;
    }

    private void Update()
    {
        this.CheckOnDead();
    }

    public void TakeDamage(float percent)
    {
        this.percentDamaged += percent;
        if (percentDamaged < 0f) { percentDamaged = 0; }
        if (percentDamaged > maxDamaged) { percentDamaged = maxDamaged; }
    }

    public void RepairDamage(float percent)
    {
        this.percentDamaged -= percent;
        if (percentDamaged < 0f) { percentDamaged = 0; }
        if (percentDamaged > maxDamaged) { percentDamaged = maxDamaged; }
    }

    public void CheckOnDead()
    {
        if (percentDamaged >= maxDamaged) this.OnDead();
    }

    private void OnDead()
    {
        this.isDead = true;
    }
}
