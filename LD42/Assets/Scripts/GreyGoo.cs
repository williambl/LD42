using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyGoo : MonoBehaviour {

    public float secondsUntilDoubled = 5;

    private float lastDoubleTime = 0;
    private ParticleSystem particleSystem;
    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        particleSystem = GetComponent<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        if (Time.time > lastDoubleTime + secondsUntilDoubled) {
            var emission = particleSystem.emission;
            var main = particleSystem.main;
            emission.rateOverTime = emission.rateOverTime.constant * 6/(transform.localScale.x/2);
            main.startSize = main.startSize.constant * 2;

            audioSource.volume *= 2;

            transform.localScale *= 2;

            lastDoubleTime = Time.time;
        }
    }

    void OnTriggerEnter (Collider other) {
        if (other.tag == "Player") {
            other.GetComponent<Player>().Lose();
        }
    }

}
