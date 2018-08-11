using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float rotateSpeed = 20;
    public float moveSpeed = 5;

    [SerializeField]
    private GameObject loseCanvas;
    [SerializeField]
    private GameObject winCanvas;
    [SerializeField]
    private UnityEngine.UI.Button winButton;

    private bool lost;
    private bool won;
    private CharacterController controller;

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        winButton.onClick.AddListener(Win);
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (lost || won)
            return;
        Vector3 rotation = new Vector3(0, Input.GetAxis("Horizontal")*rotateSpeed, 0);
        Vector3 translation = Input.GetAxis("Vertical")*moveSpeed*transform.forward;

        transform.Rotate(rotation);
        controller.SimpleMove(translation);
    }

    public void Lose () {
        loseCanvas.SetActive(true);
        lost = true;
    }

    public void Win () {
        winCanvas.SetActive(true);
        won = true;
    }
}
