using System.Data;
using System.Data.SqlClient;
using EHen_Web_App.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using EHen_Web_App.DataLayer;

namespace EHen_Web_App.Service
{
    public class EHen_App_BusinessLayer
    {
        EHen_DataLayer DL= new EHen_DataLayer();
       


        public DataTable Pindex()
        {
            DataTable dt= new DataTable();
            dt = DL.Pindex_DL();
            return dt;

        }

        public String edit_price_index(int ID, double price)
        {
            
          int Rows_affected = DL.Edit_Pindex_DL(ID,price);
          if(Rows_affected> 0)
            {
                return "Updated Successfully";
            }
            else
            {
                return "Update Failed! Network Error Please try again";
            }

        }


        public List<Return_data> Get_Hens_detail(string Date=null)
        {
            DataSet ds=new DataSet();
            DataTable HenDT= new DataTable();
            DataTable HierarchyDT = new DataTable();
            double basePrice = 0;
            List<Return_data> list1 = new List<Return_data>();        
            try
            {
                if(Date!=null)
                ds = DL.Get_Hens_detail_DL(Date);
                else
                 ds = DL.Get_Hens_detail_DL();

                HierarchyDT = ds.Tables[1];
                HenDT = ds.Tables[2];
                basePrice = Convert.ToDouble(ds.Tables[0].Rows[0][0]);
                for(int i=0;i<HierarchyDT.Rows.Count;i++)
                {
                    int Egg_count_Temp = 0;
                    int Egg_count = 0;
                    int Hens_count = 0;
                    double Per_EggPrice = 0;
                    List<int> hens_Id = new List<int>();
                    List<int> Eggs_num_perHen= new List<int>();


                    Return_data Data1 = new Return_data();
                    for (int j=0;j<HenDT.Rows.Count;j++)
                    {
                       
                        if (Convert.ToInt16(HierarchyDT.Rows[i]["Hierarchy_level"]) == Convert.ToInt16(HenDT.Rows[j]["Hierarchy_level"])  + 1)
                        {
                            Egg_count_Temp = Egg_count_Temp + Convert.ToInt16(HenDT.Rows[j]["Egg_num"]);
                        }
                        if(Convert.ToInt16(HierarchyDT.Rows[i]["Hierarchy_level"])==1 && Convert.ToInt16(HenDT.Rows[j]["Hierarchy_level"])==1)
                        {
                            Egg_count_Temp = 0;
                        }

                        if (Convert.ToInt16(HierarchyDT.Rows[i]["Hierarchy_level"]) == Convert.ToInt16(HenDT.Rows[j]["Hierarchy_level"]))
                        {
                            Hens_count = Hens_count + 1;
                            Egg_count = Convert.ToInt16(HenDT.Rows[j]["Egg_num"]) + Egg_count;
                            hens_Id.Add(Convert.ToInt16(HenDT.Rows[j]["Hen_Id"]));
                            Eggs_num_perHen.Add(Convert.ToInt16(HenDT.Rows[j]["Egg_num"]));
                        }
                    }
                    Per_EggPrice = basePrice + Egg_count_Temp * basePrice * 0.01;

                    Data1.Per_EggPrice = Per_EggPrice;
                    Data1.Egg_count = Egg_count;
                    Data1.Hen_count = Hens_count;
                    Data1.Hierarchy_level =Convert.ToInt16( HierarchyDT.Rows[i]["Hierarchy_level"]);
                    Data1.Hens_ID = hens_Id;
                    Data1.Egg_Count_perHen = Eggs_num_perHen;

                    list1.Add(Data1);
                }

            }

            catch(Exception ex) { 
            
            }
            return list1;
        }


        public String Add_Hens(int Hierarchy_level, int Hens_count,bool New_Hierarchy=false)
        {

            int Rows_affected = DL.Add_Hens_DL(Hierarchy_level, Hens_count, New_Hierarchy);
            if (Rows_affected > 0)
            {
                return "Updated Successfully";
            }
            else
            {
                return "Update Failed! Network Error Please try again";
            }

        }

        public String Edit_Hens(int Hierarchy_level, int Hen_ID, int Egg_count=0)
        {

            int Rows_affected = DL.Edit_Hens_DL(Hierarchy_level, Hen_ID, Egg_count);
            if (Rows_affected > 0)
            {
                return "Updated Successfully";
            }
            else
            {
                if (Egg_count > 0)
                    return "Cannot add Eggs to a New hens on the day they appear you can add only on following days ";
                else
                return "Update Failed! Network Error Please try again";
            }

        }

    }
}
