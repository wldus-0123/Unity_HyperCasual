using UnityEngine;

public class PipeLineMover : MonoBehaviour
{
	[SerializeField] float moveSpeed;

	private void Start()
	{
		Destroy(gameObject, 10);  // 삭제 예약
	}

	private void Update()
	{
		transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

		/*
		 * if( transform.position.x < -10)
		{
			Destroy(gameObject);
		}
		*/
	}
}
