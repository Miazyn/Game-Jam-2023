using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private PlayerController player;


    private void Start()
    {
        player = PlayerController.Instance;
        player.playerMovedCallback += MoveCamera; 
    }

    private void MoveCamera()
    {
        var playerPos = player.transform.position;
        transform.position = new Vector3(playerPos.x, playerPos.y, transform.position.z);
    }
}
