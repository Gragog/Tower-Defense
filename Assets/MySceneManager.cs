using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySceneManager : MonoBehaviour {

    [Range(0f, 10f)]
    public float timeScale = 1f;

    private void Start()
    {
        timeScale = 1f;
    }

    // Update is called once per frame
    void Update () {
        Time.timeScale = timeScale;
	}
}
