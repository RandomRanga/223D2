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
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }

        private void buttonDisplayRecords_Click(object sender, EventArgs e)
        {
            //hide current form 
            Hide();
            //creates the new records page
            FormRentalRecords Records = new FormRentalRecords();
            //shows the records page window
            Records.ShowDialog();
            //close current open windoes so it is only the one showing. 
            this.Close();
        }

        private void buttonNewBooking_Click(object sender, EventArgs e)
        {
            //hide current form 
            Hide();
            //creates the new booking page
            formCreateBooking booking = new formCreateBooking();
            //shows the booking page window
            booking.ShowDialog();
            //close current open windoes so it is only the one showing. 
            this.Close();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            //hide current form 
            Hide();
            //creates the new login page
            formLogin login = new formLogin();
            //shows the login page window
            login.ShowDialog();
            //close current open windoes so it is only the one showing. 
            this.Close();



        }
    }
}
