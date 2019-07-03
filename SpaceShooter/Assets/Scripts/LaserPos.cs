using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPos : MonoBehaviour
{
    public Transform outPlace;
    public GameObject player;
    public bool onScreen;

    private GameObject controller;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = outPlace.position;
        controller = GameObject.Find("Controller");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!ControllerVal.Instance.pause)
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


}
