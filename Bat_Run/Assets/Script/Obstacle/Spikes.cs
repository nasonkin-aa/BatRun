using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : Obstacle
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Vampire"))
        {
            Debug.Log("Yes");
        }
    }
}