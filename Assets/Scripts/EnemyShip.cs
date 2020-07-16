using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    private Vector3 targetPosition;
    public float enemySpeed;
    // Start is called before the first frame update

    private void OnDestroy()
    {
        GameManager.instance.enemyList.Remove(this.gameObject);
    }

    void Start()
    {
        GameManager.instance.enemyList.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.player != null)
        {
            targetPosition = GameManager.instance.player.transform.position;
            Vector3 directionToLook = targetPosition - transform.position;
            directionToLook.Normalize();
            transform.position += directionToLook * enemySpeed * Time.deltaTime;
            //transform.right = directionToLook;
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(transform.right, transform.forward), rotationSpeed * Time.deltaTime);
        }

        else
        {
            Destroy(this.gameObject);
        }
    }
}
