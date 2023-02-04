using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    private float armor { get; }
    private float currentHealth { get; }
    private float maxHealth { get; }
    private bool canBeDamaged { get; }

    public void changeHealth(float damage);
}