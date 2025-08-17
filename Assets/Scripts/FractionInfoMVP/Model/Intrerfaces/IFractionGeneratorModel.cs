using Data.NewFraction;

public interface IFractionGeneratorModel
{ 
    void GenerateFractions();
    Fraction GetFractionByIndex(int index);
}