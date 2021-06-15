using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockVM : IBlockVM
{
    private IBlockModel _blockModel;

    public BlockVM(IBlockModel blockModel)
    {
        _blockModel = blockModel;
    }

    public event Action<Color> OnHit;
    public event Action OnBreak;

    public void GetHit()
    {
        _blockModel.GetHit();
        OnHit?.Invoke(_blockModel.Color);
        if (!_blockModel.IsActive)
            OnBreak?.Invoke();
    }

    public Color InitializeColor()
    {
        _blockModel.InitializeColor();
        return _blockModel.Color;
    }
}
