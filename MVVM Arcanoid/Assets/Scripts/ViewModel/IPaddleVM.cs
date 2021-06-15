using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IPaddleVM
{
    public void ChangePosition(float position);
    public void Aiming();
    public void LaunchBall();
    public void ResetBall();

    event Action<Vector3> OnPositionChange;
    event Action<Vector3> OnBallPositionChange;
    event Action<Vector3, Quaternion> OnAiming;
    event Action<Vector3, Quaternion, float> OnLaunchBall;
}
