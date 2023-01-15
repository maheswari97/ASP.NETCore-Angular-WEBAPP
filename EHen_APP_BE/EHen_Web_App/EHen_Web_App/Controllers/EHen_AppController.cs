using Microsoft.AspNetCore.Mvc;
using EHen_Web_App.Model;
using EHen_Web_App.Service;
using System.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using System.Globalization;

namespace EHen_Web_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class EHen_AppController : Controller
    {
        EHen_App_BusinessLayer BusinessLayer=new EHen_App_BusinessLayer();


        [HttpGet("Price_index")]
       
        public List<PIndex_data> Pindex_data()
        {
            List<PIndex_data> Pindex_List = new List<PIndex_data>();
           
            DataTable dat = BusinessLayer.Pindex();
            
            for(int i=0;i<dat.Rows.Count;i++)
            {
                PIndex_data Pindex=new PIndex_data();

                Pindex.Id=Convert.ToInt32(dat.Rows[i]["ID"]);
                Pindex.Date = Convert.ToDateTime(dat.Rows[i]["Date"]).ToString("dd MMMM yyyy");
                Pindex.Price = Convert.ToDecimal(dat.Rows[i]["price"]);

                Pindex_List.Add(Pindex);
            }
                return Pindex_List;

        }

        [HttpPost("Edit_Pindex")]

        public Return_withSTR Edit_Pindex(Price_edit_data Data)
        {
            Return_withSTR Ret = new Return_withSTR();
             Ret.Data   = BusinessLayer.edit_price_index(Data.id, Data.price);
            
            return Ret;
        }


        [HttpGet("Hens_details")]
        public List<Return_data> Get_HenData()
        {
            List<Return_data> Hens_List = new List<Return_data>();

            Hens_List= BusinessLayer.Get_Hens_detail();
            return Hens_List;

        }

        [HttpPost("Get_Hen_data_WithGivenDate")]

        public List<Return_data> Hen_data_WithGivenDate(Return_withSTR Data1)
        {
            string Date = DateTime.ParseExact(Data1.Data, "dd MMMM yyyy", null).ToString("yyyy-MM-dd");

            List<Return_data> Hens_List = new List<Return_data>();

            Hens_List = BusinessLayer.Get_Hens_detail(Date);
            return Hens_List;

        }
        [HttpPost("Add_Hen_In_NewHierarchy")]

        public Return_withSTR Add_Hen_In_NewHierarchy(Add_hens_data Hens_Data)
        {
            Return_withSTR Ret = new Return_withSTR();
            Ret.Data = BusinessLayer.Add_Hens(Hens_Data.Hierarchy_level,Hens_Data.Hens_count,true);

            return Ret;

        }

        [HttpPost("Add_Hen")]

        public Return_withSTR Add_Hen(Add_hens_data Hens_Data)
        {
            Return_withSTR Ret = new Return_withSTR();
            Ret.Data = BusinessLayer.Add_Hens(Hens_Data.Hierarchy_level, Hens_Data.Hens_count);

            return Ret;

        }


        [HttpPost("Edit_Hen")]
        public Return_withSTR Edit_Hen(Hens_Data Hens_Data)
        {
            Return_withSTR Ret = new Return_withSTR();
            if(Hens_Data.Egg_num.ToString()!=null)
            Ret.Data = BusinessLayer.Edit_Hens(Hens_Data.Hierarchy_level, Hens_Data.Hen_Id,Hens_Data.Egg_num);
            else
                Ret.Data = BusinessLayer.Edit_Hens(Hens_Data.Hierarchy_level, Hens_Data.Hen_Id);

            return Ret;

        }



    }
}
