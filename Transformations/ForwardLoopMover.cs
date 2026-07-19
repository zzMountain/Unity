using UnityEngine;

public sealed class ForwardLoopMover : MonoBehaviour
{
    private const float DefaultSpeed = 2f;
    private const float DefaultDistance = 5f;
    private const float MinDistance = 0.01f;

    [SerializeField] private float _speed = DefaultSpeed;
    [SerializeField] private float _distance = DefaultDistance;

    private Vector3 _startPosition;
    private float _traveledDistance;

    private void Awake()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        float step = _speed * Time.deltaTime;
        Vector3 offset = transform.forward * step;

        transform.position += offset;
        _traveledDistance += Mathf.Abs(step);

        if (_traveledDistance >= Mathf.Max(_distance, MinDistance))
        {
            transform.position = _startPosition;
            _traveledDistance = 0f;
        }
    }
}
