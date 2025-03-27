using System;
using System.Windows.Forms;
using BUS_QUANLYKHACHSAN;

namespace GUI_QUANLYKHACHSAN
{
    public partial class fBaoCao : Form
    {
        private BUS_PhieuThue bus_PhieuThue;

        public fBaoCao()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            bus_PhieuThue = new BUS_PhieuThue();
            radioKH.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioNgay.Checked == true)
            {
                if (radioDT.Checked == true)
                {                  
                    fDTN frm = new fDTN(dateTimePicker1.Value, dateTimePicker2.Value);
                    frm.Show();
                }
                if (radioKH.Checked == true)
                {
                    fKHN frm = new fKHN(dateTimePicker1.Value, dateTimePicker2.Value);
                    frm.Show();
                }
            }
            if (radioQuy.Checked == true)
            {
                if (comboBox1.Text == "" || textBox1.Text == "")
                {
                    MessageBox.Show("Mời nhập đủ dữ liệu.");
                    return;
                }
                if (radioDT.Checked == true)
                {
                    fDTQ frm = new fDTQ(int.Parse(comboBox1.Text), int.Parse(textBox1.Text));
                    frm.Show();
                }
                if (radioKH.Checked == true)
                {
                    fKNQ frm = new fKNQ(int.Parse(comboBox1.Text), int.Parse(textBox1.Text));
                    frm.Show();
                }
            }
        }

        private void fBaoCao_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                comboBox1.Items.Add(i + 1);
            }
        }
    }
}
