using OilTask_MVP_Pattern.Model;
using OilTask_MVP_Pattern.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OilTask_MVP_Pattern.Presenter
{
    public class MainPresenter
    {
        private readonly IMainView _view;
        public MainPresenter(IMainView view)
        {

            _view = view;
            var selection = _view.Oils.Select(o => o.Name);
            _view.CheckedChanged += ViewCheckedChanged;
            _view.SelectedIndexChanged += ViewSelectedIndexChanged;
            _view.TextChangedEvent += ViewTextChanged;
            _view.comboBox.DataSource = selection.ToList();
        }

        public void ViewTextChanged(object sender, EventArgs e)
        {
            foreach (var item in _view.groupBox.Controls)
            {
                if (item is RadioButton rb)
                {
                    if (rb.Checked == true && rb.Text == "Quantity")
                    {
                        if (_view.QuantityBoxText.Text != "")
                        {
                            var quantity = double.Parse(_view.QuantityBoxText.Text);
                            _view.EndPriceLabelText = (quantity * _view.SelectedOil.Price).ToString() + " $";
                        }
                    }
                    else if (rb.Checked == true && rb.Text == "Sum")
                    {

                        if (_view.SumPriceBoxText.Text != "")
                        {

                            var sum = double.Parse(_view.SumPriceBoxText.Text);
                            _view.EndPriceLabelText = sum.ToString()+" $";
                        }

                    }
                    else if (_view.QuantityBoxText.Text == "" && _view.QuantityBoxText.Enabled == true || _view.SumPriceBoxText.Text == "" && _view.SumPriceBoxText.Enabled==true)
                    {
                        _view.EndPriceLabelText = "";
                    }
                }
            }
        }


        public void ViewCheckedChanged(object sender, EventArgs e)
        {

            var rb = sender as RadioButton;

            if (rb.Checked == true && rb.Text == "Quantity")
            {
                _view.QuantityBoxText.Enabled = true;
                _view.SumPriceBoxText.Enabled = false;
            }
            else if (rb.Checked == true && rb.Text == "Sum")
            {
                _view.QuantityBoxText.Enabled = false;
                _view.SumPriceBoxText.Enabled = true;
            }
        }

        public Oil Helper(string oilName)
        {
            foreach (var item in _view.Oils)
            {
                if (item.Name == oilName)
                {
                    return item;
                }
            }
            return null;
        }
        public void ViewSelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            var selectedOil = comboBox.SelectedItem;

            _view.SelectedOil = Helper(selectedOil.ToString());
            _view.PriceLabelText = _view.SelectedOil.Price.ToString();
        }
    }
}
