public interface IAlignmentCalculator
{
    float CalculateTargetY(float currentY, float itemHeight);
    int CalculateCenterIndex(float containerY, float containerHeight, float itemHeight, int itemCount);
}