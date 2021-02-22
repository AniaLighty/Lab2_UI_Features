using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//*** Controls the player move buttons, dialog, and NPC dialog pop ups. ***//

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float walkSpeed;
    [SerializeField] private SpriteRenderer sr; // <- player sprite render
    [SerializeField] bool isColiding;
    [SerializeField] GameObject npcCamper;
    [SerializeField] GameObject[] Campers; // <- set in the inspector
    [SerializeField] TextMeshProUGUI[] dialog; // <- storys camper npc dialog
    [SerializeField] private string[] words;  // <- set in the inspector

    //Player left button
    public void LeftMove()
    {
        Vector2 move = new Vector2(transform.position.x - walkSpeed, transform.position.y);

        sr.flipX = true;
        if(move.x > -8.5)
        {
            transform.position = move;
        }
    }

    //Player right button
    public void RightMove()
    {
        Vector2 move = new Vector2(transform.position.x + walkSpeed, transform.position.y);

        sr.flipX = false;

        if (move.x < 8.5)
        {
            transform.position = move;
        }
    }

    //Shows NPC dialog
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isColiding = true;
        npcCamper = collision.gameObject;
    }

    //Closes NPC dialog
    private void OnTriggerExit2D(Collider2D collision)
    {
        isColiding = false;       

        for(int i = 0; i < dialog.Length; i++)
        {
            dialog[i].text = "";
        }
    }

    //NPC camper dialog
    public void Interact()
    {
        if(isColiding == true)
        {
            if(npcCamper == Campers[0])
            {
                dialog[0].text = "Hi " + PlayerPrefs.GetString("name", "default") + " is this your first year too?";
            }
            else if (npcCamper == Campers[1])
            {
                dialog[1].text = "Your name is " + PlayerPrefs.GetString("name", "default") + " right? Mine is Summer.";
            }
            else if (npcCamper == Campers[2])
            {
                dialog[2].text = "Can't wait to start collecting badges!";
            }
            else if (npcCamper == Campers[3])
            {
                dialog[3].text = "I love this camp!";
            }
        }
    }
}
