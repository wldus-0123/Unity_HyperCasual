using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] Animator animator;

    [Header("Specs")]
    [SerializeField] float jumpSpeed;
    [SerializeField] float moveSpeed;

    [Header("Events")]
    public UnityEvent OnDied;


	private void Update()
	{
        Rotate();
	}

	private void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            Jump();
        }
    }

    private void Jump()
    {
        // ���� ���� �ӵ� ���� - ���� ��� : ���� �ӵ���ȭ 
        // rigid.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);

        // �ӵ��� ���� ���� - �ӵ����� ��� : ������ �ӵ��� ����
        rigid.velocity = Vector2.up * jumpSpeed;

    }

	private void Rotate()
	{
		transform.right = rigid.velocity + Vector2.right * moveSpeed; // ���� �ӷ��� ������ �ִ� �������� ����
	}

    private void Die()
    {
        animator.SetBool("Die", true);
        OnDied?.Invoke();
    }

	private void OnCollisionEnter2D(Collision2D collision)  // �浹���� ��
	{
        // if (��ֹ��� �ε�����)
        Die();
	}
}
