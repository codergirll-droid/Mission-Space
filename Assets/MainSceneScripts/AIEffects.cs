using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEffects : MonoBehaviour
{
    ParticleSystem AIparticle;
    bool isPlaying = false;
    float period = 0f;
    // Start is called before the first frame update
    void Start()
    {
        AIparticle = GetComponent<ParticleSystem>();
       
    }

    void Update()
    {
        if (isPlaying)
        {
            if (period > 1)
            {
                AIEffect();
                period = 0;
            }
            period += UnityEngine.Time.deltaTime;
        }
        
        
    }  

    public void AIEffect()
    {
        
            isPlaying = true;
            var sh = AIparticle.shape;
            sh.radius = Random.Range(0, 3);
            
        

    }
    public void FinishAITalk()
    {
        isPlaying = false;
    }

    public IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
