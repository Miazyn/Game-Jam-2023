using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHealth
{  
    public float armor { get => armor; set { armor = value; } }
    public float currentHealth { get => currentHealth; set { currentHealth = value; } }
    public float maxHealth { get => maxHealth; set { maxHealth = value; } }
    public bool canBeDamaged { get => canBeDamaged; set { canBeDamaged = value; } }

    public void changeHealth(float change)
    {
        change = currentHealth;
        if (currentHealth <= 0)
        {
            die();
        }
    }

    public void die()
    {
        Destroy(gameObject);
    }
    
    void Start()
    {
        armor = 0;
        maxHealth = 100;
        currentHealth = maxHealth;
        canBeDamaged = true;
    }
}
