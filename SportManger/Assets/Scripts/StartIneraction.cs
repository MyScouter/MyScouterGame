using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class StartIneraction : MonoBehaviour
{
   
    private GameObject player;
    public NPCConversation myConverstion;
    private bool isClick;
    private bool showInteractMsg;

    private GUIStyle guiStyle;

    private string msg;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        isClick = true;
        setupGui();
    }

    public void OnCollisionStay(Collision other)
    {
       
        if (other.gameObject == player)     //player has collided with trigger
        {
            showInteractMsg = true;
            if (Input.GetKey(KeyCode.F) && isClick)
            {
                ConversationManager.Instance.StartConversation(myConverstion);
                isClick = false;
            }
        }
    }
    

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)     //player has exited trigger
        {
            
            //hide interact message as player may not have been looking at object when they left
            showInteractMsg = false;
            isClick = true;
        }
    }

    private void Update()
    {
      
       
    }


    #region GUI Config

    //configure the style of the GUI
    private void setupGui()
    {
        guiStyle = new GUIStyle();
        guiStyle.fontSize = 16;
        guiStyle.fontStyle = FontStyle.Bold;
        guiStyle.normal.textColor = Color.white;
        msg = "Press F to start conversation";
    }


    void OnGUI()
    {
        if (showInteractMsg)  //show on-screen prompts to user for guide.
        {
            GUI.Label(new Rect(50, Screen.height - 50, 200, 50), msg, guiStyle);
        }
    }
    #endregion

}