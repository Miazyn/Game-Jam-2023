using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerController player;

    private BoxCollider2D boxCol;

    [SerializeField] private SpriteRenderer weaponRenderer;

    [SerializeField] private Sprite fist;
    [SerializeField] private Sprite melee;
    [SerializeField] private Sprite ranged;

    [SerializeField] private Animator weaponAnimator;

    [SerializeField] private GameObject unarmored;
    [SerializeField] private GameObject armored;


    private AudioSource audio;
    [SerializeField] private AudioClip hit;
    [SerializeField] private AudioClip coin;
    [SerializeField] private AudioClip dash;

    [SerializeField] public bool HasArmor { get; private set; }

    private Enemy enemy;
    private bool canHitEnemy = false;
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
        audio = GetComponent<AudioSource>();

        player = PlayerController.Instance;

        player.playerDashCallback += PlayDashSound;

        ChangeEquippedWeapon();
    }


    public void PlayDashSound()
    {
        audio.clip = dash;
        audio.Play();
    }

    public void PlayHitSound()
    {
        audio.clip = hit;
        audio.Play();
    }

    public void PlayCoinSound()
    {
        audio.clip = coin;
        audio.Play();
    }


    public void PlayerArmorStatus(bool _hasArmor)
    {
        HasArmor = _hasArmor;

        if (!HasArmor)
        {
            unarmored.SetActive(true);
            armored.SetActive(false);
        }
        else
        {
            unarmored.SetActive(false);
            armored.SetActive(true);
        }
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
                weaponRenderer.sprite = fist;
                break;
            case WeaponType.Melee:
                weaponRenderer.sprite = melee;
                break;
            case WeaponType.Ranged:
                weaponRenderer.sprite = ranged;
                break;
            default:
                Debug.LogError("No Active weapon nor EquippedWeaponState found.");
                break;
        }
    }

    public void Attack()
    {
        if (!canHitEnemy)
        {
            return;
        }

        switch (WeaponEquipped)
        {
            case WeaponType.Fist:
                
                enemy.changeHealth(-fistDamage);
                PlayHitSound();
                break;
            case WeaponType.Melee:
                weaponAnimator.Play("scytheswing");
                enemy.changeHealth(-meleeDamage);
                PlayHitSound();
                break;
            case WeaponType.Ranged:
                enemy.changeHealth(-rangedDamage);
                PlayHitSound();
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Enemy>(out enemy))
        {
            canHitEnemy = true;
        }
        else
        {
            enemy = null;
            canHitEnemy = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(enemy == collision.GetComponent<Enemy>())
        {
            enemy = null;
            canHitEnemy = false;
        }
        else
        {
            canHitEnemy = true;
        }
    }

}

