using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    public float speed;
    Vector3 movevector;
    public float live;
    public GameObject ExplosionPrefab;
    // Start is called before the first frame update
    private void Start()
    {
        movevector = Vector3.up * speed * Time.deltaTime; //bullet instantiates on game start
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Translate(movevector);//moves the bullet by manipulating the transform coordinates in the inspector
    }
    private void OnCollisionEnter2D(Collision2D collision) //this gets called automatically
    {
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity); //when the explosion hits the wall, the explosion, on contact with the wall, starts the explosion timer which will decrement by the second,thus triggering the expolsion.
        Destroy(gameObject); //lower case g which destroys the gameobject
    }

    IEnumerator destroyblast() //coroutine= functions that work asynchoniously with your code.
    {
        yield return new WaitForSeconds(live); //once this function is called it returns to where we were before.
        Destroy(gameObject);
    }

}
