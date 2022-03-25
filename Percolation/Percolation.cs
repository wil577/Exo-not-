using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public class Percolation
    {
        private readonly bool[,] _open;
        private readonly bool[,] _full;
        private readonly int _size;
        private bool _percolate;

        public Percolation(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), size, "Taille de la grille négative ou nulle.");
            }

            _open = new bool[size, size];
            _full = new bool[size, size];
            _size = size;
        }

        private bool IsOpen(int i, int j)
        {
            if (_open[i, j] == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsFull(int i, int j)
        {
            if (_full[i, j] == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Percolate()
        {
            List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>();
            int a = 0;

            for (int j = 0; j < _size - 1; j++)
            {
                for (int i = 0; i < _size - 1; i++)
                {
                    if (IsOpen(i, j) == true)
                    {
                        list = CloseNeighbors(i, j);
                    }
                }
            }

            foreach (KeyValuePair<int, int> item in list)
            {
                _full[item.Key, item.Value] = true;
            }

            for (int k = 0; k < _size-1; k++)
            {
                if (IsFull(_size-1, k) == true)
                {
                    a++;
                }
            }  
            if(a > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<KeyValuePair<int, int>> CloseNeighbors(int i, int j)
        {
            List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>(); 

                if(IsOpen(i + 1,j))
                {
                    list.Add(new KeyValuePair<int, int>(i + 1,j));
                }
                if (IsOpen(i - 1, j))
                {
                    list.Add(new KeyValuePair<int, int>(i - 1, j));
                }
                if (IsOpen(i, j + 1))
                {
                    list.Add(new KeyValuePair<int, int>(i, j + 1));
                }
                if (IsOpen(i, j - 1))
                {
                    list.Add(new KeyValuePair<int, int>(i, j - 1));
                }

            return list;
        }

        private void Open(int i, int j)
        {

            throw new NotImplementedException();
        }
    }
}
