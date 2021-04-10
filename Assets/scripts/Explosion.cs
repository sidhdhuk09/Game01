using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]    // makes sure that this is accessing the animator compnonet imbeded in the gameobject "blueexplosion"
public class Explosion : MonoBehaviour
{
    private Animator myAnimator;        // Animator component of this GameObject

  
    private void Start()
    {
        // Gets the Animator component attached to this GameObject
        myAnimator = GetComponent<Animator>();

        
        StartCoroutine(DestroyExplosion()); //initiates the timer that will destroy the explosion
    }

   
    IEnumerator DestroyExplosion() //destroies the explosion once the animation is complete
    {
        
        AnimatorStateInfo explosionState = myAnimator.GetCurrentAnimatorStateInfo(0);

       
        yield return new WaitForSeconds(explosionState.length); //returns explosion

       
        Destroy(gameObject);
    }
}
