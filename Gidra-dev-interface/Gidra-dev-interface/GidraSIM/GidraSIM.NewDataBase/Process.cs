using System.Collections.Generic;

namespace GidraSIM.NewDataBase
{
    class Process
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Property> properties { get; set; }
        public List<Resource> resources { get; set; }
    }
}
