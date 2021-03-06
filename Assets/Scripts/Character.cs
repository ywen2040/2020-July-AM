﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
    public float MoveSpeed = 25;
    public float RotateSpeed = 10;
    public CharacterController characterController;

    private int totalScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Was Called");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update Was Called");

        //Gets the value of the horizontal axis -> -1 to 1 
        float horizontalValue = Input.GetAxis("Horizontal");
        //Rotates around the local Y axis 
        transform.Rotate(new Vector3(0, horizontalValue * RotateSpeed, 0));
        //Gets the value of the vertical axis -> -1 to 1 

        float verticalValue = Input.GetAxis("Vertical");
        //Moves around the local Z axis 
        characterController.SimpleMove(transform.forward * (MoveSpeed * verticalValue) );
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Hit a wall");
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        Collectible collectible = other.GetComponent<Collectible>();

        if (collectible != null)
        {
            totalScore = totalScore + collectible.score;
            Destroy(collectible.gameObject);
        }
        
        
        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Collided with a trigger wall");
        }
    }
}
