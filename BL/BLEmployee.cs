using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BL
{
    public class BLEmployee
    {

        public string insertEmp(BEEmployee objBEEmp)
        {
           DALEmployee objDALEmp = new DALEmployee();
           string strResuslt = objDALEmp.insertEmp(objBEEmp);
           return strResuslt;
        }

        public string updateEmp(BEEmployee objBEEmp)
        {
            DALEmployee objDALEmp = new DALEmployee();
            string strResuslt = objDALEmp.updateEmp(objBEEmp);
            return strResuslt;
        }
    
    
    }
}
