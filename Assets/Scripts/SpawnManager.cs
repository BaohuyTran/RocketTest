using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] ballPrefab;
    private float spawnRange = 20f;
    public int ballCount;

    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        Instantiate(ballPrefab[0], GenerateSpawnPosition(), ballPrefab[0].transform.rotation);
        Instantiate(ballPrefab[1], GenerateSpawnPosition(), ballPrefab[1].transform.rotation);
        Instantiate(ballPrefab[2], GenerateSpawnPosition(), ballPrefab[2].transform.rotation);
        ballCount = GameObject.FindGameObjectsWithTag("Ball").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (ballCount < 3)
        {
            StartCoroutine(SpawnBall(player.colorIndex));
            //SpawnBall(player.colorIndex);
        }
    }

    IEnumerator SpawnBall(int index)
    {
        ballCount++;
        yield return new WaitForSeconds(1);
        Instantiate(ballPrefab[index], GenerateSpawnPosition(), ballPrefab[index].transform.rotation);
        //ballCount = GameObject.FindGameObjectsWithTag("Ball").Length;
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 1, spawnPosZ);

        return randomPos;
    }
}
