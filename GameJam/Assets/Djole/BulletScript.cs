using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public GameObject target;
    public int Demage;
    public int moveSpeed;
    private Vector2 targetPos;

    private void MoveScript()
    {
        if (target != null)
        {
            transform.Translate(targetPos.normalized * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(-Vector2.up * moveSpeed * Time.deltaTime);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (target != null)
            targetPos = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveScript();
    }
   /* private void OnCollisionEnter2D(Collision2D collision)
    {

    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerScript>().TakeDemage(Demage);
            Destroy(gameObject);
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
