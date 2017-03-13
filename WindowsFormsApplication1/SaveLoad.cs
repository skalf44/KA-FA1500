﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace WindowsFormsApplication1
{
    class SaveLoad
    {
        public int num_rows, num_cols;
        public String[,] dataset;
        public void Save(string filename, List<Gemi> gemiler)
        {
            string path = @"" + filename;
            string veriler = "";
            StreamWriter sW = new StreamWriter(path);
            for (int i = 0; i < gemiler.Count; i++)
            {
                veriler += gemiler.ElementAt(i).emniyet_alani + ";" + gemiler.ElementAt(i).hiz + ";" + gemiler.ElementAt(i).rota + ";" + gemiler.ElementAt(i).merkez.X + ";" + gemiler.ElementAt(i).merkez.Y;
                sW.WriteLine(veriler);
                veriler = "";
            }

            sW.Close();
            string fullPath = Path.GetFullPath(path);
            MessageBox.Show("Çıktı text dosyası " + fullPath + " konumuna kaydedilmiştir.");
        }
        public int[,] Load(string filename)
        {
            string whole_file = System.IO.File.ReadAllText(filename);
            whole_file = whole_file.Replace('\n', '\r');
            string[] lines = whole_file.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);

            num_rows = lines.Length;
            num_cols = lines[0].Split(';').Length;

            string[,] values = new string[num_rows, num_cols];
            for (int r = 0; r < num_rows; r++)
            {
                string[] line_r = lines[r].Split(';');
                for (int c = 0; c < num_cols; c++)
                {
                    values[r, c] = line_r[c];
                }
            }
            datasetGoster(values);
            return toInt(values, num_rows, num_cols);
        }

        public void datasetGoster(string[,] _values)
        {
            for (int i = 0; i < num_rows; i++)
            {
                for (int j = 0; j < num_cols; j++)
                {
                    Console.Write(_values[i, j] + ";");
                }
                Console.WriteLine("");
            }
        }
        private int[,] toInt(string[,] _dataset, int _num_rows, int _num_cols)
        {
            int[,] intset = new int[_num_rows, _num_cols];
            for (int i = 0; i < num_rows; i++)
            {
                for (int j = 0; j < num_cols; j++)
                {
                    intset[i, j] = Convert.ToInt32(_dataset[i, j]);
                }
            }
            return intset;
        }
    }
}