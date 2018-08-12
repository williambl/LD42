using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public Button button;

    void Start () {
        button.onClick.AddListener(StartGame);
    }

    public void StartGame () {
        SceneManager.LoadSceneAsync(1);
    }
}
