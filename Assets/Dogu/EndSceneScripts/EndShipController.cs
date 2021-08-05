using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

using DG.Tweening;


public class EndShipController : MonoBehaviour
{
    
    public  List<GameObject> astroids;
    public GameObject Portal;
    public PlayableDirector VictoryScene;
    public PlayableDirector LostScene;

    public Transform startPoint;

    public float speed = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("InstantiateAstorids", 1f, 0.5f);
        InvokeRepeating("InstantiatePortal",20f,20f);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        RenderSettings.skybox.SetFloat("_Rotation", Time.time * speed);


    }

    public void InstantiateAstorids()
    {
       GameObject clone =  Instantiate(astroids[UnityEngine.Random.Range(0, astroids.Count-1)], new Vector3(UnityEngine.Random.Range(transform.position.x - 5, transform.position.x +5), transform.position.y, transform.position.z + 30f), Quaternion.identity);
       Destroy(clone, 3f);
    }
    public void InstantiatePortal()
    {
        Instantiate(Portal, new Vector3(transform.position.x, transform.position.y, transform.position.z + 50f), transform.rotation * Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Astroid"))
        {
            LostScene.Play();
            transform.position = startPoint.transform.position;
            transform.rotation = startPoint.transform.rotation;
        }
        if (other.CompareTag("Portal"))
        {
            VictoryScene.Play();
        }
    }

    private void Movement()
    {
        transform.DOMoveZ(transform.position.z + 5f, 1f);

        if (Input.GetKey(KeyCode.D))
        {
            transform.DOMoveX(transform.position.x + 5f, 1f);
            StartCoroutine(RotationJob(-30));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.DOMoveX(transform.position.x - 5f, 1f);
            StartCoroutine(RotationJob(+30));

        }
    }

    public IEnumerator RotationJob(float angle1)
    {
        transform.DORotate(transform.eulerAngles + new Vector3(0, 0, angle1), 1f);
        yield return new WaitForSeconds(0.5f);
        transform.DORotate(Vector3.zero, 1f);
    }
    

    
}
