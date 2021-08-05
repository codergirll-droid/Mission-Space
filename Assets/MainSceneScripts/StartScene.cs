using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class StartScene : MonoBehaviour
{

    public NPCConversation myConversation;
    // Start is called before the first frame update
    void Start()
    {

        ConversationManager.Instance.StartConversation(myConversation);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    




}
