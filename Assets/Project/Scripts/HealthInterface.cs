using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    float armor { get; }
    float currentHealth { get; }
    float maxHealth { get; }
    bool canBeDamaged { get; }

    void changeHealth(float damage);
    void die();
}