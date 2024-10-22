namespace MnS_L1_GoL
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            initDGV = new Button();
            SuspendLayout();
            // 
            // initDGV
            // 
            initDGV.Location = new Point(533, 789);
            initDGV.Name = "initDGV";
            initDGV.Size = new Size(94, 29);
            initDGV.TabIndex = 0;
            initDGV.Text = "Start";
            initDGV.UseVisualStyleBackColor = true;
            initDGV.Click += initDGV_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1204, 853);
            Controls.Add(initDGV);
            Name = "Form1";
            Text = "Game of Life in DataGridView";
            ResumeLayout(false);
        }

        #endregion

        private Button initDGV;
    }
}
