using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyGoo : MonoBehaviour {

    public float secondsUntilDoubled = 5;

    private float lastDoubleTime = 0;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        if (Time.time > lastDoubleTime + secondsUntilDoubled) {
            transform.localScale *= 2;
            lastDoubleTime = Time.time;
        }
    }

}
