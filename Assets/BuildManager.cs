using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public GameObject bulletTurret;
    GameObject turretToBuild;

    public static BuildManager Instance { get; private set; }

    void Awake()
    {
        if (Instance)
        {
            Debug.LogWarning("More than one BuildManager in scene!");
            return;
        }

        Instance = this;
    }

    void Start()
    {
        turretToBuild = bulletTurret;
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
