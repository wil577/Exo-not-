using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    class Program
    {
        static void Main(string[] args)
        {
            Percolation p = new Percolation(6);
            p.Percolate();
            PercolationSimulation p2 = new PercolationSimulation();
            p2.PercolationValue(6);
        }
    }
}
