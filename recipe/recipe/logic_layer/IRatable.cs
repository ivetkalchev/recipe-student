using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_layer
{
    public interface IRatable
    {
        void SetRating(decimal rating);
        decimal GetRating();
        void DeleteRating();
        void EditRating(decimal newRating);
    }
}
