using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockModel : IBlockModel
{
    private Color _color;
    private int _durability = 3;

    public Color Color => _color;

    public bool IsActive => _durability > 0;

    public void GetHit()
    {
        _durability--;
        _color = Color.Lerp(Color.red, _color, _durability / 3);
    }

    public void InitializeColor()
    {
        _color = Random.ColorHSV();
    }
}
