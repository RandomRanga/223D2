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
    public partial class FormRentalRecords : Form
    {
        public FormRentalRecords()
        {
            InitializeComponent();
            //sets the first item as the defult item in the combo box. 
            comboBoxFilter.SelectedIndex = 0;
            listBoxDisplay.Items.Clear();

        }




        public void DisplayRentals()
        {
            string query;

            //query = "SELECT \r\n    EquipmentType.TypeName, \r\n    Rental.startTime, \r\n    rentEquipment.returnTime, \r\n    Equipment.BranchName, \r\n    rentEquipment.returnTo, \r\n    Rental.CustomerEmail \r\nFROM \r\n    rentEquipment\r\nINNER JOIN \r\n    Rental ON rentEquipment.rRentalID = Rental.RentalID\r\nINNER JOIN \r\n    Equipment ON rentEquipment.rEquipmentID = Equipment.EquipmentID\r\nINNER JOIN \r\n    EquipmentType ON Equipment.TypeName = EquipmentType.TypeName;";

            





            // check what type of rental records we want to display
            if (comboBoxFilter.SelectedItem.ToString() == "All Rentals")
            {
                query = "SELECT \r\n    EquipmentType.TypeName, \r\n    Rental.startTime, \r\n    rentEquipment.returnTime, \r\n    Equipment.BranchName, \r\n    rentEquipment.returnTo, \r\n    Rental.CustomerEmail \r\nFROM \r\n    rentEquipment\r\nINNER JOIN \r\n    Rental ON rentEquipment.rRentalID = Rental.RentalID\r\nINNER JOIN \r\n    Equipment ON rentEquipment.rEquipmentID = Equipment.EquipmentID\r\nINNER JOIN \r\n    EquipmentType ON Equipment.TypeName = EquipmentType.TypeName;";
            }
            else if (comboBoxFilter.SelectedItem.ToString() == "On Going Rentals")
            {
                query = "SELECT \r\n    EquipmentType.TypeName, \r\n    Rental.startTime, \r\n    rentEquipment.returnTime, \r\n    Equipment.BranchName, \r\n    rentEquipment.returnTo, \r\n    Rental.CustomerEmail \r\nFROM \r\n    rentEquipment\r\nINNER JOIN \r\n    Rental ON rentEquipment.rRentalID = Rental.RentalID\r\nINNER JOIN \r\n    Equipment ON rentEquipment.rEquipmentID = Equipment.EquipmentID\r\nINNER JOIN \r\n    EquipmentType ON Equipment.TypeName = EquipmentType.TypeName\r\n\tWHERE (rentEquipment.returnTime is null) AND (rental.startTime < GETDATE())";
            }
            else if (comboBoxFilter.SelectedItem.ToString() == "Up Coming Rentals")
            {
                query = "SELECT \r\n    EquipmentType.TypeName, \r\n    Rental.startTime, \r\n    rentEquipment.returnTime, \r\n    Equipment.BranchName, \r\n    rentEquipment.returnTo, \r\n    Rental.CustomerEmail \r\nFROM \r\n    rentEquipment\r\nINNER JOIN \r\n    Rental ON rentEquipment.rRentalID = Rental.RentalID\r\nINNER JOIN \r\n    Equipment ON rentEquipment.rEquipmentID = Equipment.EquipmentID\r\nINNER JOIN \r\n    EquipmentType ON Equipment.TypeName = EquipmentType.TypeName\r\n\tWHERE (rentEquipment.returnTime is null) AND (rental.startTime > GETDATE())";
            }
            else if (comboBoxFilter.SelectedItem.ToString() == "Past Rentals")
            {
                query = "SELECT \r\n    EquipmentType.TypeName, \r\n    Rental.startTime, \r\n    rentEquipment.returnTime, \r\n    Equipment.BranchName, \r\n    rentEquipment.returnTo, \r\n    Rental.CustomerEmail \r\nFROM \r\n    rentEquipment\r\nINNER JOIN \r\n    Rental ON rentEquipment.rRentalID = Rental.RentalID\r\nINNER JOIN \r\n    Equipment ON rentEquipment.rEquipmentID = Equipment.EquipmentID\r\nINNER JOIN \r\n    EquipmentType ON Equipment.TypeName = EquipmentType.TypeName\r\n\tWHERE (rentEquipment.returnTime < GETDATE());";
            }
            else
            {
                MessageBox.Show("plese ensure you have filled in the Filter");
                return;
            }

            //The SQL select query, using the correct query choosen above
            SQL.selectQuery(query);

            //clear the listbox previous data
            listBoxDisplay.Items.Clear();

            try
            {
                if (SQL.read.HasRows)
                {
                    while (SQL.read.Read())
                    {
                        String col1 = SQL.read[0].ToString();
                        String col2 = SQL.read[1].ToString();
                        String col3 = SQL.read[2].ToString();
                        String col4 = SQL.read[3].ToString();
                        String col5 = SQL.read[4].ToString();
                        String col6 = SQL.read[5].ToString();

                        listBoxDisplay.Items.Add(col1 + col2 + col3 + col4 + col5 + col6);



                    }
                }
                else
                {
                    MessageBox.Show("No rentals can be found. Try again later. ");
                    return;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;

            }





        }


        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DisplayRentals();

        }

      
        private void buttonToMain_Click(object sender, EventArgs e)
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
