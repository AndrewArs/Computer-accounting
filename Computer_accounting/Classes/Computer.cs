using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_accounting
{
    public class Computer
    {
        public String id { get; set; }
        public int cpu_id { get; set; }
        public int memory_id { get; set; }
        public int motherboard_id { get; set; }
        public int graphics_id { get; set; }
        public int hard_drive_id { get; set; }
        public int keyboard_id { get; set; }
        public int monitor_id { get; set; }
        public int mouse_id { get; set; }

        public Computer()
        {

        }

        public Computer(String id, int cpu_id, int memory_id, int motherboard_id)
        {
            this.id = id;
            this.cpu_id = cpu_id;
            this.memory_id = memory_id;
            this.motherboard_id = motherboard_id;
        }

    }
}
