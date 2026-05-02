using System;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [Header("플레이어 움직임 wasd")]
    private PlayerControls controls;
    private CharacterController cc;
    private Vector2 moveInput;
    private Vector3 move;
    public float speed = 3.0f;


    [Header("플레이어 움직임 jump")]
    private Vector3 playerVelocity = Vector3.zero;
    [SerializeField] private float gravity = -9.8f;

    private void Awake()
    {
        controls = new PlayerControls();
        cc = GetComponent<CharacterController>();

        // Move 액션에 대한 콜백 등록
        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;
    }

    private void Update()
    {
        Move();
        Jump();
        Gravity();
        cc.Move((move * speed + playerVelocity) * Time.deltaTime);
    }

    private void Move()
    {
        move = new Vector3(moveInput.x, 0f, moveInput.y);
    }

    private void Jump()
    {
        //
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if(cc.isGrounded)
            {
                playerVelocity.y += 6.0f;
            }
            //Debug.Log("점프키를 감지했습니다.");
        }
    }

    private void Gravity()
    {
        if (cc.isGrounded && playerVelocity.y < 0f)
        {
            playerVelocity.y = -2f;
        }

        playerVelocity.y += gravity * Time.fixedDeltaTime;
    }

    void OnEnable()
    {
        controls.Player.Enable();
    }

    void OnDisable()
    {
        controls.Player.Disable();
    }

}
