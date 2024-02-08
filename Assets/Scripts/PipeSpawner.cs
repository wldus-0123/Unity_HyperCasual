using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
	[SerializeField] GameObject pipeLinePrefab;
	[SerializeField] Transform spawnPoint;
	[SerializeField] float repeatTime;
	[SerializeField] float randomRange;

	private Coroutine coroutine;

	private void OnEnable()
	{
		coroutine = StartCoroutine(SpawnRoutine());
	}
	
	private void OnDisable()
	{
		StopCoroutine(coroutine);
	}
	IEnumerator SpawnRoutine()
	{
		
		while(true)
		{
			yield return new WaitForSeconds(repeatTime);
			Vector3 random = Vector2.up * Random.Range(-randomRange, randomRange);
			Instantiate(pipeLinePrefab, spawnPoint.position + random, spawnPoint.rotation);  // 랜덤한 크기만큼 위아래로 위치 변경
		}

	}
}
