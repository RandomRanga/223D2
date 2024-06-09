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


        private bool checkTextBoxes()
        {

            bool holdsData = true;
            //go through all of the controls
            foreach (Control c in this.Controls)
            {
                //if its a textbox, but doesnt matter if its middle textbox
                if (c is TextBox )
                {
                    //If it is not the case that it is empty
                    if ("".Equals((c as TextBox).Text.Trim()))
                    {
                        //set boolean to false because on textbox is empty
                        holdsData = false;
                    }
                }
            }
            //returns true or false based on if data is in all text boxs or not
            return holdsData;
        }






        private void buttonAdd_Click(object sender, EventArgs e)
        {

            string equipmentType = "", startTime = "", branchName = "", email = "";
            
            equipmentType = comboBoxEquipmentName.SelectedItem.ToString();
            startTime = textBoxStart.Text.Trim();
            branchName = comboBoxPickUp.SelectedItem.ToString();
            email = comboBoxEmail.SelectedItem.ToString();





            
            // Check if all necessary details are provided
            if (string.IsNullOrEmpty(equipmentType) || string.IsNullOrEmpty(startTime) || string.IsNullOrEmpty(branchName) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter all the necessary details.");
                return;
            }

            try
            {
                // Query the database to retrieve the EquipmentID based on the equipment type
                string query = @"
            SELECT TOP 1 e.EquipmentID
            FROM Equipment e
            WHERE e.available = 1
              AND e.TypeName = '" + equipmentType + "'";

                // Call the selectQuery method to execute the query
                SQL.selectQuery(query);

                // Check if any equipment is found for the provided type
                if (SQL.read.HasRows)
                {
                    // Read the EquipmentID from the result set
                    SQL.read.Read();
                    int equipmentID = SQL.read["EquipmentID"] != DBNull.Value ? Convert.ToInt32(SQL.read["EquipmentID"]) : 0;

                    if (equipmentID == 0)
                    {
                        MessageBox.Show("No available equipment found for the specified type.");
                        return;
                    }

                    // Insert a new rental record
                    string insertRentalQuery = @"
                INSERT INTO Rental (startTime, hireFrom, CustomerEmail)
                VALUES ('" + startTime + "', '" + branchName + "', '" + email + "')";

                    // Execute the insertion query
                    SQL.executeQuery(insertRentalQuery);

                    // Retrieve the RentalID of the newly inserted rental record
                    string getRentalIDQuery = "SELECT SCOPE_IDENTITY()";
                    SQL.selectQuery(getRentalIDQuery);

                    if (SQL.read.HasRows)
                    {
                        SQL.read.Read();
                        int rentalID = SQL.read[0] != DBNull.Value ? Convert.ToInt32(SQL.read[0]) : 0;

                        if (rentalID == 0)
                        {
                            MessageBox.Show("Failed to create rental record.");
                            return;
                        }

                        // Link the rented equipment to the rental in the rentEquipment table
                        string linkEquipmentQuery = @"
                    INSERT INTO rentEquipment (rEquipmentID, rRentalID, returnTime, returnTo)
                    VALUES (" + equipmentID + ", " + rentalID + ", NULL, NULL)";

                        SQL.executeQuery(linkEquipmentQuery);

                        // Update the equipment status to unavailable
                        string updateEquipmentQuery = "UPDATE Equipment SET available = 0 WHERE EquipmentID = " + equipmentID;
                        SQL.executeQuery(updateEquipmentQuery);

                        // Notify the user of a successful booking
                        MessageBox.Show($"Successfully booked {equipmentType} for hire, picking it up from {branchName} at {startTime} for the email: {email}");
                    }
                    else
                    {
                        MessageBox.Show("Failed to retrieve RentalID.");
                    }
                }
                else
                {
                    MessageBox.Show("No available equipment found for the specified type.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

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



        private void buttonHelp_Click(object sender, EventArgs e)
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



            //insert into Rental table 
            string insertRental = @"
                INSERT INTO Rental (startTime, hireFrom, CustomerEmail)
                VALUES ('" + startTime + "', '" + branchName + "', '" + email + "')";

            SQL.executeQuery(insertRental);

            //gets the rental ID using the helper method. 
            int rentalID = GetRentalID();

            //string insertRentEquipment = @"
            //    INSERT INTO rentEquipment ( rEquipmentID, rRentalID)
	           // VALUES ('" + equipmentID + "', '" + RentalID + "')";

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



        private void comboBoxEquipmentName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
