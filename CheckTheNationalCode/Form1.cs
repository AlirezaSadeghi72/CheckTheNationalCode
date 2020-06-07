using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckTheNationalCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            if (txtCode.Text.Length == 0)
            {
                lblStatus.Text = "لطفا کد ملی را وارد کنید";
                lblStatus.ForeColor = Color.Black;
            }
            else
            {
                SetLabalStatus(CheckCode(txtCode.Text));
            }
        }

        public bool CheckCode(string TextNationalCode)
        {
            try
            {
                var AllDigitEqual = new[]
                {
                    "0000000000",
                    "1111111111",
                    "2222222222",
                    "3333333333",
                    "4444444444",
                    "5555555555",
                    "6666666666",
                    "7777777777",
                    "8888888888",
                    "9999999999"
                };
                if (AllDigitEqual.Contains(TextNationalCode))
                    return false;

                List<int> multiplication = new List<int>();
                int i = 0;
                foreach (var item in TextNationalCode.ToCharArray())
                {
                    int num = Convert.ToInt32(item.ToString()) * (10 - i);
                    multiplication.Add(num);
                    i++;
                }

                var sum = multiplication.GetRange(0, 9).Sum();
                var c = sum % 11;

                return (((c < 2) && (multiplication[9] == c)) || ((c >= 2) && ((11 - c) == multiplication[9])));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private void SetLabalStatus(bool Status)
        {
            if (Status)
            {
                lblStatus.Text = "کد ملی وارد شده درست است";
                lblStatus.ForeColor = Color.Green;
            }
            else
            {
                lblStatus.Text = "کد ملی وارد شده اشتباه است";
                lblStatus.ForeColor = Color.Red;
            }
        }
    }
}
