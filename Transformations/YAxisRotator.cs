using UnityEngine;

public sealed class YAxisRotator : MonoBehaviour
{
    private const float DefaultDegreesPerSecond = 90f;

    [SerializeField] private float _degreesPerSecond = DefaultDegreesPerSecond;

    private void Update()
    {
        float rotationStep = _degreesPerSecond * Time.deltaTime;

        transform.Rotate(Vector3.up, rotationStep, Space.Self);
    }
}
