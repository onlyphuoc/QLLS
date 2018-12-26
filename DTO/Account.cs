using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLLS.DTO
{
    public class Account
    {

        public Account(DataRow row)
        {
            this.UserName = row["UserName"] + "";
            this.DisplayName = row["DisplayName"] + "";
            this.TypeAcc = (int)row["TypeAcc"];
            this.Pass = row["Pass"] +"";
        }

        private string userName;

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public string Pass
        {
            get
            {
                return pass;
            }

            set
            {
                pass = value;
            }
        }

        public string DisplayName
        {
            get
            {
                return displayName;
            }

            set
            {
                displayName = value;
            }
        }

        public int TypeAcc
        {
            get
            {
                return typeAcc;
            }

            set
            {
                typeAcc = value;
            }
        }

        private string pass;

        private string displayName;

        private int typeAcc;
    }
}
