using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPaddleModel
{
    public Vector3 Position { get; }
    public Vector3 LaunchPosition { get; }
    public Quaternion LaunchRotation { get; }
    public float LaunchForce { get; }
    public void ChangePosition(float position);
    public void Aiming();
    public void ResetAiming();
}
