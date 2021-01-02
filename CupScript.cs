using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupScript : MonoBehaviour

{

    //parameter

    [SerializeField] float yPositionOfCup = -4.67f;
    [SerializeField] float movementClampLeftSide = -6.24f;
    [SerializeField] float movementClampRightSide = 6.22f;
    void Update()
    {
        Vector2 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mouseposition.x, yPositionOfCup);

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, movementClampLeftSide, movementClampRightSide), transform.position.y);
    }
}
