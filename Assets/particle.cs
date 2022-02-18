using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(start());
    }

    // Update is called once per frame
    IEnumerator start() 
    {
        gameObject.GetComponent<ParticleSystem>().Play();
        yield  return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
