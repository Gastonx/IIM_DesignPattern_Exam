using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleDoor : MonoBehaviour
{
    public int OnCount = 0;

    public void ToggleOn() 
    {
      OnCount++;
        CheckCount();
    }
    
    public void ToggleOff() 
    {
        OnCount--;
        CheckCount();
    }

    private void CheckCount() 
    {

        if (OnCount == 3)
        {
            gameObject.SetActive(false);
        }
    
    }
}
