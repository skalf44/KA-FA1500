﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Rota
    {
        public double[] t = new double[3];
        public double[] co = new double[3];
        public double fitness;

        public void fitnessHesapla()
        {
            fitness = t[1] + t[2];
        }

    }
}
