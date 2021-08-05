using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beam : MonoBehaviour
{
    public float bulletSpeed = 3f;
     GameObject player;

    private void Start()
    {
        player = GameObject.Find("ship");
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.up * bulletSpeed;
        
    }


    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Entered trigger");

        if (other.gameObject.tag.Equals("meteorPrefab"))
        {
            player.GetComponent<meteorShipControl>().shotCount++;
            Destroy(other.gameObject);
        }
    }

}
