using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float rotateSpeed = 20;
    public float moveSpeed = 5;

    private CharacterController controller;

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        Vector3 rotation = new Vector3(0, Input.GetAxis("Horizontal")*rotateSpeed, 0);
        Vector3 translation = Input.GetAxis("Vertical")*moveSpeed*transform.forward;

        transform.Rotate(rotation);
        controller.SimpleMove(translation);
    }
}
