using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_THI;
using System.Data;
namespace BUS_THI
{
    public class BUS
    {
        DAL dal = new DAL();

        //DataGrirdView
        public DataTable showBang()
        {
            string strsql = "select * from Hang";
            return dal.GetDataTable(strsql);
        }

        public DataTable showcbo()
        {
            string srtsql = "select * from Loaihang";
            return dal.GetDataTable(srtsql);
        }
        //Thêm mới
        public void Insert(int mah, string tenh, float dongia, int mal)
        {
            string strsql = "insert into Hang values ('" + mah + "',N'" + tenh + "','" + dongia + "', '" + mal + "')";
            dal.Execute(strsql);
        }

        public DataTable LookLop(int mal)
        {
            string sql = "select * from Loaihang where Maloai = '" + mal + "'";
            DataTable dt = new DataTable();
            dt = dal.GetDataTable(sql);
            return dt;
        }
        public DataTable KiemTrahang(string mah)
        {
            string strsql = "select * from Hang where Mahang = '" + mah + "'";
            return dal.GetDataTable(strsql);
        }
    }
}
