using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyGoo : MonoBehaviour {

    public float secondsUntilSplit = 1;

    public GameObject prefab;

    // Use this for initialization
    void Start () {
        StartCoroutine(Duplicate());
    }

    // Update is called once per frame
    void Update () {

    }

    IEnumerator Duplicate () {
        for (int i = 0; i < 20; i++) {
            yield return new WaitForSeconds(secondsUntilSplit);
            Instantiate(prefab, transform.position, transform.rotation);
        }
    }
}
