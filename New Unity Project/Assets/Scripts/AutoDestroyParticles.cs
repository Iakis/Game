using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyParticles : MonoBehaviour
{
    ParticleSystem ps;

	void Awake ()
    {
        ps = GetComponent<ParticleSystem>();
	}
	
	void Update ()
    {
        if (ps && !ps.IsAlive(true))
            Destroy(gameObject);
	}
}
