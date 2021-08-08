using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    protected MoveAll _moveAll;
    public float speed;

    void Update()
    {
        Move();
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    protected void Move()
    {
        transform.position -= new Vector3(0, speed * Time.deltaTime);
    }
    protected void Start()
    {
        _moveAll = GameObject.FindObjectOfType<MoveAll>();
    }
}
