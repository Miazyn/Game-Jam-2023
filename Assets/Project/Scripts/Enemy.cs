using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHealth
{
    [Header("Editor Visibile")]
    [SerializeField] private float armorStats = 0;
    [SerializeField] private float maxHealthAmount = 0;
    public GameObject tree;
    public float movementSpeed;


    public float armor { get; set; }
    public float currentHealth { get; set; }
    public float maxHealth { get; set; }
    public bool canBeDamaged { get; set; }


    public enum AI
    {
        Tree,
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
        float timeBetweenAttacks = 1;
        while (true)
        {
            switch (enemyAI)
            {
                case AI.Tree:
                    if (Vector3.Distance(transform.position, tree.transform.position + Vector3.down * 2f) > .5)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, tree.transform.position + Vector3.down * 2f, movementSpeed);
                    }
                    while (currentHealth<=0)
                    {
                        tree.GetComponent<IHealth>().changeHealth(-10);
                        Debug.Log("Damaged!!!");
                        yield return new WaitForSeconds(timeBetweenAttacks);
                    }
                    break;
                case AI.Structures:
                    break;
                default:
                    break;
            }
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
