using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHealth
{
    [Header("Editor Visibile")]
    [SerializeField] private float armorStats = 0;
    [SerializeField] private float maxHealthAmount = 0;


    public float armor { get; set; }
    public float currentHealth { get; set; }
    public float maxHealth { get; set; }
    public bool canBeDamaged { get; set; }


    public enum AI
    {
        Tree,
        Player,
        Structures
    }
    [Header("AI")]
    [SerializeField] private float aiScanUpdate = 10f;
    [SerializeField] private AI enemyAI;

    void Start()
    {
        if(maxHealthAmount == 0)
        {
            maxHealth = 100;
        }
        else
        {
            maxHealth = maxHealthAmount;
        }
        if(armorStats == 0)
        {
            armor = 0;
        }
        else
        {
            armorStats = armor;
        }

        currentHealth = maxHealth;
        canBeDamaged = true;

        StartCoroutine(LookForAttack());
    }


    private void Update()
    {
        Debug.Log(currentHealth);
    }

    IEnumerator LookForAttack()
    {
        while (true)
        {
            Debug.Log($"Looking for... {enemyAI}");
            
            yield return new WaitForSeconds(aiScanUpdate);
        }
    }


    public void changeHealth(float change)
    {
        currentHealth += change;

        if (currentHealth <= 0)
        {
            die();
        }
    }

    public void die()
    {
        Destroy(gameObject);
    }


}
