using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe_Assignment_1
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Button[] _buttonArray = new Button[9];
        private bool _isX;
        private bool _isGameOver;

        public Form1()
        {
            InitializeComponent();
            _buttonArray = new Button[10] { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10 };
            for (int i = 0; i < 9; i++)
                this._buttonArray[i].Click += new System.EventHandler(this.ClickHandler);
            InitGame();    
        }

        private void InitGame()
        {
            for (int i = 0; i < 9; i++)
            {
                _buttonArray[i].Text = "";
                _buttonArray[i].ForeColor = Color.Black;
                _buttonArray[i].BackColor = Color.LightGray;
                _buttonArray[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            }
            this._isX = true;
            this._isGameOver = false;
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            InitGame();
        }
        private void ClickHandler(object sender, System.EventArgs e)
        {
            Button tempButton = (Button)sender;

            if (this._isGameOver)
            {
                MessageBox.Show("Game Over...Select Play for a new game!", "ERROR", MessageBoxButtons.OK);
                return;
            }

            if (tempButton.Text != "")	
            {
                MessageBox.Show("Button already has value!", "ERROR", MessageBoxButtons.OK);
                return;
            }

            if (_isX)	
                tempButton.Text = "X";
            else
                tempButton.Text = "O";

            _isX = !_isX;	

            this._isGameOver = TicTacToeUtils.CheckAndProcessWinner(_buttonArray);
        }

    }
    public class TicTacToeUtils
    {
        
        static private int[,] Winners = new int[,]
				   {
						{0,1,2},
						{3,4,5},
						{6,7,8},
						{0,3,6},
						{1,4,7},
						{2,5,8},
						{0,4,8},
						{2,4,6}
				   };

       
        static public bool CheckAndProcessWinner(Button[] myControls)
        {
            bool gameOver = false;
            for (int i = 0; i < 8; i++)
            {
                int a = Winners[i, 0], b = Winners[i, 1], c = Winners[i, 2];		
                

                Button b1 = myControls[a], b2 = myControls[b], b3 = myControls[c];

                if (b1.Text == "" || b2.Text == "" || b3.Text == "")	
                    continue;											

                if (b1.Text == b2.Text && b2.Text == b3.Text)			
                {														
                    b1.BackColor = b2.BackColor = b3.BackColor = Color.LightCoral;
                    b1.Font = b2.Font = b3.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Italic & System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
                    gameOver = true;
                    break; 
                }
            }
            return gameOver;
        }
    }
}
