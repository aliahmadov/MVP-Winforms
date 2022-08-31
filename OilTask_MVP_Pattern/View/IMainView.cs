using Guna.UI2.WinForms;
using OilTask_MVP_Pattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OilTask_MVP_Pattern.View
{
    public interface IMainView
    {

        List<Oil> Oils { get; set; }

        EventHandler<EventArgs> TextChangedEvent { get;set; }
        EventHandler<EventArgs> SelectedIndexChanged { get; set; }
        EventHandler<EventArgs> CheckedChanged { get; set; }    
        Guna2CustomGradientPanel Guna2Panel { get; set; }
        ComboBox comboBox { get; set; }   
        string PriceLabelText { get; set; } 
       GroupBox groupBox { get; set; }
        TextBox QuantityBoxText { get; set; }  
        TextBox SumPriceBoxText { get; set; }  
        string EndPriceLabelText { get; set; }

        Oil SelectedOil { get; set; }

    }
}
