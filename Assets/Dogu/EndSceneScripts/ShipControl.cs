using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class ShipControl : MonoBehaviour
{
    public GameObject canvas;
    public GameObject endCanvas;
    public GameObject ship;
    bool canPlay = false;
    bool failed = false;

    Rigidbody rb;
    public GameObject RedLight;
    public TextMeshPro speed;
    float speedText;

    public Material pqueenMat;

    public GameManager gameManager;
    public Transform startPoint;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            spawner();
        }

        if (Input.GetKeyDown(KeyCode.P) && failed == false){
            canPlay = true;
            canvas.SetActive(false);
        }

        if (canPlay)
        {
            this.gameObject.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            this.gameObject.transform.GetComponent<Rigidbody>().freezeRotation = true;

            this.gameObject.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;


            if (Input.GetKeyDown(KeyCode.Space))
            {
                RedLight.SetActive(true);
                Debug.Log("Basıldı");
                rb.AddForce(transform.up * 20f, ForceMode.Impulse);
                GaveRandomRotation();
            }
            else
            {
                RedLight.SetActive(false);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.DORotate(transform.localEulerAngles + new Vector3(0, 0, 10f), 0.5f);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.DORotate(transform.localEulerAngles + new Vector3(0, 0, -10f), 0.5f);
            }

            speedText = Mathf.Abs(rb.velocity.magnitude);
            speed.text = "" + System.Math.Round(speedText, 1);
            if (speedText <= 10f)
            {
                speed.DOColor(Color.white, 1f);

            }
            else if (speedText > 10f && speedText < 19f)
            {
                speed.DOColor(Color.red, 1f);
            }
            else if (speedText >= 20f)
            {
                //Destroy(this.gameObject);
                ship.SetActive(false);
                GetComponent<BoxCollider>().enabled = false;
                canPlay = false;
                failed = true;
                endCanvas.SetActive(true);
                this.gameObject.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            }
        }

        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))  // dik gelmesi gerek
        {
            Debug.Log("Victory");         
            gameManager.GetComponent<GameManager>().victory();
            spawner();
            gameObject.GetComponent<MeshRenderer>().material = pqueenMat;
            //load scene
        }
    }
    public void GaveRandomRotation()
    {
        transform.DORotate(transform.localEulerAngles + new Vector3(0, 0, UnityEngine.Random.Range(-30, +30)), 0.5f);
    }


    void spawner()
    {

        ship.SetActive(true);
        GetComponent<BoxCollider>().enabled = true;

        endCanvas.SetActive(false);

        transform.position = startPoint.transform.position;
        transform.rotation = startPoint.transform.rotation;

        canPlay = true;
        failed = false;
    }

}
