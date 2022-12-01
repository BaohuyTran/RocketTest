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
        SpawnBall(0);
        SpawnBall(1);
        SpawnBall(2);
    }

    // Update is called once per frame
    void Update()
    {
        ballCount = GameObject.FindGameObjectsWithTag("Ball").Length;
        if (ballCount < 3)
        {
            SpawnBall(player.colorIndex);
        }
    }

    void SpawnBall(int index)
    {        
        Instantiate(ballPrefab[index], GenerateSpawnPosition(), ballPrefab[index].transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 1, spawnPosZ);

        return randomPos;
    }
}
