using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    public GameObject[] planets;
    public Transform environment;
    List<float> planetsSpeed;
    List<float> planetsRotationSpeed;
    float randomPlanetSpeed;
    float randomPlanetRotationSpeed;
    //0.07f;


    private void Awake()
    {
        planetsSpeed = new List<float>(planets.Length);
        planetsRotationSpeed = new List<float>(planets.Length);

        for (int i = 0; i < planets.Length; i++)
        {
            randomPlanetSpeed = Random.Range(0.007f, 0.05f);
            planetsSpeed.Add(randomPlanetSpeed);
            randomPlanetRotationSpeed = Random.Range(10f, 20f);
            planetsRotationSpeed.Add(randomPlanetRotationSpeed);

        }
    }


    private void FixedUpdate()
    {
        for(int i = 0; i < planets.Length; i++)
        {
            planets[i].transform.RotateAround(environment.position, Vector3.up, planetsSpeed[i]);
            planets[i].transform.Rotate(Vector3.up * Time.deltaTime * planetsRotationSpeed[i]);

        }


    }

}
