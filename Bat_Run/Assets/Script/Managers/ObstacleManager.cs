using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObstacleManager : MonoBehaviour
{
    public GameObject wallPref;
    public Collider2D[] colliders;
    public float radius = 3f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ObstacleSpawn",1f,1f);
    } 

    void ObstacleSpawn()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-5.5f, 5.5f), 6f);

        colliders = Physics2D.OverlapCircleAll(spawnPosition, radius);

        if (colliders.Length <= 0)
            Instantiate(wallPref, spawnPosition, Quaternion.identity);
    }
}
