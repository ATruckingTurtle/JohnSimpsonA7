namespace JohnSimpsonA7
{
    partial class CarForm
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
            CarDisplay = new ListBox();
            FileButton = new Button();
            SortMake = new Button();
            SortMakeAndPrice = new Button();
            SuspendLayout();
            // 
            // CarDisplay
            // 
            CarDisplay.FormattingEnabled = true;
            CarDisplay.ItemHeight = 15;
            CarDisplay.Location = new Point(12, 12);
            CarDisplay.Name = "CarDisplay";
            CarDisplay.Size = new Size(776, 349);
            CarDisplay.TabIndex = 0;
            // 
            // FileButton
            // 
            FileButton.Location = new Point(82, 381);
            FileButton.Name = "FileButton";
            FileButton.Size = new Size(98, 23);
            FileButton.TabIndex = 1;
            FileButton.Text = "Open New File?";
            FileButton.UseVisualStyleBackColor = true;
            FileButton.Click += this.FileButton_Click;
            // 
            // SortMake
            // 
            SortMake.Location = new Point(356, 381);
            SortMake.Name = "SortMake";
            SortMake.Size = new Size(86, 23);
            SortMake.TabIndex = 2;
            SortMake.Text = "Sort By Make";
            SortMake.UseVisualStyleBackColor = true;
            // 
            // SortMakeAndPrice
            // 
            SortMakeAndPrice.Location = new Point(617, 373);
            SortMakeAndPrice.Name = "SortMakeAndPrice";
            SortMakeAndPrice.Size = new Size(87, 38);
            SortMakeAndPrice.TabIndex = 3;
            SortMakeAndPrice.Text = "Sort By Make and Price";
            SortMakeAndPrice.UseVisualStyleBackColor = true;
            // 
            // CarForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(SortMakeAndPrice);
            Controls.Add(SortMake);
            Controls.Add(FileButton);
            Controls.Add(CarDisplay);
            Name = "CarForm";
            Text = "John Simpson Assignment 7";
            ResumeLayout(false);
        }

        #endregion

        private ListBox CarDisplay;
        private Button FileButton;
        private Button SortMake;
        private Button SortMakeAndPrice;
    }
}
