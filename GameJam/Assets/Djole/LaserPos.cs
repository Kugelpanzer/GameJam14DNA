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
        transform.position = outPlace.position;
    }

    // Update is called once per frame
    void LateUpdate()
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
