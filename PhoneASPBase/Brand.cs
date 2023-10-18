using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PhoneASPBase
{

    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Brand()
        {
                
        }
    }

}
