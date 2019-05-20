using System.Collections.Generic;

namespace GidraSIM.NewDataBase
{
    public class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Property> Properties { get; set; }
    }
}
