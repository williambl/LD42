using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    CharacterController controller;

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        float rotation = Input.GetAxis("Horizontal");
        float translation = Input.GetAxis("Vertical");
        transform.Rotate(new Vector3(0, rotation, 0));
        controller.Move(new Vector3(0, 0, translation));
    }
}
