using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class BestCalc : Form
    {
        private String _result;
        private String action;
        private String stash;

        private String result
        {
            get { return this._result; }
            set
            {
                this._result = value;
                this.resultLabel.Text = this._result;
            }
        }
        public BestCalc()
        {
            InitializeComponent();
            this.stash = "0";
            this.result = "0";
            this.buttonNum0.Click += new System.EventHandler(this.addSymbol);
            this.buttonNum1.Click += new System.EventHandler(this.addSymbol);
            this.buttonNum2.Click += new System.EventHandler(this.addSymbol);
            this.buttonNum3.Click += new System.EventHandler(this.addSymbol);
            this.buttonNum4.Click += new System.EventHandler(this.addSymbol);
            this.buttonNum5.Click += new System.EventHandler(this.addSymbol);
            this.buttonNum6.Click += new System.EventHandler(this.addSymbol);
            this.buttonNum7.Click += new System.EventHandler(this.addSymbol);
            this.buttonNum8.Click += new System.EventHandler(this.addSymbol);
            this.buttonNum9.Click += new System.EventHandler(this.addSymbol);
            this.buttonDot.Click += new System.EventHandler(this.addSymbol);
            this.buttonMinus.Click += new System.EventHandler(this.makeAction);
            this.buttonPlus.Click += new System.EventHandler(this.makeAction);
            this.buttonMult.Click += new System.EventHandler(this.makeAction);
            this.buttonDiv.Click += new System.EventHandler(this.makeAction);
            this.buttonCE.Click += new System.EventHandler(this.buttonCE_Click);
            this.buttonEqual.Click += new System.EventHandler(this.buttonEqual_Click);
        }

        private void addSymbol(object sender, EventArgs e)
        {
            var button = (System.Windows.Forms.Button)sender;
            String sym = button.Text;
            if (sym != "." || sym == "." && !this.result.Contains("."))
            {
                if (this.result == "0")
                {
                    this.result = "";
                }
                this.result += sym;
            } 
        }

        private void makeAction(object sender, EventArgs e)
        {
            var button = (System.Windows.Forms.Button)sender;
            String sym = button.Text;
            this.stash = this.result;
            this.result = "0";
            this.action = sym;
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            this.stash = "0";
            this.result = "0";
            this.action = "";
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case "+":
                    this.result = Convert.ToString(Convert.ToDouble(this.stash) + Convert.ToDouble(this.result));
                    break;
                case "-":
                    this.result = Convert.ToString(Convert.ToDouble(this.stash) - Convert.ToDouble(this.result));
                    break;
                case "*":
                    this.result = Convert.ToString(Convert.ToDouble(this.stash) * Convert.ToDouble(this.result));
                    break;
                case "/":
                    if (Convert.ToDouble(this.result) == 0)
                    {
                        this.result = "0";
                        break;
                    }
                    this.result = Convert.ToString(Convert.ToDouble(this.stash) / Convert.ToDouble(this.result));
                    break;
                default:
                    break;
            }
            this.stash = "0";
            this.action = "";
            Clipboard.SetText(this.resultLabel.Text);
        }
    }
}
