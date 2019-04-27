using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
[CreateAssetMenu(menuName = "LD/ItemAsset", fileName = "ItemAsset")]
public class ItemAsset : ScriptableObject
{
    public enum ItemType
    {
        Distraction,
        Focus
    }
    
    public Sprite sprite;
    public ItemType itemType;
    public float value;
}
