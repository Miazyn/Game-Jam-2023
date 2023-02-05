using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_PlayerUpgrades : MonoBehaviour
{
    public Player player;


    public void AddPlayerWeapon()
    {
        player.WeaponChanged(Player.WeaponType.Melee);
    }
}
