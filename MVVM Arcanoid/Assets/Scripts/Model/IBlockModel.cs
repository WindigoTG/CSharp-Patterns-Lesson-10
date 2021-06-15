using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBlockModel
{
    public Color Color { get; }
    public bool IsActive { get; }
    public void InitializeColor();
    public void GetHit();
}
