namespace MnS_L1_GoL
{
    public partial class Form1 : Form
    {
        static DataGridView dataGridView1 = new()
        {
            AutoGenerateColumns = false
        };
        public Form1()
        {
            InitializeComponent();
            for (int i = 1; i <= 50; i++)
            {
                dataGridView1.Columns.Add("col" + i, "Column " + i);
                dataGridView1.Columns[i - 1].FillWeight = 1;
            }
            for (int j = 1; j <= 30; j++)
            {
                dataGridView1.Rows.Add();
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Value = 0;
                }
            }
            dataGridView1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.Silver;
            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
            this.AutoSize = true;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Controls.Add(dataGridView1);
        }

        private void initDGV_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the clicked cell
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Change the values
                if (cell.Value.ToString() == "0")
                {
                    cell.Value = 1;
                }
                else if (cell.Value.ToString() == "1")
                {
                    cell.Value = 0;
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check that the current cell being formatted isn't in a header
            if (dataGridView1.Columns[e.ColumnIndex].Name != "ColumnName" && e.RowIndex >= 0)
            {
                if (e.Value.ToString() == "0")
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.SelectionBackColor = Color.LightSalmon;
                }
                else if (e.Value.ToString() == "1")
                {
                    e.CellStyle.BackColor = Color.Green;
                    e.CellStyle.SelectionBackColor = Color.LightGreen;
                }
            }
        }
    }
}
