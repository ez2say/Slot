using DG.Tweening;
using System;

public class RotationController : IRotationController
{
    private float _currentSpeed;
    private bool _isSpinning;
    private Tween _spinTween;

    public float CurrentSpeed => _currentSpeed;
    public bool IsSpinning => _isSpinning;

    public void StartSpin(float targetSpeed, float duration)
    {
        _isSpinning = true;
        _spinTween?.Kill();
        _spinTween = DOTween.To(() => _currentSpeed, x => _currentSpeed = x, targetSpeed, duration)
            .SetEase(Ease.OutQuad);
    }

    public void StopSpin(float duration, Action onComplete)
    {
        _isSpinning = false;
        _spinTween?.Kill();
        _spinTween = DOTween.To(() => _currentSpeed, x => _currentSpeed = x, 0f, duration)
            .SetEase(Ease.InQuad)
            .OnComplete(() => onComplete?.Invoke());
    }
}