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

    private Rigidbody2D _rb;
    Vector2 TargetPosition;
    Vector2 direction;
    void Start()
    {
        TargetPosition = GetRandomPosition();
        _rb = this.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, 
            Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.up, direction)), 205 * Time.deltaTime);

        if ((Vector2)transform.localPosition != TargetPosition && _stay)
        {
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, TargetPosition, _speedObs * Time.deltaTime);
        }
        else if ((Vector2)transform.localPosition == TargetPosition)
        {
            _stay = false;
            StartCoroutine(StopToStart());
           // Debug.Log(TargetPosition);
        }
    }
    private IEnumerator StopToStart()
    {

        TargetPosition = GetRandomPosition();
        RotaionSpider();
        yield return new WaitForSeconds(1f);
       // Debug.Log(TargetPosition);
        _stay = true;
    }

    Vector2 GetRandomPosition()
    {
        float _randomX = Random.Range(_minX, _maxX);
        float _randomY = Random.Range(_minY, _maxY);
        return new Vector2(_randomX, _randomY);
    }

    private void RotaionSpider()
    {
        direction = new Vector2(
             (transform.localPosition.x - TargetPosition.x),
             transform.localPosition.y - TargetPosition.y);
        
        direction = -direction ;
        Debug.Log(Quaternion.Euler(0, 0, Vector2.Angle(direction, Vector2.up)));
        

    }
}
  