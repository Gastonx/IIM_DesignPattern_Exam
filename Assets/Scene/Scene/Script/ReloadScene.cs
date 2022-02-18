using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
   public void reloadScene(string name) 
    {
        SceneManager.LoadScene(name);
    
    }
}
