namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> history = new List<string>();
        string currentCalc = "";

        private void refreshListBox()
        {
            lboxCurrent.Items.Clear();
            lboxHistory.Items.Clear();

            lboxCurrent.Items.Add(currentCalc);
            for (int i = history.Count - 1; i >= 0; i--)
            {
                lboxHistory.Items.Add((string)history[i]);
            }
        }

        private string calculate(string calc)
        {
            return calc;
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            currentCalc += "1";
            refreshListBox();
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            currentCalc += "2";
            refreshListBox();
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            currentCalc += "3";
            refreshListBox();
        }

        private void bt4_Click(object sender, EventArgs e)
        {
            currentCalc += "4";
            refreshListBox();
        }

        private void bt5_Click(object sender, EventArgs e)
        {
            currentCalc += "5";
            refreshListBox();
        }

        private void bt6_Click(object sender, EventArgs e)
        {
            currentCalc += "6";
            refreshListBox();
        }

        private void bt7_Click(object sender, EventArgs e)
        {
            currentCalc += "7";
            refreshListBox();
        }

        private void bt8_Click(object sender, EventArgs e)
        {
            currentCalc += "8";
            refreshListBox();
        }

        private void bt9_Click(object sender, EventArgs e)
        {
            currentCalc += "9";
            refreshListBox();
        }

        private void bt0_Click(object sender, EventArgs e)
        {
            currentCalc += "0";
            refreshListBox();
        }

        private void btPoint_Click(object sender, EventArgs e)
        {
            currentCalc += ".";
            refreshListBox();
        }

        private void btParaOpen_Click(object sender, EventArgs e)
        {
            currentCalc += " ( ";
            refreshListBox();
        }

        private void btParaClose_Click(object sender, EventArgs e)
        {
            currentCalc += " ) ";
            refreshListBox();
        }

        private void btPlus_Click(object sender, EventArgs e)
        {
            currentCalc += " + ";
            refreshListBox();
        }

        private void btMinus_Click(object sender, EventArgs e)
        {
            currentCalc += " - ";
            refreshListBox();
        }

        private void btMultiply_Click(object sender, EventArgs e)
        {
            currentCalc += " * ";
            refreshListBox();
        }

        private void btDivision_Click(object sender, EventArgs e)
        {
            currentCalc += " / ";
            refreshListBox();
        }

        private void btCE_Click(object sender, EventArgs e)
        {
            currentCalc = "";
            refreshListBox();
        }

        private void btResult_Click(object sender, EventArgs e)
        {
            history.Add(calculate(currentCalc));
            currentCalc = "";
            refreshListBox();
        }
    }
}
