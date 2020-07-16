using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform tf;
    public float turnSpeed = 100f; //Degrees per second
    public float moveSpeed = 5f; // Units per second
    public GameObject bulletPrefab;
    public float bulletSpeed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.player = this.gameObject;
        tf = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frameS
    void Update()
    {
        HandleRotation();
     
        if(Input.GetKey(KeyCode.UpArrow))
        {
            tf.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.Self);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        //TODO: Implement Shooting
        //UnityEngine.Debug.Log("Shooting not implemented yet");
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<Bullet>().bulletSpeed = bulletSpeed;
        Destroy(bullet, 4);
    }

    public void HandleRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            tf.Rotate(0, 0, turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            tf.Rotate(0, 0, -turnSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D otherObject)
    {
        //If the player runs into something, they should die
        Die();
    }

    void Die()
    {
        //TODO: Write death code here
        Debug.Log("Player Died");
        Destroy(this.gameObject);
        
    }

    void OnDestroy()
    {
        GameManager.instance.player = null;
    }
}
