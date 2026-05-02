using UnityEngine;
using UnityEngine.InputSystem;

public class GravityControl : MonoBehaviour
{
    private CharacterController cc;
    private Vector3 playerVelocity = Vector3.zero;
    [SerializeField] private float gravity = -9.8f;
    private void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Jump();
        Gravity();

        cc.Move(playerVelocity * Time.deltaTime);
    }

    private void Jump()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if(cc.isGrounded)
            {
                playerVelocity.y += 6.0f;
            }
            Debug.Log("점프키를 감지했습니다.");
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
}
