# Windows Forms Calculator

A simple calculator application built with **C#** and **Windows Forms**, developed as a practice project for learning .NET desktop UI development.

---

## Features

- Basic arithmetic: addition, subtraction, multiplication, and division
- Parentheses support with nested grouping
- Decimal number input (locale-aware decimal separator)
- Negative number support via the minus key as a sign
- Calculation history log displayed in the UI
- Input validation with user-friendly error messages (e.g. division by zero, unclosed parentheses, trailing operators)
- Clear Entry ('CE') button for step-by-step backspace deletion
- Operator replacement — pressing a new operator while one is pending replaces it instead of stacking

---

## How It Works

Input is accumulated as a formatted string ('currentCalc') where numbers, operators, and parentheses are always separated by single spaces. When the result button is pressed, the 'Calculate(string)' method:

1. Splits the expression by spaces
2. Recursively resolves any subexpressions in parentheses
3. Builds a list of numbers and a list of operators
4. Applies standard operator precedence: '*' and '/' before '+' and '-'

---

## Project Structure

'''
Windows-Forms-Calculator/
├── Calculator.csproj       # Project file (.NET Windows Forms)
├── Program.cs              # Entry point
├── Form1.cs                # Main form logic and calculator engine
├── Form1.Designer.cs       # Auto-generated UI layout
├── Form1.resx              # Form resources
└── Properties/             # Assembly info and settings
'''

---

## Requirements

- Windows OS
- [.NET SDK](https://dotnet.microsoft.com/download) (compatible with the Windows Forms workload)
- Visual Studio 2019+ (recommended) or any IDE with C# and WinForms support

---

## Getting Started

1. Clone the repository:
   '''bash
   git clone https://github.com/Kopfman2731/Windows-Forms-Calculator.git
   '''

2. Open 'Calculator.csproj' in Visual Studio.

3. Build and run the project ('F5' or **Debug → Start Debugging**).

---

## Usage

| Button | Action |
|--------|--------|
| '0'–'9' | Enter digits |
| '+' '-' '*' '/' | Arithmetic operators |
| '-' (after '(' or as first char) | Negative sign |
| '.' | Decimal separator (locale-aware) |
| '(' ')' | Open/close parentheses |
| '=' | Evaluate expression |
| 'CE' | Delete last character/token |

Results and previous calculations appear in the history panel.

---

## Known Limitations

- No keyboard input support (mouse/click only)
- No support for unary functions (e.g. square root, percentage)
- Results are displayed as plain 'double' — no rounding or formatting for very large/small values

---

## License

This project is open source and available under the [MIT License](LICENSE).
