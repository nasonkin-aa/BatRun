using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatCollectable : Obstacle
{
    public GameObject batPref;

    public MoveAll moveAll;

    private void Awake()
    {
        moveAll = GameObject.FindObjectOfType<MoveAll>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bat"))
        {
            Instantiate(batPref, transform.position, Quaternion.identity, GameObject.Find("Character").transform);

            moveAll.ScoreBat++;

            Destroy(gameObject);
        }
    }
}
