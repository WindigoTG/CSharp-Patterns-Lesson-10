using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockView : MonoBehaviour
{
    private IBlockVM _blockVM;
    private Material _material;

    void Start()
    {
        _blockVM = new BlockVM(new BlockModel());
        _material = GetComponent<MeshRenderer>().material;
        _material.color = _blockVM.InitializeColor();
        _blockVM.OnHit += OnHit;
        _blockVM.OnBreak += OnBreak;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _blockVM.GetHit();
    }

    private void OnHit(Color color)
    {
        _material.color = _blockVM.InitializeColor();
    }

    private void OnBreak()
    {
        gameObject.SetActive(false);
    }
    ~BlockView()
    {
        _blockVM.OnHit -= OnHit;
        _blockVM.OnBreak -= OnBreak;
    }
}
