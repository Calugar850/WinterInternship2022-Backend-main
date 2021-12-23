namespace SantaClauseConsoleApp
{
    public class Item
    {
        int item_id;
        string name;
        
        public Item(int item_id, string name)
        {
            Item_id = item_id;
            Name = name;
        }

        public int Item_id { get; set; }

        public string Name { get; set; }
    }
}
