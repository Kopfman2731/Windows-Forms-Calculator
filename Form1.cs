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
        private bool prevIsNumber = false;
        private bool prevIsOperator = false;
        private bool hasDecimal = false;
        private int openPar = 0;
        private bool calcSuccess = false;

        private void refreshListBox()
        {
            //clear and re-write lboxCurrent:
            lboxCurrent.Items.Clear();
            lboxCurrent.Items.Add(currentCalc);

            //clear and re-write lboxHistory:
            lboxHistory.Items.Clear();
            foreach (string s in history)
            {
                lboxHistory.Items.Add(s);
            }
            //and scroll to bottom:
            lboxHistory.TopIndex = lboxHistory.Items.Count - 1;
        }

        private string calculate(string calc)//performs calculation on an approved string, returns result-string and sets calcSuccess, if successfull
        {
            while (calc.Contains("("))// do sub calculations in parantheses first
            {
                int start = calc.IndexOf("(");
                int length = calc.LastIndexOf(")") - start + 1;
                string subCalc = calc.Substring(start, length);
                calc.Replace(subCalc, calculate(subCalc.Trim(new char[] { '(', ')' }))); //replace parentheses substring, with 
            }
            calcSuccess = true;
            return calc;
        }

        private void btResult_Click(object sender, EventArgs e)
        {
            if (openPar == 0)
            {
                currentCalc += " = " + calculate(currentCalc);
            }
            
            if (true/*calcSuccess*/)//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< FIX ME, set to calcSuccess
            {
                history.Add(currentCalc);
                currentCalc = "";
                refreshListBox();
                prevIsNumber = false;
                hasDecimal = false;
                prevIsOperator = false;
                calcSuccess = false;
            }
        }

        private void numberClick()

        private void bt1_Click(object sender, EventArgs e)
        {
            currentCalc += "1";
            prevIsNumber = true;
            prevIsOperator = false;
            refreshListBox();
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            currentCalc += "2";
            prevIsNumber = true;
            prevIsOperator = false;
            refreshListBox();
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            currentCalc += "3";
            prevIsNumber = true;
            prevIsOperator = false;
            refreshListBox();
        }

        private void bt4_Click(object sender, EventArgs e)
        {
            currentCalc += "4";
            prevIsNumber = true;
            prevIsOperator = false;
            refreshListBox();
        }

        private void bt5_Click(object sender, EventArgs e)
        {
            currentCalc += "5";
            prevIsNumber = true;
            prevIsOperator = false;
            refreshListBox();
        }

        private void bt6_Click(object sender, EventArgs e)
        {
            currentCalc += "6";
            prevIsNumber = true;
            prevIsOperator = false;
            refreshListBox();
        }

        private void bt7_Click(object sender, EventArgs e)
        {
            currentCalc += "7";
            prevIsNumber = true;
            prevIsOperator = false;
            refreshListBox();
        }

        private void bt8_Click(object sender, EventArgs e)
        {
            currentCalc += "8";
            prevIsNumber = true;
            prevIsOperator = false;
            refreshListBox();
        }

        private void bt9_Click(object sender, EventArgs e)
        {
            currentCalc += "9";
            prevIsNumber = true;
            prevIsOperator = false;
            refreshListBox();
        }

        private void bt0_Click(object sender, EventArgs e)
        {
            currentCalc += "0";
            prevIsNumber = true;
            prevIsOperator = false;
            refreshListBox();
        }

        private void btPoint_Click(object sender, EventArgs e)
        {
            if (prevIsNumber && !hasDecimal)
            {
                currentCalc += ".";
                hasDecimal = true;
                refreshListBox();
            }
        }

        private void btParaOpen_Click(object sender, EventArgs e)
        {
            if (currentCalc.Length == 0 || prevIsOperator)
            {
                currentCalc += " ( ";
                openPar++;
                refreshListBox();
            }
        }

        private void btParaClose_Click(object sender, EventArgs e)
        {
            if (openPar > 0 && prevIsNumber)
            {
                currentCalc += " ) ";
                openPar--;
                refreshListBox();
            }
        }

        private void btPlus_Click(object sender, EventArgs e)
        {
            if (prevIsNumber)
            {
                currentCalc += " + ";
                prevIsNumber = false;
                prevIsOperator = true;
                hasDecimal = false;
                refreshListBox();
            }
            else if (prevIsOperator)
            {
                currentCalc.Remove(currentCalc.Length - 1);
                currentCalc += " + ";
                refreshListBox();
            }
        }

        private void btMinus_Click(object sender, EventArgs e)
        {
            if (prevIsNumber)
            {
                currentCalc += " - ";
                prevIsNumber = false;
                prevIsOperator = true;
                hasDecimal = false;
                refreshListBox();
            }
            else if (prevIsOperator)
            {
                currentCalc.Remove(currentCalc.Length - 1);
                currentCalc += " - ";
                refreshListBox();
            }
        }

        private void btMultiply_Click(object sender, EventArgs e)
        {
            if (prevIsNumber)
            {
                currentCalc += " * ";
                prevIsNumber = false;
                prevIsOperator = true;
                hasDecimal = false;
                refreshListBox();
            }
            else if (prevIsOperator)
            {
                currentCalc.Remove(currentCalc.Length - 1);
                currentCalc += " * ";
                refreshListBox();
            }
        }

        private void btDivision_Click(object sender, EventArgs e)
        {
            if (prevIsNumber)
            {
                currentCalc += " / ";
                prevIsNumber = false;
                prevIsOperator = true;
                hasDecimal = false;
                refreshListBox();
            }
            else if (prevIsOperator)
            {
                currentCalc.Remove(currentCalc.Length - 1);
                currentCalc += " / ";
                refreshListBox();
            }
        }

        private void btCE_Click(object sender, EventArgs e)
        {
            currentCalc = "";
            prevIsNumber = false;
            hasDecimal = false;
            prevIsOperator = false;
            openPar = 0;
            refreshListBox();
        }
    }
}
