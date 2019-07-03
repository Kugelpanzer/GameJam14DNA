using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyGenerator : MonoBehaviour
{

    public List<GameObject> enemyList = new List<GameObject>();
    public List<GameObject> spawnPoint = new List<GameObject>();
    public int spawnTime;
    private int currTime;
    [Tooltip("In seconds")]
    public int levelTimer;
    private int currLevelTimer;



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

    // Start is called before the first frame update
    void Start()
    {
        spawnTime *= 60;
        levelTimer *= 60;
        currLevelTimer = levelTimer;
    }
    private void EndLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // Update is called once per frame
    void Update()
    {
        if (!ControllerVal.Instance.pause)
        {

            if (currLevelTimer > 0)
            {
                    currLevelTimer--;
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
                EndLevel();
            }

        }
    }
    
}
