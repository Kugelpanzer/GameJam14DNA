using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    Vector3 up;
    public float moveSpeed=1;
    public GameObject pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!ControllerVal.Instance.pause)
        {
            up = Vector2.up;
            transform.position -= up * Time.deltaTime * moveSpeed;
        }
    }
    void OnBecameInvisible()
    {
        if(pos!=null)
            transform.position = pos.transform.position;
    }
}
