using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private InputActionAsset m_Controls = null;

    [SerializeField]
    private float m_speed = 6f;

    private Vector2 m_MovementInput = Vector2.zero;

    private void Awake()
    {
        InputActionMap playerMap = m_Controls.FindActionMap("Player");

        InputAction shootAction = playerMap.FindAction("Shoot");
        shootAction.performed += (ctx) => { Shoot(); };

        InputAction moveAction = playerMap.FindAction("Move");
        moveAction.performed += (ctx) => { m_MovementInput = ctx.ReadValue<Vector2>(); };
        moveAction.canceled += (ctx) => { m_MovementInput = Vector2.zero; };

        playerMap.Enable();

    }

    public void Update()
    {
        Move(m_MovementInput, Time.deltaTime);
    }

    public void Move(Vector2 _Direction, float _DeltaTime)
    {
        Debug.Log("MOVE " + _Direction);
        Debug.DrawRay(transform.position, _Direction, Color.yellow, 0.2f);
        _Direction.Normalize();
        Vector3 movement = new Vector3(_Direction.x, 0f, _Direction.y);
        transform.position += movement * m_speed * _DeltaTime;
    }

    public void Shoot()
    {
        Debug.Log("SHOOT!");
    }



}
