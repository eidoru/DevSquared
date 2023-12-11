namespace increment1forms
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
            logo = new PictureBox();
            topLine = new PictureBox();
            vectormathBtn = new Button();
            coordinatesystemsBtn = new Button();
            advancedvectormathBtn = new Button();
            matricesandtransformsBtn = new Button();
            interpolationBtn = new Button();
            bezierscurvesandpathsBtn = new Button();
            panel1 = new Panel();
            startactivityBtn = new Button();
            runBtn = new Button();
            backBtn = new Button();
            documentationBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)topLine).BeginInit();
            SuspendLayout();
            // 
            // logo
            // 
            logo.Image = Properties.Resources.DevSquaredAlphaLogo;
            logo.Location = new Point(12, 12);
            logo.Name = "logo";
            logo.Size = new Size(72, 33);
            logo.SizeMode = PictureBoxSizeMode.Zoom;
            logo.TabIndex = 0;
            logo.TabStop = false;
            // 
            // topLine
            // 
            topLine.Image = Properties.Resources.BlackSquare;
            topLine.Location = new Point(-3, 51);
            topLine.Name = "topLine";
            topLine.Size = new Size(1942, 1);
            topLine.SizeMode = PictureBoxSizeMode.StretchImage;
            topLine.TabIndex = 1;
            topLine.TabStop = false;
            // 
            // vectormathBtn
            // 
            vectormathBtn.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            vectormathBtn.Location = new Point(12, 58);
            vectormathBtn.Name = "vectormathBtn";
            vectormathBtn.Size = new Size(236, 29);
            vectormathBtn.TabIndex = 2;
            vectormathBtn.Text = "Vector Math";
            vectormathBtn.TextAlign = ContentAlignment.MiddleLeft;
            vectormathBtn.UseVisualStyleBackColor = true;
            vectormathBtn.Click += vectormathBtn_Click;
            // 
            // coordinatesystemsBtn
            // 
            coordinatesystemsBtn.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            coordinatesystemsBtn.Location = new Point(33, 86);
            coordinatesystemsBtn.Name = "coordinatesystemsBtn";
            coordinatesystemsBtn.Size = new Size(215, 29);
            coordinatesystemsBtn.TabIndex = 3;
            coordinatesystemsBtn.Text = "Coordinate Systems";
            coordinatesystemsBtn.TextAlign = ContentAlignment.MiddleLeft;
            coordinatesystemsBtn.UseVisualStyleBackColor = true;
            coordinatesystemsBtn.Click += coodinatesystemsBtn_Click;
            // 
            // advancedvectormathBtn
            // 
            advancedvectormathBtn.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            advancedvectormathBtn.Location = new Point(33, 114);
            advancedvectormathBtn.Name = "advancedvectormathBtn";
            advancedvectormathBtn.Size = new Size(215, 29);
            advancedvectormathBtn.TabIndex = 4;
            advancedvectormathBtn.Text = "Advanced Vector Math";
            advancedvectormathBtn.TextAlign = ContentAlignment.MiddleLeft;
            advancedvectormathBtn.UseVisualStyleBackColor = true;
            advancedvectormathBtn.Click += advancedvectormathBtn_Click;
            // 
            // matricesandtransformsBtn
            // 
            matricesandtransformsBtn.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            matricesandtransformsBtn.Location = new Point(33, 142);
            matricesandtransformsBtn.Name = "matricesandtransformsBtn";
            matricesandtransformsBtn.Size = new Size(215, 29);
            matricesandtransformsBtn.TabIndex = 5;
            matricesandtransformsBtn.Text = "Matrices and Transforms";
            matricesandtransformsBtn.TextAlign = ContentAlignment.MiddleLeft;
            matricesandtransformsBtn.UseVisualStyleBackColor = true;
            matricesandtransformsBtn.Click += matricesandtransformsBtn_Click;
            // 
            // interpolationBtn
            // 
            interpolationBtn.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            interpolationBtn.Location = new Point(33, 170);
            interpolationBtn.Name = "interpolationBtn";
            interpolationBtn.Size = new Size(215, 29);
            interpolationBtn.TabIndex = 6;
            interpolationBtn.Text = "Interpolation";
            interpolationBtn.TextAlign = ContentAlignment.MiddleLeft;
            interpolationBtn.UseVisualStyleBackColor = true;
            interpolationBtn.Click += interpolationBtn_Click;
            // 
            // bezierscurvesandpathsBtn
            // 
            bezierscurvesandpathsBtn.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            bezierscurvesandpathsBtn.Location = new Point(33, 198);
            bezierscurvesandpathsBtn.Name = "bezierscurvesandpathsBtn";
            bezierscurvesandpathsBtn.Size = new Size(215, 29);
            bezierscurvesandpathsBtn.TabIndex = 7;
            bezierscurvesandpathsBtn.Text = "Beziers, Curves, and Paths";
            bezierscurvesandpathsBtn.TextAlign = ContentAlignment.MiddleLeft;
            bezierscurvesandpathsBtn.UseVisualStyleBackColor = true;
            bezierscurvesandpathsBtn.Click += bezierscurvesandpathsBtn_Click;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Location = new Point(268, 52);
            panel1.Name = "panel1";
            panel1.Size = new Size(1657, 1006);
            panel1.TabIndex = 8;
            // 
            // startactivityBtn
            // 
            startactivityBtn.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            startactivityBtn.Location = new Point(1793, 12);
            startactivityBtn.Name = "startactivityBtn";
            startactivityBtn.Size = new Size(119, 29);
            startactivityBtn.TabIndex = 9;
            startactivityBtn.Text = "Start Activity";
            startactivityBtn.UseVisualStyleBackColor = true;
            startactivityBtn.Click += startactivityBtn_Click;
            // 
            // runBtn
            // 
            runBtn.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            runBtn.Location = new Point(150, 900);
            runBtn.Name = "runBtn";
            runBtn.Size = new Size(94, 29);
            runBtn.TabIndex = 10;
            runBtn.Text = "Run";
            runBtn.UseVisualStyleBackColor = true;
            runBtn.Click += runBtn_Click;
            // 
            // backBtn
            // 
            backBtn.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            backBtn.Location = new Point(1684, 12);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(94, 29);
            backBtn.TabIndex = 11;
            backBtn.Text = "Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // documentationBtn
            // 
            documentationBtn.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            documentationBtn.Location = new Point(106, 16);
            documentationBtn.Name = "documentationBtn";
            documentationBtn.Size = new Size(142, 29);
            documentationBtn.TabIndex = 12;
            documentationBtn.Text = "Documentation";
            documentationBtn.UseVisualStyleBackColor = true;
            documentationBtn.Click += documentationBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1055);
            Controls.Add(documentationBtn);
            Controls.Add(backBtn);
            Controls.Add(runBtn);
            Controls.Add(startactivityBtn);
            Controls.Add(panel1);
            Controls.Add(bezierscurvesandpathsBtn);
            Controls.Add(interpolationBtn);
            Controls.Add(matricesandtransformsBtn);
            Controls.Add(advancedvectormathBtn);
            Controls.Add(coordinatesystemsBtn);
            Controls.Add(vectormathBtn);
            Controls.Add(topLine);
            Controls.Add(logo);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ((System.ComponentModel.ISupportInitialize)topLine).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox logo;
        private PictureBox topLine;
        private Button vectormathBtn;
        private Button coordinatesystemsBtn;
        private Button advancedvectormathBtn;
        private Button matricesandtransformsBtn;
        private Button interpolationBtn;
        private Button bezierscurvesandpathsBtn;
        private Panel panel1;
        private Button startactivityBtn;
        private Button runBtn;
        private Button backBtn;
        private Button documentationBtn;
    }
}