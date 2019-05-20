using System.Collections.Generic;

namespace GidraSIM.NewDataBase
{
    public class Process
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Property> Properties { get; set; }
        public List<Resource> Resources { get; set; }
    }
}
