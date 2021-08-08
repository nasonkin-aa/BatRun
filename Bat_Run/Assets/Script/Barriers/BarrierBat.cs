using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierBat : Barrier
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bat")
        {
            Destroy(collision.gameObject);
            moveAll.CounterBat--;
        }
    }
}
