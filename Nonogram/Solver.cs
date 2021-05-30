using System;
using System.Collections.Generic;
using System.Text;

namespace Nonogram
{
    
    public class Solver
    {
        private List<List<int>> columnRequirements;
        private List<List<int>> rowRequirements;
        private int width;
        private int height;
        private bool[,] board;

        public Solver(List<List<int>> columnRequirements, List<List<int>> rowRequirements, int width, int height)
        {
            this.columnRequirements = columnRequirements;
            this.rowRequirements = rowRequirements;
            this.width = width;
            this.height = height;
            board = new bool[width, height];
            for (int i = 0; i < board.Rank; i++)
            {
                for (int j = 0; j < board.GetLength(i); j++)
                {
                    board[i, j] = false;
                }
            }
        }

        public bool[,] solve()
        {
            if (FindSolution(0, 0))
            {
                return board;
            }

            return null;
        }

        private bool FindSolution(int i, int j)
        {
            if (i == height)
            {
                return true;
            }

            int nextI = i + (j + 1 == width ? 1 : 0);
            int nextJ = (j + 1) % width;

            // прво пробуваме дека е точно полето
            board[i, j] = true;
            if(verify(i, j) && FindSolution(nextI, nextJ))
            {
                return true;
            }

            // ако не е можно точно, пробуваме грешно
            board[i, j] = false;
            if (verify(i, j) && FindSolution(nextI, nextJ))
            {
                return true;
            }

            // ако не е можно и грешно завршуваме
            return false;
        }

        private bool verify(int i, int j)
        {
            return verifyColumn(columnRequirements[j], height, i, j) && verifyRow(rowRequirements[i], width, j, i);
        }

        private bool verifyColumn(List<int> requirements, int maxLength, int length, int j)
        {
            int k = 0;
            int acc = 0;
            bool isLast = false;
            for(int i=0; i<=length; i++)
            {
                if(board[i, j])
                {
                    acc++;
                    if(!isLast)
                    {
                        if(k >= requirements.Count)
                        {
                            return false;
                        }
                    }
                    isLast = true;
                } 
                else
                {
                    if(isLast)
                    {
                        if(requirements[k] != acc)
                        {
                            return false;
                        }
                        acc = 0;
                        k++;
                    }
                    isLast = false;
                }
            }

            if (length == maxLength - 1)
            {
                if (isLast)
                {
                    return k == requirements.Count - 1 && acc == requirements[k];
                }
                else
                {
                    return k == requirements.Count;
                }
            }
            else
            {
                if (isLast)
                {
                    return acc <= requirements[k];
                }
            }

            return true;
        }

        private bool verifyRow(List<int> requirements, int maxLength, int length, int j)
        {
            int k = 0;
            int acc = 0;
            bool isLast = false;
            for (int i = 0; i <= length; i++)
            {
                if (board[j, i])
                {
                    acc++;
                    if (!isLast)
                    {
                        if (k >= requirements.Count)
                        {
                            return false;
                        }
                    }
                    isLast = true;
                }
                else
                {
                    if (isLast)
                    {
                        if (requirements[k] != acc)
                        {
                            return false;
                        }
                        acc = 0;
                        k++;
                    }
                    isLast = false;
                }
            }

            if (length == maxLength - 1)
            {
                if (isLast)
                {
                    return k == requirements.Count - 1 && acc == requirements[k];
                }
                else
                {
                    return k == requirements.Count;
                }
            }
            else
            {
                if (isLast)
                {
                    return acc <= requirements[k];
                }
            }

            return true;
        }
    }
}
