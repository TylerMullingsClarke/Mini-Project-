using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project.Model
{
    public interface ISorter
    {
        string SortName { get; }
        int[] Sort(int[] nums);
    }
}
