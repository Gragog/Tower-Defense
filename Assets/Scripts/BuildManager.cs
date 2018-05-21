using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {


    public static BuildManager Instance { get; private set; }
    public static GameObject Shop { get; private set; }

    void Awake()
    {
        if (Instance)
        {
            Debug.LogWarning("More than one BuildManager in scene!");
            return;
        }

        Instance = this;

        // ==============================

        if (Shop)
        {
            Debug.LogWarning("More than one Shop in scene!");
            return;
        }

        Shop = GameObject.FindGameObjectWithTag("Shop");
        if (!Shop.HasComponent<Shop>())
            Debug.LogError("Shop is not a shop!");
    }
}
