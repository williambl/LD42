using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyGoo : MonoBehaviour {

    public float secondsUntilDoubled = 5;
    public Player player;

    private float lastDoubleTime = 0;
    private ParticleSystem particleSystem;
    private AudioSource audioSource;

    private Vector3 lastScale;
    private float lastVolume;
    private float lastStartSize;
    private float lastRateOverTime;

    // Use this for initialization
    void Start () {
        particleSystem = GetComponent<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();

        lastScale = transform.localScale;
        lastVolume = audioSource.volume;
        lastStartSize = particleSystem.main.startSize.constant;
        lastRateOverTime = particleSystem.emission.rateOverTime.constant;
    }

    // Update is called once per frame
    void Update () {
        if (player.won)
            return;

        float lerpAmount = (Time.time-lastDoubleTime)/secondsUntilDoubled;
        Debug.Log(lerpAmount);

        var emission = particleSystem.emission;
        var main = particleSystem.main;
        emission.rateOverTime = Mathf.Lerp(lastRateOverTime, lastRateOverTime * 6/(transform.localScale.x/2), lerpAmount);
        main.startSize = Mathf.Lerp(lastStartSize, lastStartSize * 2, lerpAmount);

        audioSource.volume = Mathf.Lerp(lastVolume, lastVolume * 2, lerpAmount);

        transform.localScale = Vector3.Lerp(lastScale, lastScale * 2, lerpAmount);

        if (lerpAmount >= 1) {
            lastScale = transform.localScale;
            lastVolume = audioSource.volume;
            lastStartSize = particleSystem.main.startSize.constant;
            lastRateOverTime = particleSystem.emission.rateOverTime.constant;
            lastDoubleTime = Time.time;
        }
    }

    void OnTriggerEnter (Collider other) {
        if (other.tag == "Player") {
            other.GetComponent<Player>().Lose();
        }
    }

}
