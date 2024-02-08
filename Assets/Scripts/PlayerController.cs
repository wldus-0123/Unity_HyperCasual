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
        // 힘에 의한 속도 변경 - 가속 방식 : 점점 속도변화 
        // rigid.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);

        // 속도에 의한 변경 - 속도지정 방식 : 정해진 속도로 세팅
        rigid.velocity = Vector2.up * jumpSpeed;

    }

	private void Rotate()
	{
		transform.right = rigid.velocity + Vector2.right * moveSpeed; // 내가 속력을 가지고 있는 방향으로 변경
	}

    private void Die()
    {
        animator.SetBool("Die", true);
        OnDied?.Invoke();
    }

	private void OnCollisionEnter2D(Collision2D collision)  // 충돌했을 때
	{
        // if (장애물과 부딪히면)
        Die();
	}
}
