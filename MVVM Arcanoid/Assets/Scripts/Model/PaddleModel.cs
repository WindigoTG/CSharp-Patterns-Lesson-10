using UnityEngine;

public class PaddleModel : IPaddleModel
{
    private Vector3 _position = new Vector3(0, -5.25f, 0);
    private float _boundX = 2.0f;
    private Vector3 _launchPosition;
    private Vector3 _launchRotation = Vector3.zero;
    private float _aimingSpeed = 100.0f;
    private float _launchSpeed = 10;

    public Vector3 Position => _position;

    public Vector3 LaunchPosition => _launchPosition;

    public Quaternion LaunchRotation => Quaternion.Euler(_launchRotation);

    public float LaunchForce => _launchSpeed;

    public void Aiming()
    {
        _launchRotation = new Vector3(0, 0, Mathf.PingPong(Time.time* _aimingSpeed, 90) - 45);
    }

    public void ChangePosition(float position)
    {
        if (position > -_boundX && position < _boundX)
            _position = new Vector3(position, _position.y, _position.z);
        else if(position < -_boundX)
            _position = new Vector3(-_boundX, _position.y, _position.z);
        else if (position > _boundX)
            _position = new Vector3(_boundX, _position.y, _position.z);
        _launchPosition = new Vector3(_position.x, _position.y + 0.5f, _position.z);
    }

    public void ResetAiming()
    {
        _launchRotation = Vector3.zero;
    }
}
