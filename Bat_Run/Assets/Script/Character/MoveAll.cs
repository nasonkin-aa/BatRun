using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAll : MonoBehaviour
{
    private GameObject[] _bat;
    private float _speedBat = 10f;
    [SerializeField]
    private GameObject TransformZone;

    private void OnMouseDrag()
    {
        _bat = GameObject.FindGameObjectsWithTag("Bat");
        Vector3 _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePos.z = transform.position.z;
        for(int i = 0; i < _bat.Length; i++)
        {
            _bat[i].transform.position = Vector3.MoveTowards(_bat[i].transform.position, _mousePos, Time.deltaTime * _speedBat);
        }
    }

    private void OnMouseUp()
    {
        
    }
}
