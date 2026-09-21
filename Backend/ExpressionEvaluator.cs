using System.Globalization;

namespace Backend;

public static class ExpressionEvaluator
{
    public static double Evalute(string infix) => EvalutePostfix(ToPostfix(Tokenize(infix)));

    private static List<string> Tokenize(string infix)
    {
        var tokens = new List<string>();
        var number = string.Empty;
        foreach (var item in infix)
        {
            if (char.IsDigit(item) || item == '.')
            {
                number += item; // build the full number
                continue;
            }
            if (number.Length > 0)
            {
                ValidateNumber(number);
                tokens.Add(number);
                number = string.Empty;
            }
            if (item == ' ')
            {
                continue;
            }
            if (IsOperator(item))
            {
                tokens.Add(item.ToString());
            }
            else
            {
                throw new Exception($"Invalid character: '{item}'.");
            }
        }
        if (number.Length > 0)
        {
            ValidateNumber(number);
            tokens.Add(number);
        }
        if (tokens.Count == 0)
        {
            throw new Exception("Invalid expression.");
        }
        return tokens;
    }

    private static void ValidateNumber(string number)
    {
        if (number.Count(c => c == '.') > 1)
        {
            throw new Exception($"Invalid number: '{number}'.");
        }
    }

    private static List<string> ToPostfix(List<string> tokens)
    {
        var posfix = new List<string>();
        var stack = new Stack<char>();
        foreach (var token in tokens)
        {
            if (token.Length == 1 && IsOperator(token[0]))
            {
                var item = token[0];
                if (item == ')')
                {
                    if (stack.Count == 0)
                    {
                        throw new Exception("Unbalanced parentheses.");
                    }
                    var ope = stack.Pop();
                    while (ope != '(')
                    {
                        posfix.Add(ope.ToString());
                        if (stack.Count == 0)
                        {
                            throw new Exception("Unbalanced parentheses.");
                        }
                        ope = stack.Pop();
                    }
                }
                else
                {
                    // pop while the stack has priority over the incoming operator
                    while (stack.Count != 0 && PriorityInfix(item) <= PriorityStack(stack.Peek()))
                    {
                        posfix.Add(stack.Pop().ToString());
                    }
                    stack.Push(item);
                }
            }
            else
            {
                posfix.Add(token);
            }
        }
        while (stack.Count != 0)
        {
            var ope = stack.Pop();
            if (ope == '(')
            {
                throw new Exception("Unbalanced parentheses.");
            }
            posfix.Add(ope.ToString());
        }
        return posfix;
    }

    private static int PriorityStack(char op) => op switch
    {
        '^' => 3,
        '*' => 2,
        '/' => 2,
        '+' => 1,
        '-' => 1,
        '(' => 0,
        _ => throw new Exception("Invalid expression."),
    };

    private static int PriorityInfix(char op) => op switch
    {
        '^' => 4,
        '*' => 2,
        '/' => 2,
        '+' => 1,
        '-' => 1,
        '(' => 5,
        _ => throw new Exception("Invalid expression."),
    };

    private static bool IsOperator(char item) => item == '^' || item == '*' || item == '/' || item == '+' || item == '-' || item == '(' || item == ')';

    private static double EvalutePostfix(List<string> postfix)
    {
        var stack = new Stack<double>();
        foreach (var token in postfix)
        {
            if (token.Length == 1 && IsOperator(token[0]))
            {
                var ope2 = stack.Pop();
                var ope1 = stack.Pop();
                stack.Push(Calculate(ope1, ope2, token[0]));
            }
            else
            {
                // use . as decimal separator
                stack.Push(double.Parse(token, CultureInfo.InvariantCulture));
            }
        }
        return stack.Pop();
    }

    private static double Calculate(double ope1, double ope2, char item) => item switch
    {
        '*' => ope1 * ope2,
        '/' => ope1 / ope2,
        '+' => ope1 + ope2,
        '-' => ope1 - ope2,
        '^' => Math.Pow(ope1, ope2),
        _ => throw new Exception("Invalid expression."),
    };
}
