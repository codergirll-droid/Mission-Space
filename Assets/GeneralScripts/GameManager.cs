using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using DialogueEditor;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("VCams")]
    //public CinemachineVirtualCamera capsuleVCam;
    public CinemachineVirtualCamera compVCam;
    public CinemachineVirtualCamera roomVCam;
    public CinemachineVirtualCamera playerVCam;

    [Header("Comp Screen")]
    public RawImage compScreen;

    [Header("Textures")]
    public RenderTexture capsuleTexture;
    public RenderTexture meteorTexture;

    [Header("Player")]
    public GameObject player;

    [Header("Mini Games")]
    public GameObject capsuleGame;
    public GameObject meteorGame;

    public bool canTalk = false;
    public List<NPCConversation> dialogues;


    public bool isPlaying = false;


    // Start is called before the first frame update
    void Start()
    {

        disablePlayerControls();
        camstoEqualPri();
        //roomToPlayerCam(true);
        shutDownComputer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //roomToComputerCam(true);
            //roomToPlayerCam(true);
            playerToComputerCam(true);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            openMeteorMiniGame();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            openCapsuleMiniGame();
        }



        if (canTalk && isPlaying == false)
        {
            if(dialogues.Count == 0)
            {
                canTalk = false;
                return;
            }
            else
            {
                ConversationManager.Instance.StartConversation(dialogues[0]);
                dialogues.RemoveAt(0);
                canTalk = false;
            }

            
        }


    }




    #region CAMERA CONTROLS

    public void resetCameras()
    {
        roomVCam.Priority = 0;
        compVCam.Priority = 0;
        //capsuleVCam.Priority = 0;
        playerVCam.Priority = 0;
    }



    public void camstoEqualPri()
    {
        roomVCam.Priority = 1;
        compVCam.Priority = 0;
        //capsuleVCam.Priority = 0;
        playerVCam.Priority = 0;
    }

    public void roomToPlayerCam(bool isRoom)
    {
        resetCameras();

        if (isRoom)
        {
            roomVCam.Priority = 0;
            compVCam.Priority = 0;
            //capsuleVCam.Priority = 0;
            playerVCam.Priority = 1;
            enablePlayerControls();
        }
        else
        {
            roomVCam.Priority = 1;
            compVCam.Priority = 0;
            //capsuleVCam.Priority = 0;
            playerVCam.Priority = 0;
            disablePlayerControls();
        }
    }

    public void playerToComputerCam(bool isPlayer)
    {
        resetCameras();

        if (isPlayer)
        {
            roomVCam.Priority = 0;
            compVCam.Priority = 1;
            //capsuleVCam.Priority = 0;
            playerVCam.Priority = 0;

            disablePlayerControls();

        }
        else
        {
            roomVCam.Priority = 0;
            compVCam.Priority = 0;
            //capsuleVCam.Priority = 0;
            playerVCam.Priority = 1;

            enablePlayerControls();
        }
    }

    public void roomToComputerCam(bool isRoom)
    {
        resetCameras();

        if (isRoom)
        {
            roomVCam.Priority = 0;
            compVCam.Priority = 1;
            //capsuleVCam.Priority = 0;
            playerVCam.Priority = 0;

            disablePlayerControls();
        }
        else
        {
            roomVCam.Priority = 1;
            compVCam.Priority = 0;
           //capsuleVCam.Priority = 0;
            playerVCam.Priority = 0;

            disablePlayerControls();

        }
    }

    #endregion

    #region MINI GAME SYSTEM

    public void shutDownComputer()
    {
        compScreen.color = Color.black;
        meteorGame.SetActive(false);
        capsuleGame.SetActive(false);
    }

    public void openCapsuleMiniGame()
    {
        isPlaying = true;
        compScreen.color = Color.white;
        compScreen.texture = capsuleTexture;
        meteorGame.SetActive(false);
        capsuleGame.SetActive(true);
    }

    public void openMeteorMiniGame()
    {
        isPlaying = true;
        compScreen.color = Color.white;
        compScreen.texture = meteorTexture;
        meteorGame.SetActive(true);
        capsuleGame.SetActive(false);
    }


    public void victory()
    {
        isPlaying = false;
        canTalk = true;
        playerToComputerCam(false);
        shutDownComputer();

    }


    #endregion

    #region CONTROL PLAYER CONTROLS
    public void enablePlayerControls()
    {
        player.GetComponent<PlayerController>().canControlPlayer = true;
    }

    public void disablePlayerControls()
    {
        player.GetComponent<PlayerController>().canControlPlayer = false;

    }

    #endregion

    #region DIALOGUE


    public void startDialog()
    {
        roomToPlayerCam(true);
        StartCoroutine(wait(15f));
    }


    public void endOfDialog()
    {
        StartCoroutine(wait(Random.Range(15,20)));

    }

    //OYUN BİTİŞİ ÇAĞIR
    public IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
        canTalk = true;
    }

    public void endGame()
    {
        SceneManager.LoadScene("EndGame");
    }

    


    #endregion

}
