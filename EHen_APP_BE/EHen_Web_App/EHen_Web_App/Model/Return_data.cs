namespace EHen_Web_App.Model
{
    public class Return_data
    {
        public int Hierarchy_level { get; set; }
        public int Egg_count { get; set; }
        public int Hen_count { get; set; }
        public double Per_EggPrice { get; set; }  
        public List<int> Hens_ID { get; set; }
        public List<int> Egg_Count_perHen { get; set; }
    }

    public class Price_edit_data
    {
        public int id { get; set; }
        public double price { get; set; }
    }

    public class Return_withSTR
    { 
        public String Data { get; set; }
    }

    public class Add_hens_data
    {
        public int Hens_count { get; set; }
        public int Hierarchy_level { get; set; }

    }
}
