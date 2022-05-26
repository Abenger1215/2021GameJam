using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapWorldObject : MonoBehaviour
{
    public Sprite Icon;
    public Color IconColor = Color.white;
    public string Text;
    public int Textsize = 10;

    private void Start()
    {
        MiniMap.Instance.RegisterMiniMapWorldObject(this);
    }
}
