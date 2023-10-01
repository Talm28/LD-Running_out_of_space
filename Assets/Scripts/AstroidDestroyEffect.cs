using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidDestroyEffect : MonoBehaviour
{
    ParticleSystem particleSystem;

    void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
        particleSystem.enableEmission = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestoryEffect());
    }

    IEnumerator DestoryEffect()
    {
        particleSystem.enableEmission = true;
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
}
