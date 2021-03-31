using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quiz
{
    public partial class Form1 : Form
    {
        //public renders the variables visible from everywhere, even with other classes and functions in the code
        //variable 'randomizer' creates random numbers with function "Random"
        public Random randomizer = new Random();
        //initializes all variables
        public int addend1, addend2, timeLeft, minus1, minus2, times1, times2, divide1, divide2;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer() == true)
            {
                timer1.Stop();
                MessageBox.Show("Congratulations! You got all the answers right!");
            }

            else if (timeLeft >0 )
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time is up!";
                MessageBox.Show("You didn't finish on time");
                //display the correct values on screen
                sum.Value = addend1 + addend2;
                difference.Value = minus1 - minus2;
                product.Value = times1 * times2;
                quotient.Value = divide1 / divide2;

            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            //uses the randomizer to assign a value with a max of 50
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            //assign the numbers to each of the ? symbols, but we need to convert the integer to string
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            //initializes the value of 'sum' as zero
            sum.Value = 0;

            minus1 = randomizer.Next(1, 101);
            minus2 = randomizer.Next(1, minus1);

            minusLeftLabel.Text = minus1.ToString();
            minusRightLabel.Text = minus2.ToString();

            difference.Value = 0;


            times1 = randomizer.Next(2, 11);
            times2 = randomizer.Next(2, 21);

            timesLeftLabel.Text = times1.ToString();
            timesRightLabel.Text = times2.ToString();

            product.Value = 0;

            //division must be written in reverse to insure whole numbers
            divide2 = randomizer.Next(2, 11);
            int temp = randomizer.Next(2, 11);
            divide1 = divide2 * temp;

            divideLeftLabel.Text = divide1.ToString();
            divideRightLabel.Text = divide2.ToString();

            quotient.Value = 0;

            //initializes the timer tick
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value) && (minus1 - minus2 == difference.Value) &&
                (times1 * times2 == product.Value) && (divide1 / divide2 == quotient.Value))
                return true;
            else
                return false;

        }

        public Form1()
        {
            InitializeComponent();
        }
    }
}
