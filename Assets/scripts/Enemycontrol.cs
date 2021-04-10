using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class Enemycontrol : MonoBehaviour
{
    public int hitpoint; //everytime enemy gets hit, we want to decrement the value by 1 so if the decrement hits 0 then the enemy dies
    public int maxhitpoint;
    public Animator myAnimator;
    public Healthbar healthbar;
    private void Start()
    {
       // hitpoint = maxhitpoint;
      
        
        myAnimator = GetComponent<Animator>(); //myanimator is an animation component and we attach it to the animator in ordet to play animations
    }

        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")  //we're checking to see if the tag of the object is a bullet
        {
            hitpoint--;
            if (hitpoint <= 0)
            {
                StartCoroutine(KillDemon()); 
            }
        }
    }
    IEnumerator KillDemon()
    {
        
        GetComponent<Collider2D>().enabled = false;//disables demon's collidor so that no other object can interact with it upon death state        
        GameController.instance.SlayDemon();//calls slaydemon function using singleton method       
        myAnimator.SetTrigger("Kill Demon");//triggers deamon death animation       
        AnimatorStateInfo deathAnimState = myAnimator.GetCurrentAnimatorStateInfo(0);//gets info about current animation state       
        yield return new WaitForSeconds(deathAnimState.length);       
        Destroy(gameObject);
    }
}
