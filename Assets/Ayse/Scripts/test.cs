using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    public Light[] LightArr;



    // Update is called once per frame
    void Update()
    {
        //turnToBlue(Light);
        //turnToRed(Light);
        //blinkRandomly(Light, 1f, 3f, 1f, 3f, true);
        foreach(Light light in LightArr)
        {
            //blinkRandomly(light, 1, 2, 1, 2, true);
            turnToBlue(light);
        }
    }

    private void Start()
    {
        foreach (Light light in LightArr)
        {
            //blinkRandomly(light, 1, 2, 1, 2, true);
            turnToBlue(light);
        }
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
            //pointLight.enabled = false;
            yield return new WaitForSeconds(Random.Range(minBlink, maxBlink));

        }
    }


}
