using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public SpeedManager speedManager;
    public float speed;

    protected MoveAll _moveAll;

    private void Awake()
    {
        speedManager = GameObject.FindObjectOfType<SpeedManager>();
        speed = speedManager.gameSpeed;
    }

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
