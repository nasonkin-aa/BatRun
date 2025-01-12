using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private void OnMouseDrag()
    {
        Vector2 _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(Mathf.Round(_mousePos.x), Mathf.Round(_mousePos.y));
    }
}
