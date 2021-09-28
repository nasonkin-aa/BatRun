using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPatrolObstacle : MonoBehaviour
{
    public float _minX = -0.27f;
    public float _maxX = 0.27f;
    public float _minY = -0.37f;
    public float _maxY = 0.37f;

    public GameObject MoveZone;

    private float _speedObs = 0.5f;
    private bool _stay = true;
    Vector2 TargetPosition;

    void Start()
    {
        TargetPosition = GetRandomPosition();   
    }
    private void Update()
    {
        //Debug.Log((Vector2)transform.position != TargetPosition);
        if((Vector2)transform.localPosition != TargetPosition && _stay)
        {
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, TargetPosition, _speedObs * Time.deltaTime);
        }
        else if ((Vector2)transform.localPosition == TargetPosition)
        {
            _stay = false;
            StartCoroutine(StopToStart());
            Debug.Log(TargetPosition);
        }
    }
    private IEnumerator StopToStart()
    {
        TargetPosition = GetRandomPosition();
        yield return new WaitForSeconds(1f);
        Debug.Log(TargetPosition);
        _stay = true;
    }

    Vector2 GetRandomPosition()
    {
        float _randomX = Random.Range(_minX, _maxX);
        float _randomY = Random.Range(_minY, _maxY);
        return new Vector2(_randomX, _randomY);
    }
}
