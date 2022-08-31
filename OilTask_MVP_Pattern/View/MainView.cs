using Guna.UI2.WinForms;
using OilTask_MVP_Pattern.Model;
using OilTask_MVP_Pattern.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OilTask_MVP_Pattern
{
    public partial class MainView : Form, IMainView
    {
        public List<Oil> Oils { get; set; } = new List<Oil>();
        public EventHandler<EventArgs> SelectedIndexChanged { get; set; }
        public EventHandler<EventArgs> CheckedChanged { get; set; }
        public EventHandler<EventArgs> TextChangedEvent { get; set; }
        public Guna2CustomGradientPanel Guna2Panel { get => guna2CustomGradientPanel1; set { guna2CustomGradientPanel1 = value; } }
        public ComboBox comboBox { get => comboBox1; set { comboBox1 = value; } }
        public string PriceLabelText { get => guna2HtmlLabel1.Text; set { guna2HtmlLabel1.Text = value; } }
        public GroupBox groupBox { get => groupBox1; set { groupBox = value; } }
        public string QuantityLabelText { get => quantityTxtb.Text; set { quantityTxtb.Text = value; } }
        public Oil SelectedOil { get; set; }
        public TextBox QuantityBoxText { get => quantityTxtb; set { quantityTxtb = value; } }
        public TextBox SumPriceBoxText { get => priceTxtb; set { priceTxtb = value; } }

        public string EndPriceLabelText { get => guna2SumPriceLabel.Text; set { guna2SumPriceLabel.Text = value; } }

       

        public MainView()
        {
            InitializeComponent();
            Oils.Add(new Oil { Name = "AI-92", Price = 1.0 });
            Oils.Add(new Oil { Name = "AI-95 Premium", Price = 1.60 });
            Oils.Add(new Oil { Name = "Diesel", Price = 0.8 });

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged.Invoke(sender, e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            SelectedIndexChanged.Invoke(sender, e);
        }

        private void quantityTxtb_TextChanged(object sender, EventArgs e)
        {
            TextChangedEvent.Invoke(sender,e);
        }

      
    }
}
