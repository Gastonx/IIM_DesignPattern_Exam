using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour, IItem
{
    public string itemName { get => _item;  }

    [SerializeField] string _item = "Key";



}
