using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Almighty : Obstacle
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Vampire"))
        {
            collision.gameObject.SetActive(false);
            _moveAll.VampireDeath = true;
            _moveAll.ScoreBat = _moveAll.ScoreBat - _moveAll.transformZone._spawnCounter;
            _moveAll.transformZone._spawnCounter = 0;
            
        }
        if (collision.CompareTag("Bat"))
        {
            Destroy(collision.gameObject);
            _moveAll.CounterBat--;
            _moveAll.ScoreBat--;
            _moveAll.CounterBat = 0;
        }

    }

}
