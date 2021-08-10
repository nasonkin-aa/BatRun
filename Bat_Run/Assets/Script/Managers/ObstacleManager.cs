using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ObstacleManager : MonoBehaviour
{
    public GameObject wallPref;
    public GameObject piecePref;
    public Collider2D[] colliders;
    public float radius = 3f;

    private int spawnCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ObstacleSpawn", 2f, 3f);
    }

    void ObstacleSpawn()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-3f, 3f), 6f);

        colliders = Physics2D.OverlapCircleAll(spawnPosition, radius);

        Debug.Log(!colliders.Any(n => n.gameObject.tag == "Obstacle"));

        if (!colliders.Any(n => n.gameObject.tag == "Obstacle") && spawnCounter < 6)
        {
            Instantiate(wallPref, spawnPosition, Quaternion.identity);
            spawnCounter += 1;
        }
        else
        {
            spawnPosition = new Vector2(0, 6f);
            Instantiate(piecePref, spawnPosition, Quaternion.identity);
            spawnCounter = 0;
        }
    }

    private void Update()
    {

    }
}
