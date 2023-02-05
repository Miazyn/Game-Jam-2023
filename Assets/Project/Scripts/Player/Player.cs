using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private BoxCollider2D fistCol;
    [SerializeField] private BoxCollider2D meleeCol;
    [SerializeField] private BoxCollider2D rangedCol;

    [SerializeField] private GameObject melee;
    [SerializeField] private GameObject ranged;

    public enum WeaponType
    {
        Fist,
        Melee,
        Ranged
    }

    public WeaponType WeaponEquipped;

    [SerializeField] private float fistDamage = 5;
    [SerializeField] private float meleeDamage = 15;
    [SerializeField] private float rangedDamage = 10;

    private void Start()
    {
        ChangeEquippedWeapon();
    }

    public void WeaponChanged(WeaponType _weapon)
    {
        WeaponEquipped = _weapon;

        ChangeEquippedWeapon();
    }

    private void ChangeEquippedWeapon()
    {
        switch (WeaponEquipped)
        {
            case WeaponType.Fist:
                melee.SetActive(false);
                ranged.SetActive(false);
                break;
            case WeaponType.Melee:
                melee.SetActive(true);
                ranged.SetActive(false);
                break;
            case WeaponType.Ranged:
                melee.SetActive(false);
                ranged.SetActive(true);
                break;
            default:
                melee.SetActive(false);
                ranged.SetActive(false);

                Debug.LogError("No Active weapon nor EquippedWeaponState found.");
                break;
        }
    }

    public void Attack()
    {
        switch (WeaponEquipped)
        {
            case WeaponType.Fist:
                HitTarget(fistCol, fistDamage);
                break;
            case WeaponType.Melee:
                HitTarget(meleeCol, meleeDamage);
                break;
            case WeaponType.Ranged:
                HitTarget(rangedCol, rangedDamage);
                break;
            default:
                Debug.LogError("Weapon out of range!");
                break;
        }
    }

    private void HitTarget(BoxCollider2D _rangeCollision, float dmg)
    {
        var CollisionCheck = Physics2D.OverlapBox(_rangeCollision.bounds.center, _rangeCollision.size, 0f);

        if(CollisionCheck == null)
        {
            return;
        }

        IHealth hit = CollisionCheck.GetComponent<IHealth>();

        if(hit == null)
        {
            return;
        }

        Debug.Log($"Hit item, going to damage it. {CollisionCheck}");
        hit.changeHealth(-dmg);
    }

}

