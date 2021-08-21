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
            Debug.Log(_spawnCounter);
            Destroy(collision.gameObject);
            _spawnCounter++;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bat")
        {
            moveAll.CounterBat++;
            if(moveAll.CounterBat >= 3)
            {
                StartCoroutine(WaitBeforeTransform());
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bat")
        {
            moveAll.CounterBat--;
        }
    }

    private IEnumerator WaitBeforeTransform()
    {
        yield return new WaitForSeconds(0.2f);// test 
                _triggerStayStart = true;
       
    }
}
