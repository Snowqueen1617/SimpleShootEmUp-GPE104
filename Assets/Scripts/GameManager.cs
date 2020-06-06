using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;
    
    public GameObject player;

    void Awake() //happens before start function
    {
        if(instance == null) //if nothing has been assigned to instance yet, assign
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //hold on to the data of this object when loading a new scene
        }
        else
        {
            Destroy(this.gameObject); //there is, destroy the game object
            UnityEngine.Debug.LogError("[GameManager] Attempted to create a second game manager: " + this.gameObject.name);
        }
    }
}
