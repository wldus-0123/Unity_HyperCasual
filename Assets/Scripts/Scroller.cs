using UnityEngine;

public class Scroller : MonoBehaviour
{
	[SerializeField] Transform[] children;  // �ڽĵ��� ��ġ ����
	[SerializeField] float scrollSpeed;     // ��ũ�� �ӵ�
	[SerializeField] float offset;

	private void Update()
	{
		for(int i = 0; i < children.Length; i++)
		{
			children[i].Translate(Vector2.left * scrollSpeed * Time.deltaTime, Space.World); // ������ �������� �ڽĵ��� �������� �о��ֱ�
			
			if(children[i].position.x < -offset)  // x���� â ������ �Ѿ��
			{
				Vector2 pos = new Vector2(offset, children[i].position.y);
				children[i].position = pos;  
			}
		}
	}

}
