using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int rows = 1;
        int columns = 1;
        Stack<Tuple<int, int>> undoStack = new Stack<Tuple<int, int>>();
        Stack<Tuple<int, int>> redoStack = new Stack<Tuple<int, int>>();

        while (true)
        {
            int move = int.Parse(Console.ReadLine());
            int x;
            bool canMove = false;

            if (move == 11)
            {
                break;
            }
            else if (move == 9 && undoStack.Count > 0)
            {
                Tuple<int, int> temp = new Tuple<int, int>(rows, columns);
                rows = undoStack.Peek().Item1;
                columns = undoStack.Peek().Item2;
                redoStack.Push(temp);
                undoStack.Pop();
                continue;
            }
            else if (move == 10 && redoStack.Count > 0)
            {
                Tuple<int, int> temp = new Tuple<int, int>(rows, columns);
                rows = redoStack.Peek().Item1;
                columns = redoStack.Peek().Item2;
                undoStack.Push(temp);
                redoStack.Pop();
                continue;
            }
            else if (move != 9 && move != 10)
            {
                x = int.Parse(Console.ReadLine());
                canMove = CheckMove(move, rows, columns, x);

                if (!canMove)
                {
                    continue;
                }

                Tuple<int, int> temp = new Tuple<int, int>(rows, columns);
                undoStack.Push(temp);
                Move(move, ref rows, ref columns, x);
                while (redoStack.Count > 0)
                {
                    redoStack.Pop();
                }
            }
        }

        Console.WriteLine(Convert.ToChar(columns - 1 + 'A') + " " + rows);
    }

    static bool CheckMove(int action, int rows, int columns, int x)
    {
        if (action == 1)
        {
            if (rows + x <= 8)
            {
                return true;
            }
        }
        else if (action == 2)
        {
            if (rows + x <= 8 && columns - 1 > 0)
            {
                return true;
            }
        }
        else if (action == 3)
        {
            if (columns - x > 0)
            {
                return true;
            }
        }
        else if (action == 4)
        {
            if (rows - x > 0 && columns - x > 0)
            {
                return true;
            }
        }
        else if (action == 5)
        {
            if (rows - x > 0)
            {
                return true;
            }
        }
        else if (action == 6)
        {
            if (rows - x > 0 && columns + x <= 8)
            {
                return true;
            }
        }
        else if (action == 7)
        {
            if (columns + x <= 8)
            {
                return true;
            }
        }
        else if (action == 8)
        {
            if (rows + x <= 8 && columns + x <= 8)
            {
                return true;
            }
        }

        return false;
    }

    static void Move(int action, ref int rows, ref int columns, int x)
    {
        if (action == 1)
        {
            rows += x;
        }
        else if (action == 2)
        {
            rows += x;
            columns -= x;
        }
        else if (action == 3)
        {
            columns -= x;
        }
        else if (action == 4)
        {
            rows -= x;
            columns -= x;
        }
        else if (action == 5)
        {
            rows -= x;
        }
        else if (action == 6)
        {
            rows -= x;
            columns += x;
        }
        else if (action == 7)
        {
            columns += x;
        }
        else if (action == 8)
        {
            rows += x;
            columns += x;
        }
    }
}
