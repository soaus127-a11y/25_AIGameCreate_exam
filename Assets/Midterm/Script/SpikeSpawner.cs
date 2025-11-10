using UnityEngine;
using System.Collections;

public class SpikeSpawner : MonoBehaviour
{
    public GameObject SpikePrefab;
    private Coroutine spawnRoutine;

    private bool isGameOver = false;

    void Start()
    {
        spawnRoutine = StartCoroutine(SpawnSpikeRoutine());
    }

    IEnumerator SpawnSpikeRoutine()
    {
        while (!isGameOver)
        {
            float waitTime = Random.Range(1f, 4f);
            yield return new WaitForSeconds(waitTime);

            if (isGameOver)
                yield break; // 게임오버면 코루틴 종료

            Debug.Log("Spawner : Spike 생성!");
            GameObject spike = Instantiate(SpikePrefab);
            spike.transform.position = transform.position;
        }
    }

    // 게임오버 시 호출되는 함수
    public void GameOver()
    {
        isGameOver = true;
        if (spawnRoutine != null)
        {
            StopCoroutine(spawnRoutine);
        }
        Debug.Log("게임 종료 - 스파이크 생성 멈춤");
    }
}
