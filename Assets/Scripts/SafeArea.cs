using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D otherObject)
    {
        //If something goes outside the camera view, destroys it
        Destroy(otherObject.gameObject);

    }
}
