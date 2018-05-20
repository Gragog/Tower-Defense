using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class DestroyEndedParticleSystem : MonoBehaviour {

    ParticleSystem system;

	// Use this for initialization
	void Start () {
        system = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (system.isStopped) Destroy(gameObject);
	}
}
