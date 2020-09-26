using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.spawnPointList.Add(transform);
    }

    private void OnDestroy()
    {
        GameManager.instance.spawnPointList.Remove(transform);
    }
}
