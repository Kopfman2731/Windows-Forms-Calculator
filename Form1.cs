using System.Drawing.Design;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        public CalculatorForm()
        {
            InitializeComponent();
        }
        /*
         * ##################################################################
         * #                                                                #
         * #    Input is saved as string currentCalc while inputting        #
         * #    automatically formatted, so that numbers, operators         #
         * #    and parentheses are always separated with a single          #
         * #    space.                                                      #
         * #    When result button is pressed, Calculate(string) takes      #
         * #    currentCalc, splits it by spaces, parses the resulting      #
         * #    list, calling itself on any substrings inside               #
         * #    parentheses.                                                #
         * #    Parsing results in a list of numbers and a list of          #
         * #    operators, which are then processed to arrive at            #
         * #    a result or error (for division by zero)                    #
         * #                                                                #
         * ##################################################################
         */

        private List<string> history = new List<string>();
        private string currentCalc = "";
        char[] numberArray = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        char[] operatorArray = { '+', '-', '*', '/' };
        int parOpen = 0;
        private bool calcSuccessful = false;
        private bool errorIsPosted = false;
        private bool debug = false;
        private char decimalSeparator;

        //when form is first loaded do
        private void Form1_Load(object sender, EventArgs e)
        {
            NumberFormatInfo nfInfo = CultureInfo.CurrentCulture.NumberFormat;
            decimalSeparator = nfInfo.CurrencyDecimalSeparator.First();
            btDecimalSeparator.Text = decimalSeparator.ToString();

            if (debug)
            {
                history.Add("debug: decimal separator: " + decimalSeparator);
            }
        }


        //perform calculation on currentCalc and return result, with flag calcSuccessful to indicate any errors
        private double Calculate(string calc)
        {
            List<double> numbers = new List<double>();
            List<char> operators = new List<char>();
            List<string> splitCalc;
            bool hasOperator = false;

            calc = calc.Trim('(', ')', ' ');

            //if calc contains no operators just return value
            foreach (char c in operatorArray)
            {
                if (calc.Contains(c + " "))
                {
                    hasOperator = true;
                    break;
                }
            }
            if (!hasOperator)
            {
                return Double.Parse(calc);
            }

            splitCalc = new List<string>(calc.Split(" "));

            for (int i = 0; i < splitCalc.Count; i++)
            {
                //numbers
                if (numberArray.Contains(splitCalc[i].First()) || ( splitCalc[i].Length > 1 && numberArray.Contains(splitCalc[i].ElementAt(1))))
                {
                    numbers.Add(Double.Parse(splitCalc[i]));
                }
                //operators
                else if (splitCalc[i].Length == 1 && operatorArray.Contains(splitCalc[i].First()))
                {
                    operators.Add(Char.Parse(splitCalc[i]));
                }
                //handle parentheses
                else if (splitCalc[i] == "(")
                {
                    //start at '('
                    int sectionLength = 1,//count list entries
                        open = 1;//count open parentheses
                    string substringCalc = splitCalc[i];

                    //find appropriate ')' starting at next list entry
                    for (int j = i + 1; j < splitCalc.Count; j++)
                    {
                        substringCalc += " " + splitCalc[j];
                        sectionLength++;

                        if (splitCalc[j] == "(")
                        {
                            open++;
                        }
                        else if (splitCalc[j] == ")")
                        {
                            open--;
                            if (open == 0)
                            {
                                // appropriate ')' found
                                break;
                            }
                        }
                    }
                    //call Calculate on section in parentheses
                    numbers.Add(Calculate(substringCalc));
                    //remove section from splitCalc
                    splitCalc.RemoveRange(i, sectionLength);
                }
            }

            //perform calculation
            //'*' and '/' first:
            while (operators.Count > 0)
            {
                for (int i = 0; i < operators.Count; i++)
                {
                    //while '*' and '/' operators are present, skip '+' and '-'
                    if ((operators.Contains('*') || operators.Contains('/')) &&
                        (operators[i] == '+' || operators[i] == '-'))
                    {
                        continue;
                    }
                    //execute operation
                    if (!doMath(operators, numbers, i))
                    {
                        //division by zero
                        calcSuccessful = false;
                        return 0;
                    }
                    i--;
                }
            }

            return numbers[0];
        }

        //perform operation at index, save output in numbers[index], removing operators[index] and numbers[index + 1]
        private bool doMath(List<char> operators, List<double> numbers, int index)
        {
            switch (operators[index])
            {
                case '+':
                    if (debug) { history.Add("debug: " + numbers[index].ToString() + " + " + numbers[index + 1].ToString() + " = " + (numbers[index] + numbers[index + 1])); }
                    numbers[index] += numbers[index + 1];
                    break;
                case '-':
                    if (debug) { history.Add("debug: " + numbers[index].ToString() + " - " + numbers[index + 1].ToString() + " = " + (numbers[index] - numbers[index + 1])); }
                    numbers[index] -= numbers[index + 1];
                    break;
                case '*':
                    if (debug) { history.Add("debug: " + numbers[index].ToString() + " * " + numbers[index + 1].ToString() + " = " + (numbers[index] * numbers[index + 1])); }
                    numbers[index] *= numbers[index + 1];
                    break;
                case '/':
                    //handle division by zero
                    if (numbers[index + 1] == 0)
                    {
                        PostError("Division by Zero");
                        return false;
                    }
                    else
                    {
                        if (debug) { history.Add("debug: " + numbers[index].ToString() + " / " + numbers[index + 1].ToString() + " = " + (numbers[index] / numbers[index + 1])); }
                        numbers[index] /= numbers[index + 1];
                    }
                    break;
            }
            operators.RemoveAt(index);
            numbers.RemoveAt(index + 1);

            return true;
        }

        //Handle error state and messages in lboxHistory:
        private void PostError(string message)
        {
            if (errorIsPosted)
            {
                history.RemoveAt(history.Count - 1);
            }
            history.Add("Malformed expression: " + message);
            refreshHistory();

            errorIsPosted = true;
            calcSuccessful = false;
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

        //Handle adding a number
        private void addNumber(char newNumber)
        {
            //handle zeroes when currentCalc short
            if (currentCalc == "0")
            {
                //new zero not allowed if zero is already in last position
                if (newNumber == '0')
                {
                    return;
                }
                //else delete last position and continue
                {
                    currentCalc = "";
                }
            }
            //handle zeroes when currentCalc longer and last is zero...
            else if (currentCalc.Length > 1 && currentCalc.Last() == '0')
            {
                //... preceeded by a space or a negative sing
                if (currentCalc.ElementAt(currentCalc.Length - 2) == ' ' || currentCalc.ElementAt(currentCalc.Length - 2) == '-')
                {
                    //delete last position and continue
                    currentCalc = currentCalc.Remove(currentCalc.Length - 1);
                }
            }
            //not allowed after closing parenthesis
            else if (currentCalc.Length > 1 && currentCalc.Last() == ')') { return; }
            //else allowed

            currentCalc += newNumber;
            refreshCurrent();
        }

        //Handle adding an operator
        private void addOperator(char newOperator)
        {
            int end = currentCalc.Length;

            //not allowed on empty input, unless newOperator is '-' as a sign
            if (currentCalc == "")
            {
                if (newOperator == '-')
                {
                    currentCalc += '-';
                    refreshCurrent();
                    return;
                }
                else
                {
                    return;
                }
            }
            //not allowed after '-' as a sign, unless newOperators is '-' then remove it
            if (currentCalc.Last() == '-')
            {
                if (newOperator == '-')
                {
                    currentCalc = currentCalc.Remove(currentCalc.Length - 1);
                    refreshCurrent();
                }
                return;
            }
            //not allowed if same operator already present:
            if (end > 2 && currentCalc.ElementAt(end - 2) == newOperator && !numberArray.Contains(currentCalc.Last())) { return; }
            //not allowed after opening parenthesis, unless newOperator is '-' as a sign
            if (end >= 2 && currentCalc.ElementAt(end - 2) == '(') 
            {
                if (newOperator == '-')
                {
                    currentCalc += '-';
                    refreshCurrent();
                    return;
                }
                else
                {
                    return;
                }
            }

            //replace other operator if present
            if (end > 2 && operatorArray.Contains(currentCalc.ElementAt(end - 2)) && !numberArray.Contains(currentCalc.Last()))
            {
                currentCalc = currentCalc.Remove(end - 2) + newOperator + " ";
            }
            //else remove point if point is last char and add operator
            else if (currentCalc.ElementAt(end - 1) == decimalSeparator)
            {
                currentCalc = currentCalc.Remove(end - 1) + " " + newOperator + " ";
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
            //not allowed on empty string
            if (currentCalc.Length == 0) { return; }
            //check for open parentheses
            if (parOpen != 0)
            {
                PostError("\")\" expected");
                return;
            }
            //check for trailing operator
            else if (operatorArray.Contains(currentCalc.Last()))
            {
                PostError("Unexpected operator");
                return;
            }
            //else allowed
            else
            {
                //trim trailing point if present
                currentCalc = currentCalc.TrimEnd(decimalSeparator);

                calcSuccessful = true; //true until error occurs

                double result = Calculate(currentCalc);
                if (calcSuccessful)
                {
                    currentCalc += " = " + result.ToString();
                    if (errorIsPosted)
                    {
                        history.RemoveAt(history.Count - 1);
                    }
                    history.Add(currentCalc);
                    currentCalc = "";
                    refreshCurrent();
                    refreshHistory();
                    calcSuccessful = false;
                    errorIsPosted = false;
                }
            }
        }

        //Clear Entry button:
        private void btCE_Click(object sender, EventArgs e)
        {
            int end = currentCalc.Length;
            //not allowed if string empty
            if (end == 0) { return; }
            //allowed if string.Length < 3 OR last element is number OR last element is decimalSeparator
            if (end < 3 || numberArray.Contains(currentCalc.Last()) || currentCalc.Last() == decimalSeparator)
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
            //handle sign
            else if (currentCalc.Last() == '-')
            {
                //remove 1 element
                currentCalc = currentCalc.Remove(end - 1);
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

        private void btDecimalSeparator_Click(object sender, EventArgs e)
        {
            //if added to empty string or after operator, add 0 before .
            if (currentCalc == "" || currentCalc.Last() == ' ' || currentCalc.Last() == '-')
            {
                currentCalc += "0" + decimalSeparator;
                refreshCurrent();
            }
            else if (numberArray.Contains(currentCalc.Last())) //allowed if added after number
            {
                currentCalc += decimalSeparator;
                refreshCurrent();
            }
        }

        //parentheses buttons:

        private void btParaOpen_Click(object sender, EventArgs e)
        {
            //only allow "(" at start of expression or after operator or opening parenthesis (which comes with a trailing space)
            if (currentCalc == "" || currentCalc.Last() == ' ')
            {
                currentCalc += "( ";// therefore counts as operator when last in string
                parOpen++;
                refreshCurrent();
            }
        }

        private void btParaClose_Click(object sender, EventArgs e)
        {
            //not allowed on string shorter than 2
            if (currentCalc.Length < 2) { return; }

            //only allow ")" after a number, trailing point or another ")" and if there are opening "("
            if (parOpen > 0 && ((numberArray.Contains(currentCalc.Last()) || currentCalc.Last() == ')') || currentCalc.Last() == decimalSeparator))
            {
                //remove trailing point if present
                if (currentCalc.Last() == decimalSeparator)
                {
                    currentCalc = currentCalc.Remove(currentCalc.Length - 1);
                }
                currentCalc += " )";
                parOpen--;
                refreshCurrent();
            }
        }

        //number buttons:

        private void bt1_Click(object sender, EventArgs e)
        {
            addNumber('1');
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            addNumber('2');
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            addNumber('3');
        }

        private void bt4_Click(object sender, EventArgs e)
        {
            addNumber('4');
        }

        private void bt5_Click(object sender, EventArgs e)
        {
            addNumber('5');
        }

        private void bt6_Click(object sender, EventArgs e)
        {
            addNumber('6');
        }

        private void bt7_Click(object sender, EventArgs e)
        {
            addNumber('7');
        }

        private void bt8_Click(object sender, EventArgs e)
        {
            addNumber('8');
        }

        private void bt9_Click(object sender, EventArgs e)
        {
            addNumber('9');
        }

        private void bt0_Click(object sender, EventArgs e)
        {
            addNumber('0');
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
