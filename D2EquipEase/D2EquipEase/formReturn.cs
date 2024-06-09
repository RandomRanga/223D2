using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D2EquipEase
{
    public partial class formReturn : Form
    {
        public formReturn()
        {
            InitializeComponent();

            try
            {
                //sets the time in text box to current time 
                textBoxTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:00");
                //sets up all possible return locations 
                string returnBranch = "SELECT BranchName FROM branch ";
                SQL.editComboBoxItems(comboBoxReturn, returnBranch);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }








        private void buttonReturn_Click(object sender, EventArgs e)
        {
            try
            {
                //check all inputs 


                // init all variables 
                string equipmentID = numericUpDownEquipmentID.Text.Trim();
                string returnTime = textBoxTime.Text.Trim();
                string returnBranch = comboBoxReturn.SelectedItem.ToString().Trim();

                string query = $@"
                    UPDATE rentEquipment
                    SET returnTime = '{returnTime}', returnTo = '{returnBranch}'
                    WHERE rEquipmentID = {equipmentID} AND returnTime IS NULL;";

                SQL.executeQuery(query);

                MessageBox.Show("Success, ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("sorry you Equipment was not returned, please try again" + ex.ToString());
            }

        }






        private void buttonMain_Click(object sender, EventArgs e)
        {
            //hide current form 
            Hide();
            //creates the new main page
            formMain main = new formMain();
            //shows the records page window
            main.ShowDialog();
            //close current open windoes so it is only the one showing. 
            this.Close();
        }

        
    }
}
