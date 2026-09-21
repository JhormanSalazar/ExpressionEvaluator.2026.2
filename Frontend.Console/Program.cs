using Backend;

var infix = "4*5/(4+6)";
Console.WriteLine($"Infix = {infix}, Result = {ExpressionEvaluator.Evalute(infix):N5}"); // 2

var infix2 = "4*(5+6-(8/2^3)-7)-1";
Console.WriteLine($"Infix = {infix2}, Result = {ExpressionEvaluator.Evalute(infix2):N5}"); // 11

var infix3 = "4*7^(1/3)*7*((1+9)/3*7^4)";
Console.WriteLine($"Infix = {infix3}, Result = {ExpressionEvaluator.Evalute(infix3):N5}"); // 428,675.12518474100 

var infix4 = "144^(1/2)";
Console.WriteLine($"Infix = {infix4}, Result = {ExpressionEvaluator.Evalute(infix4):N5}"); // 12

var infix5 = "12+34";
Console.WriteLine($"Infix = {infix5}, Result = {ExpressionEvaluator.Evalute(infix5):N5}"); // 46

var infix6 = "100/10/2";
Console.WriteLine($"Infix = {infix6}, Result = {ExpressionEvaluator.Evalute(infix6):N5}"); // 5

var infix7 = "10-4-3";
Console.WriteLine($"Infix = {infix7}, Result = {ExpressionEvaluator.Evalute(infix7):N5}"); // 3

var infix8 = "1-2*3+4";
Console.WriteLine($"Infix = {infix8}, Result = {ExpressionEvaluator.Evalute(infix8):N5}"); // -1

var infix9 = "2^3^2";
Console.WriteLine($"Infix = {infix9}, Result = {ExpressionEvaluator.Evalute(infix9):N5}"); // 512

var infix10 = "0.5*4";
Console.WriteLine($"Infix = {infix10}, Result = {ExpressionEvaluator.Evalute(infix10):N5}"); // 2

var infix11 = "3.75+1.25";
Console.WriteLine($"Infix = {infix11}, Result = {ExpressionEvaluator.Evalute(infix11):N5}"); // 5

var infix12 = "25";
Console.WriteLine($"Infix = {infix12}, Result = {ExpressionEvaluator.Evalute(infix12):N5}"); // 25

var infix13 = "(3.1416+70)/(300^(1/3.2))";
Console.WriteLine($"Infix = {infix13}, Result = {ExpressionEvaluator.Evalute(infix13):N5}"); // 12.30450
