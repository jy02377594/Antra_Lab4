using System;
using System.Linq.Expressions;

namespace Exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<int, bool>> filter = n => (n * 3) < 5;

            BinaryExpression lt = (BinaryExpression)filter.Body;
            BinaryExpression mult = (BinaryExpression)lt.Left;
            ParameterExpression en = (ParameterExpression)mult.Left;
            ConstantExpression three = (ConstantExpression)mult.Right;
            ConstantExpression five = (ConstantExpression)lt.Right;

            Console.WriteLine("({0} ({1} {2} {3}) {4})", lt.NodeType,
                     mult.NodeType, en.Name, three.Value, five.Value);


            Func<int, int> addOne = n => n + 1;
            Console.WriteLine("Result: {0}", addOne(5));

            Expression<Func<int, int>> addOneExpression = n => n + 1;

            var addOneFunc = addOneExpression.Compile();
            Console.WriteLine("Result: {0}", addOneFunc(5));

        }
    }
}
