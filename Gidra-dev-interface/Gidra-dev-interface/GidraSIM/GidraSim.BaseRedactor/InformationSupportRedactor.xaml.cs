using GidraSIM.Core.Model.Resources;
using System;
using System.Windows;


namespace GidraSim.BaseRedactor
{
    /// <summary>
    /// Логика взаимодействия для InformationSupportRedactor.xaml
    /// </summary>
    public partial class InformationSupportRedactor : Window
    {
        public InformationSupportRedactor()
        {
            InitializeComponent();
        }

        public InformationSupport curINF;

        private void InfSupSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                curINF = new InformationSupport()
                {
                    Price = Convert.ToDecimal(_price.Text),
                    Type = (TypeIS)type.SelectedIndex,
                    MultiClientUse = (bool)_MultiClientUse.IsChecked       
                };

                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
