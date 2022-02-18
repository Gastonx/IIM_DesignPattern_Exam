using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemGetter : MonoBehaviour
{
   
    public UnityEvent Heal;
    public UnityEvent OpenGate;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var item = collision.GetComponent<IItem>();
        if (item != null && item.itemName == ("Key")) 
        {
            
            OpenGate.Invoke();
            Destroy(collision.transform.parent.gameObject);

        }
        else if(item != null && item.itemName == ("Potion"))
        {
            Heal.Invoke();
            Destroy(collision.transform.parent.gameObject);
        }
            
    }

    
}
