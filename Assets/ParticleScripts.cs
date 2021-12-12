using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScripts : MonoBehaviour
{
    private void OnEnable()
    {
        Destroy(this.gameObject,3);
    }
}
