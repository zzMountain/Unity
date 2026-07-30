using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public sealed class CoroutineCounter : MonoBehaviour
{
    private const float TickIntervalSeconds = 0.5f;

    [SerializeField] private Text _counterText;

    private readonly WaitForSeconds _tickDelay = new WaitForSeconds(TickIntervalSeconds);

    private Coroutine _countingCoroutine;
    private int _value;

    private void Awake()
    {
        UpdateCounterText();
    }

    private void Update()
    {
        Mouse mouse = Mouse.current;

        if (mouse == null)
            return;

        if (mouse.leftButton.wasPressedThisFrame)
            ToggleCounting();
    }

    private void OnDisable()
    {
        if (_countingCoroutine == null)
            return;

        StopCoroutine(_countingCoroutine);
        _countingCoroutine = null;
    }

    private void ToggleCounting()
    {
        if (_countingCoroutine == null)
        {
            _countingCoroutine = StartCoroutine(CountRoutine());
        }
        else
        {
            StopCoroutine(_countingCoroutine);
            _countingCoroutine = null;
        }
    }

    private IEnumerator CountRoutine()
    {
        while (true)
        {
            yield return _tickDelay;

            _value++;
            UpdateCounterText();
        }
    }

    private void UpdateCounterText()
    {
        _counterText.text = _value.ToString();
    }
}
