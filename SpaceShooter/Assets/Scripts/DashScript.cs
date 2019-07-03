using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour
{
    public Transform outPos;
    public void MoveOut()
    {
        transform.position = outPos.position;
    }

}
