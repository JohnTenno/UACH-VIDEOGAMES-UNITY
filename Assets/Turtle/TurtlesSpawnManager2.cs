using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtlesSpawnManager2 : MonoBehaviour
{
    [SerializeField] protected float minWaitTime = 2f;
    [SerializeField] protected float maxWaitTime = 3f;
    [SerializeField] protected TurtleSpawnPoint spawnPointR;
    [SerializeField] protected TurtleSpawnPoint spawnPointL;

    protected float waitTime = 0f;
    protected bool allowSpawn = true;


    void Update()
    {
        if (allowSpawn)
        {

            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {

                // Debug.Log("WaitTime: " + waitTime);
                if (Random.value > 0.5f)
                {
                    spawnPointR.Spawn();
                }
                else
                {
                    spawnPointL.Spawn();
                }
                waitTime = Random.Range(minWaitTime, maxWaitTime);
            }
        }
    }


    void Stop()
    {
        allowSpawn = false;
    }
}
