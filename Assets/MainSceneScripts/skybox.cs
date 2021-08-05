using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DialogueEditor;

public class skybox : MonoBehaviour
{
    public float speed = 1.2f;


    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * speed);

        if (ConversationManager.Instance != null)
        {   
             if (Input.GetKeyDown(KeyCode.Space))
                //ConversationManager.Instance.SelectNextOption();
                ConversationManager.Instance.PressSelectedOption();


        }




    }
}
