using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public InputControls controls { get; private set; }

    private Vector2 moveDirection;

    [SerializeField] float movementSpeed = 5;

    private void Awake()
    {
        controls = new InputControls();

    }

    private void Start()
    {
        
    }

    private void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        moveDirection = controls.Player.Move.ReadValue<Vector2>();

        transform.position += new Vector3(moveDirection.x, moveDirection.y, 0) * movementSpeed * Time.deltaTime;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
