using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    private void OnMouseDrag()
    {
        Debug.Log("ok");
        Vector2 _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(_mousePos.x, _mousePos.y);
    }
}
