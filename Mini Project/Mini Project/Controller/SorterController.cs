﻿using Mini_Project.Model;
using Mini_Project.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project.Controller
{
    public class SorterController
    {
        private int[] _array;
        public ISorter Sorter { get; private set; }

        public SorterController(ISorter sorter, int arrayLength) {
            Sorter = sorter;
            _array = ArrayGenerator.NewRandom(arrayLength);
        }

        public void DisplayArray() {
            foreach (var item in _array) {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        public void DisplayArraySorted() {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var sortedArr = Sorter.Sort(_array);
            stopwatch.Stop();
            foreach (var item in sortedArr) {
                Console.Write($"{item} ");
            }
            Console.WriteLine($"\n\nTime taken to sort: {stopwatch.Elapsed.TotalMilliseconds}ms");
        }
    }
}