using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuyetVaySieuToc.Models.BusinessModel
{
    public static class TaoMaAuto
    {
        public static string getMa(List<string> dsMa,string kyTu)
        {

            if (dsMa.Count() > 0)
            {
                int maxtemp = 0;
                int maMax = int.Parse(dsMa[0].Substring(kyTu.Length));
                for (int i = 1; i < dsMa.Count(); i++)
                {
                    int temp = int.Parse(dsMa[i].Substring(kyTu.Length));
                    if (temp > maMax)
                    {
                        maxtemp = i;
                       
                    }
                    maMax = temp;
                }
                return dsMa[maxtemp];
            }
            return null;
        }
        private static string DoDai(int a)
        {
            string kq = "";
            for (int i = 0; i < a; i++)
            {
                kq += "0";
            }
            return kq;
        }
        //static string kyTu = "LSP";

        public static string TaoMa(string ma,string kyTu)
        {
            int dodai = 5;
            string kp = kyTu;
            if (String.IsNullOrEmpty(ma))
            {
                ma = "1";
                kp += DoDai(dodai - kyTu.Length - ma.Length) + ma.ToString();
                return kp;
            }
            int masohientai = int.Parse(ma.Substring(3));
            //kp += DoDai(dodai - kyTu.Length - (masohientai+1).ToString().Length) + (masohientai + 1).ToString();

            //

            int newmaso = masohientai+1;
            int mDodai = (dodai - kyTu.Length - newmaso.ToString().Length) > 0 ? (dodai - kyTu.Length - newmaso.ToString().Length) : 0;
            if (mDodai == 0)
            {
                //cái này nó tăng tới độ dài >5 được NXC100 cũng ok.
                //thử xóa cái 09 rồi thêm lại 09 thử xem
                kp += newmaso.ToString();
            }
            else
            {
                kp += DoDai(mDodai) + newmaso.ToString();
            }

            return kp;
        }

    }
}