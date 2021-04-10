using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class MainMenuController : MonoBehaviour
{
    public GameObject mainScreen;

   
    public Button playButton, backButton; //buttons for the controller in order to navigate the menu

    
    private void Start()
    {
        
        playButton.Select();
    }

    
    public void OnButtonPlayGame()
    {
        
        SceneManager.LoadScene(1);
    }

    
    public void OnButtonAboutGame()
    {
        
        mainScreen.SetActive(false); //disable the main active scene

       
      

        
        backButton.Select();
    }

    
    public void OnButtonBack()
    {
        // Enables the main screen
        //mainScreen.SetActive(true);

        
        

        // Selects the play button for use with a game controller
        playButton.Select();
    }

    
    public void OnButtonQuit()
    {
        // Closes the game
        Application.Quit();
    }
}
