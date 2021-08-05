using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PointLightManager : MonoBehaviour
{
    public static PointLightManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }



    public void turnToRed(Light light)
    {
        light.color = Color.red;
    }

    public void turnToBlue(Light light)
    {
        light.color = Color.blue;
    }

    public void blinkRandomly(Light light, float minBlink, float maxBlink, float minLightIntensity, float maxLightIntensity, bool canBlink)
    {
        if (canBlink)
        {
            StartCoroutine(flicker(light, minLightIntensity, maxLightIntensity, minBlink, maxBlink));

        }
        else
        {
            light.enabled = true;
            light.intensity = 1;
        }
    }

    IEnumerator flicker(Light pointLight, float minLightIntensity, float maxLightIntensity, float minBlink, float maxBlink)
    {
        while (true)
        {
            pointLight.enabled = true;
            pointLight.intensity = Random.Range(minLightIntensity, maxLightIntensity);
            yield return new WaitForSeconds(Random.Range(minBlink, maxBlink));
            pointLight.enabled = false;
            yield return new WaitForSeconds(Random.Range(minBlink, maxBlink));

        }
    }

}
