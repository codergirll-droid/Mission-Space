using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class meteorShipControl : MonoBehaviour
{
    public GameObject mainManager;

    public GameObject endCanvas;
    public Transform startPoint;

    public float speed = 10f;
    public GameObject beam;
    public float bulletSpeed = 10f;
    public Transform beamPoint;
    private bool isInCooldown = false;


    public GameObject manager;
    public GameObject canvas;
    bool canStart = false;
    bool failed = false;

    bool hasWon = false;
    public int shotCount = 0;



    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(true);
        manager.GetComponent<MeteorGameManager>().canSpawn = false;

    }



    private void FixedUpdate()
    {
        if (canStart && failed == false)
        {
            canvas.SetActive(false);

            Movement();


            if (transform.position.x >= 4.4f)
                transform.position = new Vector3(4.3f, transform.position.y, transform.position.z);
            else if (transform.position.x <= -4.4f)
                transform.position = new Vector3(-4.3f, transform.position.y, transform.position.z);

            if (transform.position.y >= 4.4f)
                transform.position = new Vector3(transform.position.x, 4.3f, transform.position.z);
            else if (transform.position.y <= -4.4f)
                transform.position = new Vector3(transform.position.x, -4.3f, transform.position.z);
        }


       

       

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            spawner();
        }

        if(canStart && failed == false)
            Shoot();

        if (Input.GetKeyDown(KeyCode.P))
        {
            canStart = true;
            manager.GetComponent<MeteorGameManager>().canSpawn = true;
        }

        if(shotCount >= 10)
        {
            mainManager.GetComponent<GameManager>().victory();
        }

    }


    void Movement()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            //transform.DOMoveY(transform.position.y + 0.1f, 0.5f);
            transform.position += Vector3.up * speed;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            //transform.DOMoveY(transform.position.y - 0.1f, 0.5f);
            transform.position += Vector3.down * speed;

        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //transform.DOMoveX(transform.position.x + 0.1f, 0.5f);
            transform.position += Vector3.left * speed;

        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.DOMoveX(transform.position.x - 0.1f, 0.5f);
            transform.position += Vector3.right * speed;

        }

    }


    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isInCooldown)
            {
                GameObject a = Instantiate(beam, new Vector3(beamPoint.position.x, beamPoint.position.y, -1.145f), beamPoint.rotation);
                Destroy(a, 3f);
                Invoke("ResetCooldown", 1f);
                isInCooldown = true;
            }
            
        }

        
    }
    private void ResetCooldown()
    {
        isInCooldown = false;
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("meteorPrefab"))
        {
            endCanvas.SetActive(true);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            manager.GetComponent<MeteorGameManager>().canSpawn = false;

            canStart = false;
            failed = true;
        }
    }

    public void spawner()
    {
        transform.position = startPoint.transform.position;
        transform.rotation = startPoint.transform.rotation;
        endCanvas.SetActive(false);

        gameObject.GetComponent<MeshRenderer>().enabled = true;
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        manager.GetComponent<MeteorGameManager>().canSpawn = true;

        canStart = true;
        failed = false;
    }

}
