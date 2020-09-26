using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Vector3 directionToMove;
    //private Vector3 targetPosition;
    public float moveSpeed = 3f;

    private void OnDestroy()
    {
        GameManager.instance.enemyList.Remove(this.gameObject);
    }

    private void Start()
    {
        GameManager.instance.enemyList.Add(this.gameObject);
        directionToMove = GameManager.instance.player.transform.position - transform.position;
        directionToMove.Normalize();
        //targetPosition = GameManager.instance.player.transform.position - transform.position;
    }
    private void Update()
    {
        transform.position += directionToMove * moveSpeed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.player.transform.position, moveSpeed * Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        //transform.position = Vector3.Lerp(transform.position, targetPosition, 0.001f);

        if (GameManager.instance.player == null)
        {
            Destroy(this.gameObject);
        }    
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
