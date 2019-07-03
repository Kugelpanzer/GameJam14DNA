using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : EnemyBase
{
    public List<string> Moves=new List<string>();
    public List<int> Duration = new List<int>();
    public int currDuration;

    public int br = 0;
    //private char[] listMoves;
    private List<Vector2> vMoves = new List<Vector2>();
    private Vector2 sumMoves = new Vector2();

    private void Counter()
    {

        if (br < Duration.Count-1)
        {
            br++;

        }
        else
        {
            br = 0;
        }
        
        //listMoves = Moves[br].ToCharArray();
        /*string s="";
        foreach (char c in listMoves)
            s += c;

        Debug.Log(s);*/
        currDuration = Duration[br];
    }
    private void GetMoves(char[] ch)
    {
        vMoves.Clear();
        foreach (char c in ch)
        {
            switch (c)
            {
                case 'l':
                    vMoves.Add(-Vector2.right);
                    break;
                case 'd':
                    vMoves.Add(-Vector2.up);
                    break;
                case 'r':
                    vMoves.Add(Vector2.right);
                    break;
                case 'u':
                    vMoves.Add(Vector2.up);
                    break;
            }
        }
        sumMoves = new Vector2();
        foreach (Vector2 m in vMoves)
            sumMoves += m;

        sumMoves = sumMoves.normalized;
    }
    protected override void EnemyMove()
    {
        if (currDuration > 0)
        {

            moveVector = sumMoves;
            //code for movment

            //
            currDuration--;
        }
        else
        {
            Counter();
            GetMoves(Moves[br].ToCharArray());
        }


    }
    private void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.volume = ControllerVal.Instance.volume;
        //listMoves = Moves[br].ToCharArray();
        currDuration = Duration[br];
        GetMoves(Moves[br].ToCharArray());
    }


}
