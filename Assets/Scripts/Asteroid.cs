using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Transform tf; // A variable to hold our Transform component
    void Start()
    {
        // Get the Transform Component
        tf = GetComponent<Transform>();
    }
    void Update()
    {
        // Move up every frame draw by adding 1 to the y of our position
        tf.position = tf.position + ((Vector3.down * Time.deltaTime) * 3f);
    }

    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        UnityEngine.Debug.Log("Collided with something");
        UnityEngine.Debug.Log(otherObject.gameObject.name);
        if (otherObject.gameObject == GameManager.instance.player)
        {
            UnityEngine.Debug.Log("Ran into player game object");
            //This is what happens when a player hits an astroid
        }
    }

    private void OnCollisionExit2D(Collision2D otherObject)
    {
        UnityEngine.Debug.Log("I stopped colliding");
    }

    private void OnCollisionStay2D(Collision2D otherObject)
    {
        UnityEngine.Debug.Log("I'm still colliding with something");
    }
}
