using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project.Model
{
    public class BubbleSorter : ISorter
    {
        public int[] Sort(int[] nums) 
        {
                int[] arrnums = { 4, 2, 6, 5, 9, 8 }; //Setting the array and its numbers
                for (int i = 0; i < arrnums.Length - 1; i++) //set a starting point at the start of the arrays length,
                                                         //then to go to i minus one so we dont go outside the boundaries of the array
                {
                    for (int j = 0; j < arrnums.Length - 1; j++)
                    {
                        if (arrnums[j] > arrnums[j + 1])
                        {
                            int tmp = arrnums[j];
                            arrnums[j] = arrnums[j + 1];
                            arrnums[j + 1] = tmp;
                        }
                    }
                }
                for (int i = 0; i < arrnums.Length; i++)
                {
                    Console.WriteLine(arrnums[i]);
                }
                return arrnums;
            }
        }
    }
}
