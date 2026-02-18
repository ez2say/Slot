using UnityEngine;

public class AlignmentCalculator : IAlignmentCalculator
{
    public float CalculateTargetY(float currentY, float itemHeight)
    {
        var remainder = currentY % itemHeight;
        return remainder < itemHeight / 2
            ? currentY - remainder
            : currentY - remainder + itemHeight;
    }

    public int CalculateCenterIndex(float containerY, float containerHeight, float itemHeight, int itemCount)
    {
        var centerIndex = Mathf.FloorToInt((containerY + containerHeight / 2) / itemHeight);
        return Mathf.Clamp(centerIndex, 0, itemCount - 1);
    }
}