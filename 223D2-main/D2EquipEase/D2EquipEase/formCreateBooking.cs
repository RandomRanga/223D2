using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace D2EquipEase
{
    public partial class formCreateBooking : Form
    {
        public formCreateBooking()
        {
            InitializeComponent();

            try
            {
                string EquipmentType = "SELECT TypeName FROM EquipmentType";
                string pickUpBranch = "SELECT BranchName FROM branch ";
                string Email = "SELECT Email FROM Customer";
                
                SQL.editComboBoxItems(comboBoxEquipmentName, EquipmentType);
                
                SQL.editComboBoxItems(comboBoxPickUp, pickUpBranch);
                SQL.editComboBoxItems(comboBoxEmail, Email);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }



        }


        private bool checksInputs()
        {
            if (comboBoxEquipmentName.SelectedIndex == -1 || comboBoxPickUp.SelectedIndex == -1 || comboBoxEmail.SelectedIndex == -1 )
            {
                return false;
            }
            return true;
        }

        private bool checkDate(string startTimeInput)
        {
            DateTime startTime;
            string Format = "yyyy-MM-dd HH:mm:ss";
            if (!DateTime.TryParseExact(startTimeInput, Format, null, System.Globalization.DateTimeStyles.None, out startTime))
            {
                return false;
            }
            return true ;
        }



        private void buttonAdd_Click(object sender, EventArgs e)
        {
 
            // Get the equipment type entered by the user from the textbox
            string equipmentType = comboBoxEquipmentName.SelectedItem.ToString();
            //uses the helper function to get the equipmentID
            int equipmentID = GetEquipmentID(equipmentType);
            //ensures that the input was valid else exits
            if (equipmentID == -1)
            {
                return;
            }
            //gets the the time which the user wants to start hiring the item
            string startTime = textBoxStart.Text.Trim();
            //gets the branch for where the user want to pick it up from 
            string branchName = comboBoxPickUp.SelectedItem.ToString();
            //gets the users email and checks it is in the database could use helper method in the future.
            string email = comboBoxEmail.SelectedItem.ToString();

            
            if (!checksInputs())
            {
                MessageBox.Show("Please ensure you have filled in all inputs.");
                return;
            }
            if (!checkDate(startTime))
            {
                MessageBox.Show("Please double check the date format.\nNeeds to be yyyy-MM-dd HH:mm:ss");
                return;
            }


            //insert into Rental table 
            string insertRental = @"
                INSERT INTO Rental (startTime, hireFrom, CustomerEmail)
                VALUES ('" + startTime + "', '" + branchName + "', '" + email + "')";

            SQL.executeQuery(insertRental);

            //gets the rental ID using the helper method. 
            int rentalID = GetRentalID();

            //inserts into the rentEquipment table, uses variables to stop sql injections
            string rentEquipmentQuery = "INSERT INTO rentEquipment (rEquipmentID, rRentalID) VALUES (@equipmentID, @rentalID)";
            using (SqlCommand command = new SqlCommand(rentEquipmentQuery, SQL.con))
            {
                command.Parameters.AddWithValue("@equipmentID", equipmentID);
                command.Parameters.AddWithValue("@rentalID", rentalID);
                SQL.read?.Close();
                command.ExecuteNonQuery();
            }
            MessageBox.Show($"Successfull. Pick up the {equipmentType} on the {startTime} from {branchName}, for {email}.");


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








        public int GetEquipmentID(string equipmentType)
        {
            // Check if the equipment type is provided
            if (string.IsNullOrEmpty(equipmentType))
            {
                MessageBox.Show("Please enter an equipment type.");
                return -1;
                
            }

            try
            {
                // uses the query to get the equipment ID
                string query = @"
                    SELECT TOP 1 EquipmentID
                    FROM Equipment
                    WHERE available = 1
                    AND TypeName = '" + equipmentType + "'";

                
                SQL.selectQuery(query);

              
                if (SQL.read.HasRows)
                {
                    // read and store the equipment ID
                    SQL.read.Read();
                    int equipmentID = Convert.ToInt32(SQL.read["EquipmentID"]);

                    // return the ID
                    return equipmentID;
                }
                else
                {
                    MessageBox.Show("No available equipment found for the specified type.");
                    return -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                return -1;

            }

            


        }


        public int GetRentalID()
        {
            string getRentalIDQuery = "SELECT SCOPE_IDENTITY()";
            using (SqlCommand cmd = new SqlCommand(getRentalIDQuery, SQL.con))
            {
                SQL.read = cmd.ExecuteReader();
                if (SQL.read.HasRows)
                {
                    SQL.read.Read();
                    return SQL.read[0] != DBNull.Value ? Convert.ToInt32(SQL.read[0]) : 0;
                }
                return 0;
            }
        }

        private void buttonOrder_Click(object sender, EventArgs e)
        {
            try
            {
                string orderQuery = @"
                        SELECT TypeName, purchaseDate
                        FROM Equipment
                        ORDER BY purchaseDate DESC";


                SQL.editComboBoxItems(comboBoxEquipmentName, orderQuery);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void buttonOrderAlphabetical_Click(object sender, EventArgs e)
        {
            string EquipmentType = "SELECT TypeName FROM EquipmentType";
            SQL.editComboBoxItems(comboBoxEquipmentName, EquipmentType);
        }

        private void buttonAvaviable_Click(object sender, EventArgs e)
        {

            string branchName = comboBoxPickUp.SelectedItem.ToString();



            try
            {
                string orderQuery = "SELECT Equipment.TypeName\r\nFROM Equipment\r\nWHERE branchName ='"  + branchName + "'AND available = 1 ORDER BY purchaseDate DESC";


                SQL.editComboBoxItems(comboBoxEquipmentName, orderQuery);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }





        }
    }
}
