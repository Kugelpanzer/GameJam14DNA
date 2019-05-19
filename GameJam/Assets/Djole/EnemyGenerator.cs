using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    public List<GameObject> enemyList = new List<GameObject>();
    public List<GameObject> spawnPoint = new List<GameObject>();
    public GameObject bossSpawn;
    public GameObject boss;
    public int spawnTime;
    private int currTime;
    public int bossTimer;
    private int currBossTimer;
    private bool end;



    private void Spawn()
    {
        GameObject curr;
        int r;
        foreach(GameObject sp in spawnPoint)
        {
            r = Random.Range(-1,enemyList.Count);
            if (r != -1)
            {
                curr=Instantiate(enemyList[r]);
                curr.transform.position = sp.transform.position;

            }
        }
    }
    private void SpawnBoss()
    {
        GameObject curr;
        curr = Instantiate(boss);
        curr.transform.position = bossSpawn.transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        spawnTime *= 60;
        bossTimer *= 60;
        currBossTimer = bossTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (!end)
        {
            if (currBossTimer > 0)
            {
                currBossTimer--;
                if (currTime > 0)
                {
                    currTime--;
                }
                else
                {
                    Spawn();
                    currTime = spawnTime;
                }

            }
            else
            {
                SpawnBoss();
                end = true;
            }
        }
    }
}
