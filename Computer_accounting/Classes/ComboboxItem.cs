using System;

namespace Computer_accounting
{
    class ComboboxItem
    {
        public String Text { get; set; }
        public int ID { get; set; }

        public ComboboxItem(int id, String text)
        {
            this.ID = id;
            this.Text = text;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
