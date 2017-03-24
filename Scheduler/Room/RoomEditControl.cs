using System;
using System.Globalization;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class RoomEditControl : UserControl
    {
        private string roomCode;
        public RoomEditControl(Room room)
        {
            InitializeComponent();
            roomCode = room.Code;

            if (room != null)
            {
                nameBox.Text = room.Name;
                descBox.Text = room.Desc;
                ratioBox.Text = room.Ratio.ToString(CultureInfo.InvariantCulture);
                capacityBox.Text = room.Capacity.ToString(CultureInfo.InvariantCulture);
            }

            ratioBox.KeyPress += numberEntry_KeyPress;
            capacityBox.KeyPress += numberEntry_KeyPress;
        }

        private void numberEntry_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == 8);
        }

        public Room GetRoomFromData()
        {
            if (nameBox.Text == "")
            {
                MessageBox.Show("Room name cannot be empty.", "Invalid Entry");
                return null;
            }
            if (descBox.Text == "")
            {
                MessageBox.Show("Room description cannot be empty.", "Invalid Entry");
                return null;
            }
            if (ratioBox.Text == "")
            {
                MessageBox.Show("Ratio cannot be empty.", "Invalid Entry");
                return null;
            }
            if (capacityBox.Text == "")
            {
                MessageBox.Show("Capacity cannot be empty.", "Invalid Entry");
                return null;
            }

            return new Room(nameBox.Text, descBox.Text, roomCode, Convert.ToInt32(ratioBox.Text), Convert.ToInt32(capacityBox.Text));
        }
    }
}
