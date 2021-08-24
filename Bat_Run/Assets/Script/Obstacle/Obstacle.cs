using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public SpeedManager speedManager;
    public float speed;

    protected MoveAll _moveAll;

    protected void Awake()
    {
        _moveAll = GameObject.FindObjectOfType<MoveAll>();
        speedManager = GameObject.FindObjectOfType<SpeedManager>();
        //Debug.Log(speedManager.gameSpeed);
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
}
