using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandGenerator : MonoBehaviour
{

    public int time;
    private int currTime;

    public GameObject pos;
    public GameObject island;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!ControllerVal.Instance.pause)
        if (currTime >= 0 ) 
        {
            currTime--;
        }
        else
        {

            GameObject c;
            c = Instantiate(island);
            c.transform.position = new Vector3(Random.Range(-5f, 5f), pos.transform.position.y, 0);
            currTime = time;

        }
    }

}
