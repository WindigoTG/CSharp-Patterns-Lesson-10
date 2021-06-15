using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleVM : IPaddleVM
{
    IPaddleModel _paddleModel;

    public event Action<Vector3> OnPositionChange;
    public event Action<Vector3, Quaternion> OnAiming;
    public event Action<Vector3, Quaternion, float> OnLaunchBall;
    public event Action<Vector3> OnBallPositionChange;

    private bool _isBallReady = true;

    public PaddleVM(IPaddleModel paddleModel)
    {
        _paddleModel = paddleModel;
    }

    public void ChangePosition(float position)
    {
        _paddleModel.ChangePosition(position);
        OnPositionChange?.Invoke(_paddleModel.Position);
        if (_isBallReady)
            OnBallPositionChange?.Invoke(_paddleModel.LaunchPosition);
    }

    public void Aiming()
    {
        if (_isBallReady)
        {
            _paddleModel.Aiming();
            OnAiming.Invoke(_paddleModel.LaunchPosition, _paddleModel.LaunchRotation);
        }
    }

    public void LaunchBall()
    {
        if (_isBallReady)
        {
            OnLaunchBall?.Invoke(_paddleModel.LaunchPosition,
                            _paddleModel.LaunchRotation,
                            _paddleModel.LaunchForce);
            _isBallReady = false;
        }
    }

    public void ResetBall()
    {
        _isBallReady = true;
    }
}
