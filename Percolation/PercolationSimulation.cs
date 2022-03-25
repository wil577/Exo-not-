using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public struct PclData
    {
        /// <summary>
        /// Moyenne 
        /// </summary>
        public double Mean { get; set; }
        /// <summary>
        /// Ecart-type
        /// </summary>
        public double StandardDeviation { get; set; }

        public double RelativeStd { get; set; }
    }

    public class PercolationSimulation
    {
        public PclData MeanPercolationValue(int size, int t)
        {

            throw new NotImplementedException();
        }

        public double PercolationValue(int size)
        {
            Percolation p = new Percolation(size);
            Random rnd = new Random();
            
            do
            {
                rnd.Next(0 ,size - 1);
                
                p.Percolate();
            }
            while (p.Percolate() != true);



            throw new NotImplementedException();
        }
    }
}
