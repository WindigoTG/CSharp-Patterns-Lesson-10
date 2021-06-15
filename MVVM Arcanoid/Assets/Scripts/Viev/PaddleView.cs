using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleView : MonoBehaviour
{
    private IPaddleVM _paddleVM;
    private Camera _camera;
    private Transform _ball;
    private Rigidbody _ballRB;

    [SerializeField] Transform _aiming;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        _paddleVM = new PaddleVM(new PaddleModel());
        _paddleVM.OnPositionChange += OnPositionChange;
        _paddleVM.OnAiming += OnAiming;
        _paddleVM.OnLaunchBall += OnLaunchBall;
        _paddleVM.OnBallPositionChange += OnBallPositionChange;
        _ball = FindObjectOfType<SphereCollider>().transform;
        _ballRB = _ball.GetComponent<Rigidbody>();
        _aiming.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        _paddleVM.ChangePosition(_camera.ScreenToWorldPoint(Input.mousePosition - _camera.transform.position).x);

        if (Input.GetMouseButton(0))
            _paddleVM.Aiming();
        if (Input.GetMouseButtonUp(0))
            _paddleVM.LaunchBall();
    }

    private void OnPositionChange(Vector3 position)
    {
        transform.position = position;
    }

    private void OnAiming(Vector3 position, Quaternion rotation)
    {
        _aiming.gameObject.SetActive(true);
        _aiming.position = position;
        _aiming.rotation = rotation;
    }

    private void OnLaunchBall(Vector3 position, Quaternion rotation, float force)
    {
        _aiming.gameObject.SetActive(false);
        _ball.position = position;
        _ball.rotation = rotation;
        _ballRB.AddForce(_ball.up * force, ForceMode.Impulse);
    }

    private void OnBallPositionChange(Vector3 position)
    {
        _ballRB.velocity = Vector3.zero;
        _ball.position = position;
    }

    private void OnTriggerEnter(Collider other)
    {
        _paddleVM.ResetBall();
    }

    ~PaddleView()
    {
        _paddleVM.OnPositionChange -= OnPositionChange;
        _paddleVM.OnAiming -= OnAiming;
        _paddleVM.OnLaunchBall -= OnLaunchBall;
        _paddleVM.OnBallPositionChange -= OnBallPositionChange;
    }
}
