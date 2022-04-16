using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speed : MonoBehaviour
{
    public float timestart = 13;
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(DragReducerInterval());
        rb.drag = 5;
    }

    void update()
    {
        timestart -= Time.deltaTime;
        Debug.Log("timestart");
    }

    IEnumerator DragReducerInterval()
    {
        while (true) // in the documentation you'll see for(;;)
        {
            yield return new WaitForSeconds(1);
            // your logic here
            rb.drag -= 0.3f;
            Debug.Log(rb.drag);
        }
    }
}