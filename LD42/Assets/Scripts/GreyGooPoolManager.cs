using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyGooPoolManager : MonoBehaviour {

    public static Queue<GameObject> greyGooQueue = new Queue<GameObject>();
    public static GameObject staticGreyGooPrefab;

    public GameObject greyGooPrefab;

    public int numberToEnqueue;

    // Use this for initialization
    void Start () {
        staticGreyGooPrefab = greyGooPrefab;
        EnqueueMoreGameObjects(numberToEnqueue);
    }

    void Update () {
        if (greyGooQueue.Count < numberToEnqueue) {
            EnqueueMoreGameObjects(numberToEnqueue - greyGooQueue.Count);
        }
    }

    public static void EnqueueMoreGameObjects (int amount) {
        for (int i = 0; i < amount; i++) {
            GameObject gObject = Instantiate(staticGreyGooPrefab);
            gObject.SetActive(false);
            greyGooQueue.Enqueue(gObject);
        }
    }

    public static GameObject InstantiateFromQueue (Vector3 position, Quaternion rotation) {
        GameObject gObject;
        if (greyGooQueue.Count < 2)
            gObject = greyGooQueue.Dequeue();
        else
            gObject = Instantiate(staticGreyGooPrefab);

        gObject.SetActive(true);
        gObject.transform.position = position;
        gObject.transform.rotation = rotation;

        return gObject;
    }

}
