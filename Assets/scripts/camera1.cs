using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera1 : MonoBehaviour
{
    public Transform player;        //will allow us to manipulate the coordinates with reference to the player 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z); //calling Transform player to update x and y axis relative to the player
    }
}
