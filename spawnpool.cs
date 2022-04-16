using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnpool : MonoBehaviour
{
    private void Start()
    {
        Instantiate(spawnPool[0], new Vector3(Random.Range(-2.5f, 2.5f), 5.55f, 0), Quaternion.identity);
    }

    public GameObject[] spawnPool = new GameObject[2];

    public void Spawner()
    {
        float randomvalue = Random.value;
        if (randomvalue <= 0.65)
        {
            Instantiate(spawnPool[0], new Vector3(Random.Range(-2.5f, 2.5f), 5.55f, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(spawnPool[1], new Vector3(Random.Range(-2.5f, 2.5f), 5.55f, 0), Quaternion.identity);
        }
    }
}
