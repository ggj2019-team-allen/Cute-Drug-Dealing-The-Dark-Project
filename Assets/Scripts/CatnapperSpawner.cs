using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatnapperSpawner : MonoBehaviour
{
    public int spawnLimit;
    public int spawnCount;
    public Transform[] spawnPoints;
    private float xNum = 11.35f;
    public GameObject npc;
    int randX;
    Vector2 whereToSpawn;
    public float spawnRate = 5f;
    public float nextSpawn = 10f;
    private int randY;
    public Transform[] waypoints;

    // Start is called before the first frame update
    void Start()
    {
        spawnCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            if (spawnCount < spawnLimit)
            {
                randY = Random.Range(0, spawnPoints.Length);
                nextSpawn = Time.time + spawnRate;

                

                whereToSpawn = new Vector2(xNum, spawnPoints[randY].transform.position.y);
                GameObject catNapper = Instantiate(npc, whereToSpawn, Quaternion.identity);
                spawnCount += 1;

            }
        }
    }
}
