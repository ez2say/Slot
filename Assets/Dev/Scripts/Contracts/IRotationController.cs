using System;

public interface IRotationController
{
    void StartSpin(float targetSpeed, float duration);
    void StopSpin(float duration, Action onComplete);
    float CurrentSpeed { get; }
    bool IsSpinning { get; }
}