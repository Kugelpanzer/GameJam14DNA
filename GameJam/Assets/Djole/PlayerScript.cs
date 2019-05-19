using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{


    private bool flagMoving;// if moving is true cant move in ant other direction
    private Vector2 vLeft, vRight, vUp, vDown;
    private Vector2 moveVector;

    public int health;
    private bool inv; //while true player is invurnable

    public float moveSpeed=1;

    [Tooltip("Dash reload in frames")]
    public int dashReload = 60;
    public int dashPower = 10;

    public int dashDuration = 20;
    private int currDashTime,currDash,currDashReload;

    public float laserDistance = 0.2f;
    public float laserStep = 0.01f;

    private float currAngle;
    private List<Vector2> point = new List<Vector2>();
    private List<Vector2> currPoint = new List<Vector2>();

    public GameObject bigLaser;
    public GameObject smallLaserPos;

    // public int protectedTimer;// time while imune to demage

    [Tooltip("Time that player cant take demage, starts when player takes demage")]
    public int invurnableTimer;
    private int currInvTime;

    private Vector3 cc;

    public void TakeDemage(int demage)
    {
        if (!inv)
        {
           
            if (health > 0)
            {
                health -= demage;
                inv = true;
            }
            else
            {
                DeathTrigger();
            }
        }
    }

    private void DeathTrigger()
    {
        Debug.Log("umro si");
    }

    private void InvTime()
    {
        if (inv && currInvTime >= 0)
        {
            currInvTime--;
        }
        else if (inv && currInvTime < 0)
        {
            currInvTime = invurnableTimer;
            inv = false;
        }
    }
    private void Dashing()
    {
        if (currDashTime > 0)
        {
            currDash = dashPower;
            currDashTime--;
        }
        else
        {
            currDash = 0;
        }
        if (currDashReload > 0)
        {
            currDashReload--;
        }

    }

    private void MoveScript()
    {
        vLeft = Vector2.zero;
        vRight = Vector2.zero;
        vUp = Vector2.zero;
        vDown = Vector2.zero;


        if (Input.GetKey(KeyCode.A))
        {
            vRight =-Vector2.right;
        }
        if (Input.GetKey(KeyCode.W))
        {
            vUp = Vector2.up;
        }
        if (Input.GetKey(KeyCode.D))
        {
            vLeft = Vector2.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vUp = -Vector2.up;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (currDashReload <= 0)
            { 
                currDashTime = dashDuration;
                currDashReload = dashReload;
            }
        }
        moveVector = (vLeft + vRight + vUp + vDown).normalized * (moveSpeed+ currDash);
        transform.Translate(moveVector*Time.deltaTime);
    }
    void Start()
    {
        for(int i =0; i < 5; i++)
        {
            currPoint.Add(new Vector2());
        }
        for(float i=-2* laserDistance; i<=2* laserDistance; i+= laserDistance)
        {
            point.Add(new Vector2(i, 2*laserDistance));
        }
        /*foreach (Vector2 ii in point)
            Debug.Log(ii);*/
    }

    private void Firing()
    {
        LaserPos bl = bigLaser.GetComponent<LaserPos>();
        LaserPos sl = smallLaserPos.GetComponent<LaserPos>();
        LaserList sList = smallLaserPos.GetComponent<LaserList>();
        bl.onScreen = false;
        if (currDashReload <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                if (currAngle <= laserDistance)
                {
                    currAngle += laserStep;
                }
            }
            else
            {
                if (currAngle>0)
                {
                    currAngle -= laserStep;
                }
               if (currAngle <= 0)
                {
                    bl.onScreen = true;
                }
            }
            if (!bl.onScreen)
            {
                sl.onScreen = true;
                currPoint[0] = Vector2.Lerp(point[2], point[0], currAngle);
                currPoint[1] = Vector2.Lerp(point[2], point[1], currAngle);
                currPoint[2] = Vector2.up;
                currPoint[3] = Vector2.Lerp(point[2], point[3], currAngle);
                currPoint[4] = Vector2.Lerp(point[2], point[4], currAngle);

                int i = 0;
                foreach(GameObject l in sList.lasers)
                {
                    cc = currPoint[i];
                    l.transform.up =cc/* - transform.position*/;
                    //l.transform.LookAt(currPoint[i]);
                    //Debug.DrawRay(transform.position, cc/*-transform.position*/, Color.red);
                    //Camera.main.ScreenToWorldPoint(Input.mousePosition)
                    i++;

                }

            }
            else
            {
                sl.onScreen = false;
            }
        }
        //OVDE ----------------------------------------------------------------------------------------
        else
        {
            sl.onScreen = false;
            bl.onScreen = false;
        }


    }


    // Update is called once per frame
    void Update()
    {
        Firing();
        Dashing();
        InvTime();
        MoveScript();
    }
}
