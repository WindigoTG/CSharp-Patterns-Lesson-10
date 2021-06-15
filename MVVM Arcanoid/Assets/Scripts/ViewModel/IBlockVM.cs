using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IBlockVM
{
    public Color InitializeColor();
    public void GetHit();
    event Action<Color> OnHit;
    event Action OnBreak;
}
