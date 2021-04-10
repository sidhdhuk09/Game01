using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musiccontroller : MonoBehaviour
{ 
 private static musiccontroller _instance;
public static musiccontroller instance;


private void Awake()
{
    if (_instance != null && _instance != this) //using singleton method so that we can call the instance of the music variable at the start of the menu itself
    {
        Destroy(gameObject);
        return;
    }
    else
    {
        _instance = this;
    }
    instance = _instance;

    
    DontDestroyOnLoad(this); //music will be present throughout the loading screens
}
}