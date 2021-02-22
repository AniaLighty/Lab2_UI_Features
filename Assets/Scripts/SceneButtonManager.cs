using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//*** Controls the scene changing/advancing buttons ***//

public class SceneButtonManager : MonoBehaviour
{  

   public void TitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void Introduction()
    {
        SceneManager.LoadScene("Intro");
    }

    public void Gameplay()
    {
        SceneManager.LoadScene("Game");
    }

    public void PlayerSelectScreen()
    {
        SceneManager.LoadScene("PlayerSelect");
    }   
}
