using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculatorPractice {
    class MathProblem {
        private string _infixProblem;
        private string _postfixProblem;
        private double _correctAnswer;
        private double _userAnswer;
        private bool _isCorrect;


        //create new stack
        Stack<string> newStack = new Stack<string>();

        public double CorrectAnswer {
            get { return _correctAnswer; }
            //private set { _correctAnswer = SolveProblem(); }
        }//end property
        public double UserAnswer {
            get { return _userAnswer; }
            set { _userAnswer = value; }
        }//end property
        public string InfixProblem {
            get { return _infixProblem; }
            set {
                _infixProblem = value;
                _postfixProblem = InfixToPostfixConvert(_infixProblem);
                _correctAnswer = SolveProblem(_postfixProblem);
            }//end set
        }//end property

        public bool IsCorrect {
            get { return _isCorrect; }
            private set { _isCorrect = value; }
        }//end property


        public string InfixToPostfixConvert(string infixBuffer) {
            int priority = 0;
            string postfixBuffer = "";
            string[] stringArray = infixBuffer.Split(' ');

            Stack<string> s1 = new Stack<string>();

            for (int i = 0; i < stringArray.Length; i++) {

                string ch = stringArray[i];

                if (ch == "+" || ch == "-" || ch == "*" || ch == "/") {

                    // check the precedence

                    if (s1.Length <= 0) {
                        s1.Push(ch);
                    } else {
                        if (s1.Peek() == "*" || s1.Peek() == "/") {
                            priority = 1;
                        } else {
                            priority = 0;
                        }//end if

                        if (priority == 1) {
                            if (ch == "+" || ch == "-") {
                                postfixBuffer += s1.Pop() + " ";
                                i--;
                            } else { // Same
                                postfixBuffer += s1.Pop() + " ";
                                i--;
                            }//end if
                        } else {
                            if (ch == "+" || ch == "-") {
                                postfixBuffer += s1.Pop() + " ";
                                s1.Push(ch);
                            } else {
                                s1.Push(ch);
                            }//end if
                        }//end if
                    }//end if
                } else {
                    if (postfixBuffer == "") {
                        postfixBuffer += ch + " ";
                    } else {

                        if (i == stringArray.Length) {
                            postfixBuffer += ch;
                        } else {
                            postfixBuffer += ch + " ";
                        }//end if
                    }//end if

                }//end if
            }//end for

            int len = s1.Length;

            for (int j = 0; j < len; j++) {
                if (s1.Length == 1) {
                    postfixBuffer += s1.Pop();
                } else {
                    postfixBuffer += s1.Pop() + " ";

                }
                

            }//end for
            return postfixBuffer;
        }//end converter
        private double SolveProblem(string inputString) {

            //split string on spaces and store to array
            string[] stringArray = inputString.Split(' ');

            for (int index = 0; index < stringArray.Length; index++) {
                //as we walk the array check to see if the current index is an operator or operand
                if (IsOperator(stringArray[index]) == true) {//if operator perform the required operation
                    Operate(stringArray[index]);

                } else {//if operand add to stack
                    newStack.Push(stringArray[index]);
                    //lsbListBox.Items.Add("After Push: " + newStack.ToString());
                }//end if               
            }//end for
            //return final result
            return double.Parse(newStack.Peek());
        }
        private static bool IsOperator(string symbol) {
            if (symbol == "+" || symbol == "-" || symbol == "*" || symbol == "/") {
                return true;
            } else {
                return false;
            }//end if        
        }//end IsOperator
        private void Operate(string symbol) {
            //pop the first 2 operands from the stack and store their values to variables                                 
            double num2 = double.Parse(newStack.Pop());
            double num1 = double.Parse(newStack.Pop());

            //depending on the operator call the required method and push result onto stack
            if (symbol == "+") {

                double result = Add(num1, num2);
                newStack.Push(result.ToString());
                //lsbListBox.Items.Add("After Addition: " + newStack.ToString());

            } else if (symbol == "-") {

                double result = Subtract(num1, num2);
                newStack.Push(result.ToString());
                //lsbListBox.Items.Add("After Subtraction: " + newStack.ToString());

            } else if (symbol == "*") {

                double result = Multiply(num1, num2);
                newStack.Push(result.ToString());
                //lsbListBox.Items.Add("After Multiplication: " + newStack.ToString());

            } else if (symbol == "/") {

                double result = Divide(num1, num2);
                newStack.Push(result.ToString());
                //lsbListBox.Items.Add("After Division: " + newStack.ToString());
            }//end if                               
        }//end Operate
        private double Add(double num1, double num2) {
            return num1 + num2;
        }//end method
        private double Subtract(double num1, double num2) {
            return num1 - num2;
        }//end method
        private double Divide(double num1, double num2) {
            return num1 / num2;
        }//end method
        private double Multiply(double num1, double num2) {
            return num1 * num2;
        }//end method
    }
}
