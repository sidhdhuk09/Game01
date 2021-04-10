using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;       //in order to display timer and enemy counter        
using UnityEngine.SceneManagement;  //in order to transition between scenes using a controller


public class GameController : MonoBehaviour
{
    
    
    public static GameController instance; //using implementation of a singleton in order to create an instance of "instance"   
    public GameObject demonContainer, hudContainer, gameOverPanel;  
    public Text demonCounter, timeCounter, countdownText;   
    public bool gamePlaying { get; private set; }   
    public int countdownTime;   
    private int numTotalDemons, numSlayedDemons;    
    private float startTime, elapsedTime;
    
    TimeSpan timePlaying;

    
    private void Awake()
    {
        
        instance = this; //assings instance to a public static object
    }

    
    private void Start()
    {
         
        numTotalDemons = demonContainer.transform.childCount; //counts no of total demons in the game
      
        numSlayedDemons = 0;        
        demonCounter.text = "Demons: 0 / " + numTotalDemons; //initializes demon counter      
        timeCounter.text = "Time: 00:00.00"; //initializes time counter       
        gamePlaying = false;       
        StartCoroutine(CountdownToStart()); //initialies coroutine i.e IEnumerator 
    }

   
    private void BeginGame()
    {gamePlaying = true;
     startTime = Time.time;
    }

    
    private void Update()
    {
        
       if (gamePlaying)
        {
            
            elapsedTime = Time.time - startTime;           
            timePlaying = TimeSpan.FromSeconds(elapsedTime); //generate a timer in order to calculate and iterate time                      
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff"); // eg:- 55:03:71            
            timeCounter.text = timePlayingStr; // sets the time counter to the string timeplayingSTR in that format
        }
    }

    
    public void SlayDemon()
    {        
        numSlayedDemons++;        
        string demonCounterStr = "Demons: " + numSlayedDemons + " / " + numTotalDemons;//creates a format in order to display demon counter     
        demonCounter.text = demonCounterStr;        
        if (numSlayedDemons >= numTotalDemons) //to check if all the enemies have been defeate
        {
            
            EndGame();
        }
    }

    
    private void EndGame()
    {        
        gamePlaying = false; //game no longer continues after the gameplaying statew turns to false        
        Invoke("ShowGameOverScreen", 1.25f); //calls gameover screen after 1.25 seconds. we use f as it is a float value
    }

    
    private void ShowGameOverScreen()
    {       
        gameOverPanel.SetActive(true);       
        hudContainer.SetActive(false);       
        string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");       
    }

   
   IEnumerator CountdownToStart()
    /*
     * IEnumerator  is an interface that defines one method, GetEnumerator which returns an IEnumerator interface. This allows readonly access to a collection then a collection that implements IEnumerable can be used with a for-each statement.
     * */
    
    {
        
        while (countdownTime > 0)
        {           
            countdownText.text = countdownTime.ToString();           
            yield return new WaitForSeconds(1f);//returns exactly 1 second           
            countdownTime--;
        }        
        BeginGame();       
    }
   
    
    public void OnButtonLoadLevel(string levelToLoad) 
    {
        
        SceneManager.LoadScene(levelToLoad); //loads scene
    }
}
