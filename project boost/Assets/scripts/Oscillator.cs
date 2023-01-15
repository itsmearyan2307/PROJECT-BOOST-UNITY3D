using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    

    Vector3 startingPosition;

    [SerializeField] Vector3 movementVector;

    [SerializeField] float movementFactor;

    [SerializeField] float period = 2f;

    [SerializeField] float osclillatingSpeed = 2f;

    void Start()

    {

        startingPosition = transform.position;



    }



    // Update is called once per frame

    void Update()

    {



        movementFactor = Mathf.Sin((Time.time / period) * osclillatingSpeed) + 1;

        transform.position = startingPosition + (movementVector * movementFactor);



    }

}