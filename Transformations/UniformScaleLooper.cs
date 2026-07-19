using UnityEngine;

public sealed class UniformScaleLooper : MonoBehaviour
{
    private const float DefaultGrowthSpeed = 1f;
    private const float DefaultMaxScaleMultiplier = 2f;
    private const float MinScaleMultiplier = 0.1f;
    private const float BaseScaleMultiplier = 1f;
    private const float PingPongLength = 1f;

    [SerializeField] private float _growthSpeed = DefaultGrowthSpeed;
    [SerializeField] private float _maxScaleMultiplier = DefaultMaxScaleMultiplier;

    private Vector3 _startScale;

    private void Awake()
    {
        _startScale = transform.localScale;
    }

    private void Update()
    {
        float maxScaleMultiplier = Mathf.Max(_maxScaleMultiplier, MinScaleMultiplier);
        float scaleProgress = Mathf.PingPong(Time.time * _growthSpeed, PingPongLength);
        float scaleMultiplier = Mathf.Lerp(BaseScaleMultiplier, maxScaleMultiplier, scaleProgress);

        transform.localScale = _startScale * scaleMultiplier;
    }
}
