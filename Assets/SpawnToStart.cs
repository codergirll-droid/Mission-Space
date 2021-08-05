using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnToStart : MonoBehaviour
{

    public GameObject Ship;
    public GameObject startPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnToStart1()
    {
        Ship.transform.position = startPoint.transform.position;
        Ship.transform.rotation = startPoint.transform.rotation;
    }
}
