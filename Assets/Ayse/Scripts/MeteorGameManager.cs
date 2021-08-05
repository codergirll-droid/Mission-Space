using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorGameManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject asteroid;
    public float minWaitingTime = 1f;
    public float maxWaitingTime = 5f;
    int randomPoint = 0;
    public bool canSpawn = true;

    private void Start()
    {
        //StartCoroutine(spawnNumerator());

    }

    private void FixedUpdate()
    {
        //StartCoroutine(spawnNumerator());
        if (canSpawn)
        {
            canSpawn = false;
            randomPoint = Random.Range(0, spawnPoints.Length);

            Instantiate(asteroid, spawnPoints[randomPoint].position, spawnPoints[randomPoint].rotation);
            StartCoroutine(wait());
        }

    }


    IEnumerator spawnNumerator()
    {
        yield return new WaitForSeconds(Random.Range(minWaitingTime, maxWaitingTime));

        while (true)
        {
            randomPoint = Random.Range(0, spawnPoints.Length);
            Instantiate(asteroid, spawnPoints[randomPoint].position, spawnPoints[randomPoint].rotation);
            yield return new WaitForSeconds(Random.Range(minWaitingTime, maxWaitingTime));
        }
            
        


    }


    IEnumerator wait()
    {
        yield return new WaitForSeconds(Random.Range(minWaitingTime, maxWaitingTime));
        canSpawn = true;
    }


}
