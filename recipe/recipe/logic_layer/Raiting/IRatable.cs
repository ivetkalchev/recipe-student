using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_layer.Raiting
{
    public interface IRatable
    {
        void AddRating(int userId, decimal rating);
        void RemoveRating(int userId);
        decimal GetAverageRating();
    }
}
