using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiBat : Obstacle
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bat"))
        {
            Destroy(collision.gameObject);
            _moveAll.CounterBat--;
            _moveAll.CounterBat = 0;// ???
        }
    }
}
