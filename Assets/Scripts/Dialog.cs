using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//*** Controls introduction text, and takes and stores player's name. ***//

public class Dialog : MonoBehaviour
{
    [SerializeField] private string[] introText;
    [SerializeField] private int index;
    [SerializeField] private TextMeshProUGUI dialog;
    [SerializeField] private GameObject[] campers; // <- camper ncp responeses 
    [SerializeField] private GameObject playerName;
    [SerializeField] private GameObject startGame; // <- button for Gameplay scene

    // Start is called before the first frame update
    void Start()
    {
        dialog.text = introText[index];
    }

    //Gets value from input felid and assigns to the player pref
    public void NameInput()
    {
        PlayerPrefs.SetString("name", playerName.GetComponent<TMP_InputField>().text);

        Debug.Log(PlayerPrefs.GetString("name", "default"));        
    }

    //Progesses the (intro) consuler's text
    public void ChangeText()
    {
        //runs intro dialog and npc responses
        if (playerName.activeInHierarchy == false)
        {    
            //Consuler/Intro Text
            dialog.text = introText[index];
            if (index < introText.Length - 1)
            {
                index++;
            }

            //checks to run the camp ncp responses
            if (index >= 2)
            {
                StartCoroutine(turnOnText(index - 2));
            }

            if(index == 5)
            {
                playerName.SetActive(true);
                startGame.SetActive(true);
            }
        }
    }    

    //Sets a timer for campers' text pop ups
    IEnumerator turnOnText(int i)
    {        
        //pops on text        
        yield return new WaitForSeconds(Random.Range(.1f, 2f));
        campers[i].SetActive(true);
        
        //closes pop up        
        yield return new WaitForSeconds(Random.Range(1f, 2f));
        campers[i].SetActive(false);
    }    
}
