using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    private Player player;

    public InputControls controls { get; private set; }

    private Vector2 moveDirection;

    private bool StartedDoubleClick = false;
    private bool IsDashing = false;
    private bool CanDash = true;

    [SerializeField] private float dashCooldown = 2f;
    private float dashCooldownTimer = 0f;
    [SerializeField] private float dashTime = 1f;
    private float dashTimer = 0f;

    private float doubleClickTimer = 0f;
    private float doubleClickTime = 0.3f;
    private char key = ' ';

    private int curDirection = 1;

    [SerializeField] float movementSpeed = 5;
    [SerializeField] float dashAmplifier = 2f;

    public delegate void PlayerMovedCallback();
    public PlayerMovedCallback playerMovedCallback;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
        player = GetComponent<Player>();
        controls = new InputControls();

        controls.Player.Attack.performed += _ctx_attack => Attack();
    }

    void check()
    {
        Debug.Log("released");
    }

    private void Update()
    {

        if (IsDashing)
        {
            Dash();
            playerMovedCallback?.Invoke();
        }
        else 
        { 
            MovePlayer();
            playerMovedCallback?.Invoke();
        }

        if (!CanDash && !IsDashing)
        {
            dashCooldownTimer -= Time.deltaTime;
            if (dashCooldownTimer <= 0f)
            {
                CanDash = true;
            }
        }

        if (StartedDoubleClick)
        {
            doubleClickTimer -= Time.deltaTime;

            DetectKeyPressed();
            

            if (doubleClickTimer <= 0f)
            {
                StartedDoubleClick = false;
            }
        }


        if (CanDash)
        {
            CheckKeyPressForDASH();
        }

        
    }

    private bool DetectKeyPressed()
    {
        bool keyPressed = false;

        if (Keyboard.current.dKey.wasPressedThisFrame && key == 'D')
        {
            keyPressed = true;
        }
        if (Keyboard.current.wKey.wasPressedThisFrame && key == 'W')
        {
            keyPressed = true;
        }
        if (Keyboard.current.sKey.wasPressedThisFrame && key == 'S')
        {
            keyPressed = true;
        }
        if (Keyboard.current.aKey.wasPressedThisFrame && key == 'A')
        {
            keyPressed = true;
        }

        if (keyPressed)
        {
            Dash();
            IsDashing = true;

            dashTimer = dashTime;

            StartedDoubleClick = false;
        }

        return keyPressed;
    }

    private void MovePlayer()
    {
        moveDirection = controls.Player.Move.ReadValue<Vector2>();

        Debug.Log(moveDirection);

        transform.position += new Vector3(moveDirection.x, moveDirection.y, 0) * movementSpeed * Time.deltaTime;

        FlipChar((int)moveDirection.x);
    }

    private void FlipChar(int _direction)
    {
        if(_direction == 0)
        {
            return;
        }

        if(_direction != curDirection)
        {
            transform.Rotate(0, 180, 0);
            curDirection = _direction;
        }
    }

    private void Dash()
    {
        Vector2 dashDirection = controls.Player.Move.ReadValue<Vector2>();

        transform.position += new Vector3(dashDirection.x, dashDirection.y) * movementSpeed * dashAmplifier * Time.deltaTime;

        dashTimer -= Time.deltaTime;

        if(dashTimer <= 0f)
        {
            IsDashing = false;
            //START DASH COOLDOWN
            dashCooldownTimer = dashCooldown;
        }

        FlipChar((int)dashDirection.x);
    }

    private void CheckKeyPressForDASH()
    {
        
        if (Keyboard.current.dKey.wasReleasedThisFrame)
        {
            StartedDoubleClick = true;
            doubleClickTimer = doubleClickTime;

            key = 'D';
        }
        if (Keyboard.current.wKey.wasReleasedThisFrame)
        {
            StartedDoubleClick = true;
            doubleClickTimer = doubleClickTime;

            key = 'W';
        }
        if (Keyboard.current.sKey.wasReleasedThisFrame)
        {
            StartedDoubleClick = true;
            doubleClickTimer = doubleClickTime;

            key = 'S';
        }
        if (Keyboard.current.aKey.wasReleasedThisFrame)
        {
            StartedDoubleClick = true;
            doubleClickTimer = doubleClickTime;

            key = 'A';
        }

        CanDash = false;
    }

    private void Attack()
    {
        Debug.Log("ATTACK!");
        player.Attack();
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
