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

            // Calculate the total length required for each column
            int col1Width = 20;
            int col2Width = 23;
            int col3Width = 23;
            int col4Width = 28;
            int col5Width = 28;
            int col6Width = 35;


            // Add row Headers with padding
            string row1Col1 = "Equipment Type";
            string row1Col2 = "Start Time";
            string row1Col3 = "Return Time";
            string row1Col4 = "PickUp Branch";
            string row1Col5 = "Return Branch";
            string row1Col6 = "Email";

            listBoxDisplay.Items.Add(
                row1Col1.PadRight(col1Width) +
                row1Col2.PadRight(col2Width) +
                row1Col3.PadRight(col3Width) +
                row1Col4.PadRight(col4Width) +
                row1Col5.PadRight(col5Width) +
                row1Col6.PadRight(col6Width));

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

                        listBoxAddItems(col1, col2, col3, col4, col5, col6);



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

        private void listBoxAddItems (string col1, string col2, string col3, string col4, string col5, string col6)
        {
              // Calculate the total length required for each column
            int col1Width = 20;
            int col2Width = 23;
            int col3Width = 23;
            int col4Width = 28;
            int col5Width = 28;
            int col6Width = 35;



            



          
            // Add headers with padding
            listBoxDisplay.Items.Add(
                col1.PadRight(col1Width) +
                col2.PadRight(col2Width) +
                col3.PadRight(col3Width) +
                col4.PadRight(col4Width) +
                col5.PadRight(col5Width) +
                col6.PadRight(col6Width));

            

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
