using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyGoo : MonoBehaviour {

    public float secondsUntilSplit = 5;
    public float timesToSplit = 2;

    // Use this for initialization
    void Start () {
        StartCoroutine(Duplicate());
    }

    // Update is called once per frame
    void Update () {

    }

    IEnumerator Duplicate () {
        for (int i = 0; i < timesToSplit; i++) {
            yield return new WaitForSeconds(secondsUntilSplit);
            GameObject duplicate = GreyGooPoolManager.InstantiateFromQueue(transform.position, transform.rotation);
        }
        Destroy(GetComponent<Rigidbody>());    
    }
}
