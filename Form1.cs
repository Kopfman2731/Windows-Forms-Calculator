using System.Drawing.Design;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<string> history = new List<string>();
        private string currentCalc = "";
        private bool isValid = false;

        //perform calculation on currentCalc, append result to currentCalc and returns true if successful
        private string Calculate()
        {
            isValid = true;
            //parse and check for possible error states:
            return "";
        }

        //check parentheses:
        private bool CheckPar()
        {
            int openPar = 0;
            foreach (char c in currentCalc)
            {
                if (c == '(') { openPar++; }
                if (c == ')')
                {
                    if (openPar > 0)
                    {
                        openPar--;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            if (openPar > 0) { return false; }

            return true;
        }

        //reset after successful calculation
        private void reset()
        {
            lboxCurrent.Items.Clear();
            isValid = false;
            currentCalc = "";
        }

        //refresh lboxCurrent
        private void refreshCurrent()
        {
            lboxCurrent.Items.Clear();
            lboxCurrent.Items.Add(currentCalc);
        }

        //refresh lboxHistory
        private void refreshHistory()
        {
            lboxHistory.Items.Clear();
            foreach (string s in history)
            {
                lboxHistory.Items.Add(s);
            }
        }

        //Result button
        private void btResult_Click(object sender, EventArgs e)
        {

        }

        //Clear Entry button:
        private void btCE_Click(object sender, EventArgs e)
        {
            currentCalc = currentCalc.Remove(currentCalc.Length - 1); //remove last entry from currentCalc
            refreshCurrent();
        }

        //number and operator buttons:

        private void bt1_Click(object sender, EventArgs e)
        {
            currentCalc += "1";
            refreshCurrent();
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            currentCalc += "2";
            refreshCurrent();
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            currentCalc += "3";
            refreshCurrent();
        }

        private void bt4_Click(object sender, EventArgs e)
        {
            currentCalc += "4";
            refreshCurrent();
        }

        private void bt5_Click(object sender, EventArgs e)
        {
            currentCalc += "5";
            refreshCurrent();
        }

        private void bt6_Click(object sender, EventArgs e)
        {
            currentCalc += "6";
            refreshCurrent();
        }

        private void bt7_Click(object sender, EventArgs e)
        {
            currentCalc += "7";
            refreshCurrent();
        }

        private void bt8_Click(object sender, EventArgs e)
        {
            currentCalc += "8";
            refreshCurrent();
        }

        private void bt9_Click(object sender, EventArgs e)
        {
            currentCalc += "9";
            refreshCurrent();
        }

        private void bt0_Click(object sender, EventArgs e)
        {
            currentCalc += "0";
            refreshCurrent();
        }

        private void btPoint_Click(object sender, EventArgs e)
        {
            currentCalc += ".";
            refreshCurrent();
        }

        private void btParaOpen_Click(object sender, EventArgs e)
        {
            currentCalc += " ( ";
            refreshCurrent();
        }

        private void btParaClose_Click(object sender, EventArgs e)
        {
            currentCalc += " ) ";
            refreshCurrent();
        }

        private void btPlus_Click(object sender, EventArgs e)
        {
            currentCalc += " + ";
            refreshCurrent();
        }

        private void btMinus_Click(object sender, EventArgs e)
        {
            currentCalc += " - ";
            refreshCurrent();
        }

        private void btMultiply_Click(object sender, EventArgs e)
        {
            currentCalc += " * ";
            refreshCurrent();
        }

        private void btDivision_Click(object sender, EventArgs e)
        {
            currentCalc += " / ";
            refreshCurrent();
        }
    }
}
