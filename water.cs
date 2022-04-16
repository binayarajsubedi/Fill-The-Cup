using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    bool collidedwithcup = false;
    public spawnpool spawnerscript;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnItemOnInterval());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collidedwithcup = true;
    }

    // Update is called once per frame
    void Update()
    {
     if (collidedwithcup == true)
        {
            collidedwithcup = false;
           // spawnpoolcaller();
            Destroy(gameObject);
            
        }
    }

    void spawnpoolcaller()
    {
        spawnerscript.Spawner();
    }

    IEnumerator SpawnItemOnInterval()
    {
        while (true) // in the documentation you'll see for(;;)
        {
            yield return new WaitForSeconds(3);
            // your logic here
            spawnpoolcaller();
        }
    }

}
