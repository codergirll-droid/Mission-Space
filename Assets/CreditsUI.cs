using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsUI : MonoBehaviour
{

    public GameObject CreditsScreenUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreditsTrue()
    {
        CreditsScreenUI.SetActive(true);
    }
    public void CreditsFalse()
    {
        CreditsScreenUI.SetActive(false);
    }
}
