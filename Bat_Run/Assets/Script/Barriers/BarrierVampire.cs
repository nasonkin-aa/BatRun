using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierVampire : Barrier
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Vampire")
        {
            Destroy(collision.gameObject);
        }
    }
}
