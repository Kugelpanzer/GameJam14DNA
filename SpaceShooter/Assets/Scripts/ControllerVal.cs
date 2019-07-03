using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerVal
{
    private static ControllerVal instance = new ControllerVal();
    public static ControllerVal Instance => instance;
    public bool pause=false;

    public float volume=0.5f;
    // Start is called before the first frame update

}
