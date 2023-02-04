using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    float armor { get; set; }
    float currentHealth { get; set; }
    float maxHealth { get; set; }
    public bool canBeDamaged { get; set; }

    void changeHealth(float change);
    void die();
}