using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//*** Controls the slider for the player avater. ***//

public class PlayerSlect : MonoBehaviour
{
    [SerializeField] private Sprite[] player;
    [SerializeField] private int index;
    [SerializeField] private Slider playerCamper;
    [SerializeField] private SpriteRenderer sr;
    

    // Start is called before the first frame update
    void Start()
    {
        sr.sprite = player[PlayerPrefs.GetInt("player", 0)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickPlayer()
    {
        PlayerPrefs.SetInt("player", (int)playerCamper.value);
        sr.sprite = player[(int)playerCamper.value];
        
        Debug.Log("index is: " + index);
    }
}
