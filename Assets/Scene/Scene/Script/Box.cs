using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, ITouchable
{
    public GameObject Potion;

    public void Touch(int power)
    {
        if (Random.Range(1,4) > 2) //spawn aleatoire d'une potion
        {
            Instantiate(Potion, gameObject.transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
