using System.Collections.Generic;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class MainControl : UserControl
    {
        public MainControl(Dictionary<string, int> childData, Dictionary<string, int> employeeData, Dictionary<string, Room> rooms)
        {
            InitializeComponent();

            llText.Text = childData["ll"].ToString();
            ttText.Text = childData["tt"].ToString();
            bb1Text.Text = childData["bb1"].ToString();
            bb2Text.Text = childData["bb2"].ToString();
            ff1Text.Text = childData["ff1"].ToString();
            ff2Text.Text = childData["ff2"].ToString();
            bhText.Text = childData["bh"].ToString();
            bmText.Text = childData["bm"].ToString();
            saText.Text = childData["sa"].ToString();
            totalText.Text = childData["total"].ToString();

            ellText.Text = employeeData["ll"].ToString();
            ettText.Text = employeeData["tt"].ToString();
            ebb1Text.Text = employeeData["bb1"].ToString();
            ebb2Text.Text = employeeData["bb2"].ToString();
            eff1Text.Text = employeeData["ff1"].ToString();
            eff2Text.Text = employeeData["ff2"].ToString();
            ebhText.Text = employeeData["bh"].ToString();
            ebmText.Text = employeeData["bm"].ToString();
            esaText.Text = employeeData["sa"].ToString();
            etotalText.Text = employeeData["total"].ToString();

            llRText.Text = rooms["LL"].Ratio.ToString();
            if (GetRatio(childData["ll"], employeeData["ll"]) > rooms["LL"].Ratio) llRText.ForeColor = System.Drawing.Color.Red;
            llCText.Text = rooms["LL"].Capacity.ToString();
            if (childData["ll"] > rooms["LL"].Capacity && rooms["LL"].Capacity != 0) llCText.ForeColor = System.Drawing.Color.Red;

            ttRText.Text = rooms["TT"].Ratio.ToString();
            if (GetRatio(childData["tt"], employeeData["tt"]) > rooms["TT"].Ratio) ttRText.ForeColor = System.Drawing.Color.Red;
            ttCText.Text = rooms["TT"].Capacity.ToString();
            if (childData["tt"] > rooms["TT"].Capacity && rooms["TT"].Capacity != 0) ttCText.ForeColor = System.Drawing.Color.Red;

            bb1RText.Text = rooms["BB1"].Ratio.ToString();
            if (GetRatio(childData["bb1"], employeeData["bb1"]) > rooms["BB1"].Ratio) bb1RText.ForeColor = System.Drawing.Color.Red;
            bb1CText.Text = rooms["BB1"].Capacity.ToString();
            if (childData["bb1"] > rooms["BB1"].Capacity && rooms["BB1"].Capacity != 0) bb1CText.ForeColor = System.Drawing.Color.Red;

            bb2RText.Text = rooms["BB2"].Ratio.ToString();
            if (GetRatio(childData["bb2"], employeeData["bb2"]) > rooms["BB2"].Ratio) bb2RText.ForeColor = System.Drawing.Color.Red;
            bb2CText.Text = rooms["BB2"].Capacity.ToString();
            if (childData["bb2"] > rooms["BB2"].Capacity && rooms["BB2"].Capacity != 0) bb2CText.ForeColor = System.Drawing.Color.Red;

            ff2RText.Text = rooms["FF2"].Ratio.ToString();
            if (GetRatio(childData["ff2"], employeeData["ff2"]) > rooms["FF2"].Ratio) ff2RText.ForeColor = System.Drawing.Color.Red;
            ff2CText.Text = rooms["FF2"].Capacity.ToString();
            if (childData["ff2"] > rooms["FF2"].Capacity && rooms["FF2"].Capacity != 0) ff2CText.ForeColor = System.Drawing.Color.Red;

            ff1RText.Text = rooms["FF1"].Ratio.ToString();
            if (GetRatio(childData["ff1"], employeeData["ff1"]) > rooms["FF1"].Ratio) ff1RText.ForeColor = System.Drawing.Color.Red;
            ff1CText.Text = rooms["FF1"].Capacity.ToString();
            if (childData["ff1"] > rooms["FF1"].Capacity && rooms["FF1"].Capacity != 0) ff1CText.ForeColor = System.Drawing.Color.Red;

            bhRText.Text = rooms["BH"].Ratio.ToString();
            if (GetRatio(childData["bh"], employeeData["bh"]) > rooms["BH"].Ratio) bhRText.ForeColor = System.Drawing.Color.Red;
            bhCText.Text = rooms["BH"].Capacity.ToString();
            if (childData["bh"] > rooms["BH"].Capacity && rooms["BH"].Capacity != 0) bhCText.ForeColor = System.Drawing.Color.Red;

            bmRText.Text = rooms["BM"].Ratio.ToString();
            if (GetRatio(childData["bm"], employeeData["bm"]) > rooms["BM"].Ratio) bmRText.ForeColor = System.Drawing.Color.Red;
            bmCText.Text = rooms["BM"].Capacity.ToString();
            if (childData["bm"] > rooms["BM"].Capacity && rooms["BM"].Capacity != 0) bmCText.ForeColor = System.Drawing.Color.Red;

            saRText.Text = rooms["SA"].Ratio.ToString();
            if (GetRatio(childData["sa"], employeeData["sa"]) > rooms["SA"].Ratio) saRText.ForeColor = System.Drawing.Color.Red;
            saCText.Text = rooms["SA"].Capacity.ToString();
            if (childData["sa"] > rooms["SA"].Capacity && rooms["SA"].Capacity != 0) saCText.ForeColor = System.Drawing.Color.Red;

            ToolTip toolTip = new ToolTip();

            toolTip.SetToolTip(ratioLabel, "Red values in this column indicate that there are not enough employees to maintain the ratio for the number of kids in this room.");
            toolTip.SetToolTip(capLabel, "Red values in this column indicate that there are more kids in this room than its capacity supports.");
        }

        private int GetRatio(int children, int employees)
        {
            if (children == 0 && employees == 0)
                return 0;

            if (employees == 0)
                return int.MaxValue;

            return children / employees;
        }
    }
}
