using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace calculatorPractice {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }//end constructor
        

        LinkedList<string> newList = new LinkedList<string>();

        
        private void btn0_Click(object sender, RoutedEventArgs e) {
          
            newList.AddNode("0");
            AddToDisplay();
        }

        private void btn1_Click(object sender, RoutedEventArgs e) {
           
            newList.AddNode("1");
            AddToDisplay();
        }

        private void btn2_Click(object sender, RoutedEventArgs e) {
          
            newList.AddNode("2");
            AddToDisplay();
        }

        private void btn3_Click(object sender, RoutedEventArgs e) {
           
            newList.AddNode("3");
            AddToDisplay();
        }

        private void btn4_Click(object sender, RoutedEventArgs e) {
          
            newList.AddNode("4");
            AddToDisplay();
        }

        private void btn5_Click(object sender, RoutedEventArgs e) {
           
            newList.AddNode("5");
            AddToDisplay();
        }

        private void btn6_Click(object sender, RoutedEventArgs e) {
          
            newList.AddNode("6");
            AddToDisplay();
        }

        private void btn7_Click(object sender, RoutedEventArgs e) {
            
            newList.AddNode("7");
            AddToDisplay();
        }

        private void btn8_Click(object sender, RoutedEventArgs e) {
           
            newList.AddNode("8");
            AddToDisplay();
        }

        private void btn9_Click(object sender, RoutedEventArgs e) {
          
            newList.AddNode("9");
            AddToDisplay();
        }
        private void btnDecimal_Click(object sender, RoutedEventArgs e) {
            newList.AddNode(".");
            AddToDisplay();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e) {
           
            newList.AddNode("+");
            AddToDisplay();
        }
        private void btnSubtract_Click_1(object sender, RoutedEventArgs e) {
          
            newList.AddNode("-");
            AddToDisplay();
        }

        private void btnMultiply_Click(object sender, RoutedEventArgs e) {
          
            newList.AddNode("*");
            AddToDisplay();
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e) {
         
            newList.AddNode("/");
            AddToDisplay();
        }
        private void AddToDisplay() {
            txtDisplay.Text = newList.ToString();
        }
        private void btnClear_Click(object sender, RoutedEventArgs e) {
            txtDisplay.Text = "";
            newList.Clear();
        }
        private void btnEquals_Click(object sender, RoutedEventArgs e) {
            //create instance of MathProblem
            MathProblem newProblem = new MathProblem();
            //walk the list until you see an operator
            for (int index = 0; index < newList.Length; index++) {
                if (newList[index] == "+" || newList[index] == "-" || newList[index] == "*" || newList[index] == "/") {
                    //insert spaces before and after operator
                    newList.Insert(index, " ");
                    newList.Insert(index+2, " ");
                    index += 2;
                }//end if
            }//end for
            //send the list as a string to InfixProblem variable of MathProblem class
            newProblem.InfixProblem = newList.ToString();
            //display correct answer in display box
            txtDisplay.Text = newProblem.CorrectAnswer.ToString();
        }//end event
        
        
        
        


        

        
    }//end class
}//end namespace
