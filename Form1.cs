using System.Drawing.Design;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<string> history = new List<string>();
        char[] numberArray = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        char[] operatorArray = { '+', '-', '*', '/' };
        private string currentCalc = "";
        int parOpen = 0;
        private bool calcSuccessful = false;
        private bool postedError = false;

        //perform calculation on currentCalc and return result, with flag calcSuccessful to indicate any errors
        private double Calculate(string c)
        {
            List<double> numbers = new List<double>();
            List<char> operators = new List<char>();
            List<string> splitCalc;
            double n;
            double result;

            calcSuccessful = true; //true until error occurs

            //check if string is empty:
            if (c == "")
            {
                if (postedError)
                {
                    history.RemoveAt(history.Count - 1);
                    postedError = false;
                }
                return 0;
            }

            //check parentheses
            try
            {
                CheckPar(c);
            }
            catch (ArgumentException)
            {
                PostError(postedError, "Unexpected Parenthesis");
                return 0;
            }
            //split calculation string by " " and put into appropriate list
            splitCalc = new List<string>(currentCalc.Split(" "));

            //DEBUGGING
            foreach( string s in splitCalc)
            {
                history.Add("\"" + s + "\"");
                refreshHistory();
            }
            
            for (int i = 0; i < splitCalc.Count; i++)
            {


                //if s is number:


                if (numberArray.Contains(splitCalc[i].First()))
                {
                    //if position valid
                    if (numbers.Count == operators.Count)
                    {
                        //parse double and add to list numbers
                        try
                        {
                            n = double.Parse(splitCalc[i]);
                        }
                        catch (FormatException)
                        {
                            PostError(postedError, "Invalid Number");
                            return 0;
                        }
                        numbers.Add(n); //add to numbers
                    }
                    else //if position invalid: error
                    {
                        PostError(postedError, "Unexpected Number");
                        return 0;
                    }
                }


                // else if s is operator:


                else if (operatorArray.Contains(splitCalc[i].First()))
                {
                    //if position is valid
                    if (numbers.Count == operators.Count + 1)
                    {
                        operators.Add(splitCalc[i].First()); //add to operators
                    }
                    else //if position invalid: error
                    {
                        PostError(postedError, "Unexpected Operator");
                        return 0;
                    }
                }


                // else if s is '('


                else if (splitCalc[i] == "(")
                {
                    int openPar = 0;
                    string substring;
                    //if position is valid
                    if (numbers.Count == operators.Count)
                    {
                        //find correct closing parenthesis, extract substring and call calculate(substring)

                        //find correct closing parenthesis
                        for (int j=i; j < splitCalc.Count; j++)
                        {
                            if (splitCalc[j] == "(") //count parentheses starting with current "("
                            {
                                openPar++;
                            }
                            else if (splitCalc[j] == ")")
                            {
                                openPar--;
                            }
                            //if openPar == 0, j is index of correct closing parenthesis
                            if (openPar == 0)
                            {
                                //extract substring
                                substring = splitCalc.Slice(i, j-i).ToString();
                                //remove substring from splitCalc
                                splitCalc.RemoveRange(i, j - i);
                                //call calculate(substring), add to result to numbers
                                numbers.Add (Calculate(substring));
                                break;
                            }
                        }
                    }
                    //if position is invalid: error
                    else
                    {
                        PostError(postedError, "Unexpected Parenthesis");
                        return 0;
                    }
                }
            }
            return 0;
        }

        //Handle error state and messages in lboxHistory:
        private void PostError(bool prevErrorWasPosted, string message)
        {
            if (prevErrorWasPosted)
            {
                history.RemoveAt(history.Count - 1);
            }
            history.Add("Malformed expression: " + message);
            postedError = true;
            calcSuccessful = false;
        }
        
        //Check parentheses:
        private void CheckPar(string currentCalc)
        {
            int openPar = 0;
            //check for an opening parenthesis for every closing parenthesis
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
                        throw new ArgumentException("Malformed expression. Too many closing Parentheses");
                    }
                }
            }
            //check for not - closed parentheses
            if (openPar > 0)
            {
                throw new ArgumentException("Malformed expression. Parentheses not closed.");
            }
        }

        //Refresh lboxCurrent
        private void refreshCurrent()
        {
            lboxCurrent.Items.Clear();
            lboxCurrent.Items.Add(currentCalc);
        }

        //Refresh lboxHistory
        private void refreshHistory()
        {
            lboxHistory.Items.Clear();
            foreach (string s in history)
            {
                lboxHistory.Items.Add(s);
            }
            lboxHistory.TopIndex = lboxHistory.Items.Count - 1;
        }

        //Handle adding an operator
        private void addOperator(char newOperator)
        {
            int end = currentCalc.Count();

            //not allowed on empty input:
            if (currentCalc == "") { return; }
            //not allowed if same operator already present:
            if (end > 2 && currentCalc.ElementAt(end - 2) == newOperator) { return; }
            //not allowed after opening parenthesis
            if (end > 2 && currentCalc.ElementAt(end - 2) == '(') { return; }

            //replace other operator if present
            if (end > 2 && operatorArray.Contains(currentCalc.ElementAt(end - 2)))
            {
                currentCalc = currentCalc.Remove(end - 2) + newOperator + " ";
            }
            else if (currentCalc.ElementAt(end-1) == '.') //remove point if is last char and add operator
            {
                currentCalc = currentCalc.Remove(end-1) + " " + newOperator + " ";
            }
            else //else operator is allowed
            {
                currentCalc += " " + newOperator + " ";
            }

                refreshCurrent();
        }

        //Result button
        private void btResult_Click(object sender, EventArgs e)
        {
            double result = Calculate(currentCalc);
            if (calcSuccessful)
            {
                currentCalc += " = " + result.ToString();
                if (postedError)
                {
                    history.RemoveAt(history.Count - 1);
                }
                history.Add(currentCalc);
                currentCalc = "";
                refreshCurrent();
                refreshHistory();
                calcSuccessful = false;
                postedError = false;
            }
        }

        //Clear Entry button:
        private void btCE_Click(object sender, EventArgs e)
        {
            int end = currentCalc.Count();
            //not allowed if string empty
            if (end == 0) { return;  }
            //allowed if string.Count() < 3 OR last element is number OR last element is '.'
            if (end < 3 || numberArray.Contains(currentCalc.Last()) || currentCalc.Last() == '.')
            {
                currentCalc = currentCalc.Remove(end - 1);
            }
            //handle operators and opening parentheses
            else if (currentCalc.Last() == ' ')
            {
                //if operator
                if (operatorArray.Contains(currentCalc.ElementAt(end - 2)))
                {
                    //...remove last 3 elements
                    currentCalc = currentCalc.Remove(end - 3);
                }
                //if opening parenthesis
                else if (currentCalc.ElementAt(end - 2) == '(')
                {
                    //...remove last 2 elements
                    currentCalc = currentCalc.Remove(end - 2);
                    parOpen--;
                }
            }
            //handle closing parenthesis
            else if (currentCalc.Last() == ')')
            {
                //...remove last 2 elements
                currentCalc = currentCalc.Remove(end - 2);
                parOpen++;
            }
            refreshCurrent();
        }

        //number buttons:

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
            //if added to empty string or after operator, add 0 before .
            if (currentCalc.Last() == ' ' || currentCalc == "")
            {
                currentCalc += "0.";
                refreshCurrent();
            }
            else if (numberArray.Contains(currentCalc.Last())) //allowed if added after number
            {
                currentCalc += ".";
                refreshCurrent();
            }
        }

        //parentheses buttons:

        private void btParaOpen_Click(object sender, EventArgs e)
        {
            //only allow "(" at start of expression or after operator or opening parenthesis (which comes with a trailing space)
            if (currentCalc.Last() == ' ' || currentCalc == "")
            {
                currentCalc += "( ";// therefore counts as operator when last in string
                parOpen++;
                refreshCurrent();
            }
        }

        private void btParaClose_Click(object sender, EventArgs e)
        {
            //remove trailing point if present
            if (currentCalc.Last() == '.')
            {
                currentCalc = currentCalc.Remove(currentCalc.Length - 1);
            }
            //only allow ")" after a number and if there are opening "("
            if (parOpen > 0 && numberArray.Contains(currentCalc.Last()))
            {
                currentCalc += " )";
                parOpen--;
                refreshCurrent();
            }
        }

        //operator buttons:

        private void btPlus_Click(object sender, EventArgs e)
        {
            addOperator('+');
        }

        private void btMinus_Click(object sender, EventArgs e)
        {
            addOperator('-');
        }

        private void btMultiply_Click(object sender, EventArgs e)
        {
            addOperator('*');
        }

        private void btDivision_Click(object sender, EventArgs e)
        {
            addOperator('/');
        }
    }
}
