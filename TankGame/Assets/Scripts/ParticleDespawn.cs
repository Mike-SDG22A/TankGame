using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDespawn : MonoBehaviour
{
    float particleTtl = 3;

    void Update()
    {
        particleTtl -= Time.deltaTime;
        if (particleTtl <= 0)
        {
            Destroy(gameObject);
        }
    }


}
