using UnityEngine;

public class Scroller : MonoBehaviour
{
	[SerializeField] Transform[] children;  // 자식들의 위치 보관
	[SerializeField] float scrollSpeed;     // 스크롤 속도
	[SerializeField] float offset;

	private void Update()
	{
		for(int i = 0; i < children.Length; i++)
		{
			children[i].Translate(Vector2.left * scrollSpeed * Time.deltaTime, Space.World); // 세상을 기준으로 자식들을 왼쪽으로 밀어주기
			
			if(children[i].position.x < -offset)  // x값이 창 범위를 넘어서면
			{
				Vector2 pos = new Vector2(offset, children[i].position.y);
				children[i].position = pos;  
			}
		}
	}

}
