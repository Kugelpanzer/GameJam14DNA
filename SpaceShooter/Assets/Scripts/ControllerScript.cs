using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {

        if ((Input.GetButtonDown("Pause") || Input.GetButtonDown("Cancel"))&& ControllerVal.Instance.pause ==false)
        {
            ControllerVal.Instance.pause = true;
        }else if((Input.GetButtonDown("Pause") || Input.GetButtonDown("Cancel"))&& ControllerVal.Instance.pause == true)
        {
            ControllerVal.Instance.pause = false;
        }
    }
}
