using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Player>().HP <= 0)
        {
            Destroy(gameObject);
        }

        // Xac dinh vi tri hoi sinh dich
        if (transform.position.x == 10f || transform.position.x == -10f)
        {
            transform.position = new Vector2(transform.position.x, Random.Range(-6f, 6f));
        }
        else if (transform.position.y == 6f || transform.position.x == -6f)
        {
            transform.position = new Vector2(Random.Range(-10f, 10f), transform.position.y);
        }

        // Hoi sinh dich
        if (timeBtwSpawn <= 0)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            if (startTimeBtwSpawn - decreaseTime > minTime)
            {
                startTimeBtwSpawn -= decreaseTime;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
