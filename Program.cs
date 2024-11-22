using System;
using System.Collections.Generic;

namespace GeometryLibrary
{
    public enum FigureType
    {
        Circle,
        Triangle
    }

    public interface IFigure
    {
        FigureType Type { get; }
        double CalculateArea();
    }

    public class Circle : IFigure
    {
        public double Radius { get; }

        public FigureType Type => FigureType.Circle;

        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Радиус круга должен быть положительным числом.");
            }
            Radius = radius;
        }

        public double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }

    public class Triangle : IFigure
    {
        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }

        public FigureType Type => FigureType.Triangle;

        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException("Стороны треугольника должны быть положительными числами.");
            }
            if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
            {
                throw new ArgumentException("Сумма любых двух сторон треугольника должна быть больше третьей стороны.");
            }

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public double CalculateArea()
        {
            double p = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }

        public bool IsRightAngledTriangle()
        {
            double[] sides = { SideA, SideB, SideC };
            Array.Sort(sides);
            return Math.Pow(sides[2], 2) == Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2);
        }
    }

    public static class Geometry
    {
        public static double CalculateArea(IFigure figure)
        {
            return figure.CalculateArea();
        }
    }
}
