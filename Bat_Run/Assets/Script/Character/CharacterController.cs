using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update

    private bool _click;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //if (_click)
        //{
        //    _mousePos = Camera.main.ScreenToWorldPoint(_mousePos);
        //    this.transform.position = new Vector2(_mousePos.x, _mousePos.y);
        //}
        //else
        //{

        //}
        
    }

    private void OnMouseDown()
    {
        _click = false;

    }
    private void OnMouseUp()
    {
        _click = true;
    }
    private void OnMouseDrag()
    {
        Vector2 _mousePos = Input.mousePosition;

        _mousePos = Camera.main.ScreenToWorldPoint(_mousePos);
        this.transform.position = new Vector2(_mousePos.x, _mousePos.y);
        Debug.Log("sad");
    }
}
