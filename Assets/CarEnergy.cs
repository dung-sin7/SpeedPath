using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEnergy : MonoBehaviour
{
    [SerializeField] private float fuel = 100f;
    [SerializeField] private float capacity = 100f;

    private void Awake()
    {
        this.Reborn();
    }

    public void Reborn()
    {
        this.fuel = this.capacity;
    }

    public void ConsumeFuel(float percent)
    {
        this.fuel -= percent;
        if (this.fuel < 0f) { this.fuel = 0; }
        if (this.fuel > this.capacity) { this.fuel = this.capacity; }
    }

    public void LoadFuel(float percent)
    {
        this.fuel += percent;
        if (this.fuel < 0f) { this.fuel = 0; }
        if (this.fuel > this.capacity) { this.fuel = this.capacity; }
    }

    public void AddCapacity(float percent)
    {
        this.capacity += percent;
        if (this.capacity < 0f) { this.capacity = 0; }
    }
}
