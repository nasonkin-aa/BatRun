using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformZone : MonoBehaviour
{
    public bool _triggerStayStart = false;
    [SerializeField]
    private MoveAll moveAll;
    public int _spawnCounter;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bat" && _triggerStayStart == true)
        {
            Destroy(collision.gameObject);
            _spawnCounter++;
            //Debug.Log(_spawnCounter);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Bat")
        {
            moveAll.CounterBat++;
            Debug.Log(moveAll.CounterBat);
            if(moveAll.CounterBat >= 3)
            {
                _triggerStayStart = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bat")
        {
            moveAll.CounterBat--;
            Debug.Log(moveAll.CounterBat);
        }
    }
}
