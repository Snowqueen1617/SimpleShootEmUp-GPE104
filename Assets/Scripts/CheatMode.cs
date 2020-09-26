using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatMode : MonoBehaviour
{
 
    // Update is called once per frame
    public void Update()
    {
        GameManager.instance.score += 10;
        
    }
    
}
