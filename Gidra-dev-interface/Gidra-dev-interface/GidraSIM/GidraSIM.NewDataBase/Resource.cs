using System.Collections.Generic;

namespace GidraSIM.NewDataBase
{
    class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Property> properties { get; set; }
    }
}
