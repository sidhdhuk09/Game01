using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{

    public float playerspeed;
    private Rigidbody2D rb;
    private Vector2 leftstickinput;
    private Vector2 Rightstickinput;
    public GameObject laserprefab;
    public Transform firepoint;
    public float timebetweenbullets;
    private bool canshoot;// true or false
    
    public static float healthAm;//oublic static used to be accessable in other scripts
    

    // Start is called before the first frame update
    void Start()
    {
        healthAm = 1;
        canshoot = true;//so tthat we can shoot on program run
        rb = GetComponent<Rigidbody2D>(); //going to call get component function. will return rigidbody
    
    }
    
    // Update is called once per frame
    void Update()
    {
       
        if (GameController.instance.gamePlaying)
        {
            
            GetPlayerInput();
        }
        else
        {
            
            leftstickinput = Vector2.zero; //values are set to zero so that the play does not move due to internal deadstick drit
            Rightstickinput = Vector2.zero;
        }
        if (healthAm <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void GetPlayerInput()
    {
        
        leftstickinput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); //vector2 is a constructor which will give coordinates to horzontal and vertical axis
        Rightstickinput = new Vector2(Input.GetAxis("R_Horizontal"), Input.GetAxis("R_Vertical"));
        if(Input.GetButton("shoot") && canshoot) // it will check if we're holding down the shoot button so the code will be called only when we can shoot and we're holding down the shoot button
                {
            shoot();
        }
    }
    private void shoot()
    {
        canshoot = false;//as soon as we fire a shot,can shoot will set to false to allow for time delay

        Instantiate(laserprefab,firepoint.position,transform.rotation);
        StartCoroutine(shotcooldown());// will call the asyncronous function IEnumerator 
    }
    IEnumerator shotcooldown()
    {
        yield return new WaitForSeconds(timebetweenbullets);
        canshoot = true;
    }

    private void FixedUpdate() //called on a fixed time. doesn't depend on framerate.
    {
        Vector2 currentmovement = leftstickinput * playerspeed * Time.deltaTime; //normalizes values.
        rb.MovePosition(rb.position + currentmovement);
        if(Rightstickinput.magnitude> 0.0f)//when the stick is idle, the magnitute is 0. when we move it then it'll increment
        {
            Vector3 currentrotation = Vector3.left * Rightstickinput.x + Vector3.up * Rightstickinput.y; //this will assign to the x rotation of current rotation to leftstick.x 
            Quaternion playerrotation = Quaternion.LookRotation(currentrotation, Vector3.forward); //quaternion is how unity calculates rotation so we assign a variable to quaternion and we pass currentroation in it so that we can rotate the player using the right joystick.
            rb.SetRotation(playerrotation);
        }
        //healthAm = 0.1f;
    }
}
