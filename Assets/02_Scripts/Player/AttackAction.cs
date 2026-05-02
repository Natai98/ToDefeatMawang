using UnityEngine;
using UnityEngine.InputSystem;

public class AttackAction : MonoBehaviour
{
    private PlayerControls controls;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controls = GetComponent<PlayerMove>().controls;

        controls.Player.Attack.performed += ctx => Attack();
    }

    private void Attack()
    {
        Debug.Log("어택!!");

        Vector2 mousePos = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        int interactLayerMask = LayerMask.GetMask("InteractObject");

        if (Physics.Raycast(ray, out RaycastHit hit, interactLayerMask))
        {
            if (hit.collider == null ) return;

            float distance = Vector3.Distance(transform.position, hit.collider.transform.position);
            if(distance < 10.0f)
            {
                hit.collider.GetComponent<IDamage>()?.TakeDamage(1.0f);
                Debug.Log("공격이 적중했습니다.");
            }
            else
            {
                Debug.Log("공격이 빗나갔습니다.");
            }
        }
        else
        {
            return;
        }
    }
}
