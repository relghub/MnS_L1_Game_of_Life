namespace MnS_L1_GoL
{
	public partial class Form1 : Form
	{
		static DataGridView dataGridView1 = new()
		{
			AutoGenerateColumns = false
		};
		static List<(int, int)> aliveCells = [],
						   aliveNeighbours = [],
								cellsToDie = [],
							 cellsToRevive = [];
		static bool keepLooping = true;

		public Form1()
		{
			InitializeComponent();
			for (int i = 1; i <= 50; i++)
			{
				dataGridView1.Columns.Add("col" + i, "Column " + i);
				dataGridView1.Columns[i - 1].FillWeight = 1;
			}
			for (int j = 1; j <= 29; j++)
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
			dataGridView1.GridColor = Color.Black;
			dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
			dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
			this.AutoSize = true;
			this.FormBorderStyle = FormBorderStyle.Fixed3D;
			this.Controls.Add(dataGridView1);
		}

		private void initDGV_Click(object sender, EventArgs e)
		{
			Thread thread = new Thread(GoL_Loop);
			thread.Start();
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
					e.CellStyle.BackColor = Color.Black;
					e.CellStyle.ForeColor = e.CellStyle.BackColor;
				}
				else if (e.Value.ToString() == "1")
				{
					e.CellStyle.BackColor = Color.White;
					e.CellStyle.ForeColor = e.CellStyle.BackColor;
				}
			}
		}
		private void GoL_Loop()
		{
			while (keepLooping)
			{
				aliveCells.Clear();
				cellsToDie.Clear();
				cellsToRevive.Clear();

				foreach (DataGridViewRow row in dataGridView1.Rows)
				{
					foreach (DataGridViewCell cell in row.Cells)
					{
						if ((int)cell.Value == 1)
						{
							aliveCells.Add((cell.RowIndex, cell.ColumnIndex));
						}
					}
				}

				for (int i = 0; i <= 29; i++)
				{
					for (int j = 0; j <= 49; j++)
					{
						for (int k = i - 1; k <= i + 1; k++)
						{
							for (int l = j - 1; l <= j + 1; l++)
							{
								int row = (k + 30) % 30;  // Wrap around
								int col = (l + 50) % 50;

								if (row == i && col == j) continue;  // Skip the cell itself

								if ((int)dataGridView1.Rows[row].Cells[col].Value == 1)
								{
									aliveNeighbours.Add((row, col));
								}
							}
						}

						if ((aliveNeighbours.Count < 2 || aliveNeighbours.Count > 3) && aliveCells.Contains((i, j)))
						{
							cellsToDie.Add((i, j));
						}
						else if (!aliveCells.Contains((i, j)) && (aliveNeighbours.Count == 3 || aliveNeighbours.Count == 4))
						{
							cellsToRevive.Add((i, j));
						}

						aliveNeighbours.Clear();
					}
				}

				foreach ((int row, int col) in cellsToDie)
				{
					dataGridView1.Rows[row].Cells[col].Value = 0;
				}

				foreach ((int row, int col) in cellsToRevive)
				{
					dataGridView1.Rows[row].Cells[col].Value = 1;
				}
				Thread.Sleep(100);
			}
		}
	}
}
