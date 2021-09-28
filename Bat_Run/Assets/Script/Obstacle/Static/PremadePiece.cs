using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PremadePiece : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("NoChildDestroy", 5f, 5f);
    }

    void NoChildDestroy()
    {
        if (transform.childCount == 0)
        {
            Destroy(gameObject);
        }
    }
    
}
