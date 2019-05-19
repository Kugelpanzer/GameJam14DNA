using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPos : MonoBehaviour
{
    public Transform outPlace;
    public GameObject player;
    public bool onScreen;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (onScreen)
        {
            transform.position = player.transform.position;

        }
        else
        {
            transform.position = outPlace.position;
        }
        
    }


}
