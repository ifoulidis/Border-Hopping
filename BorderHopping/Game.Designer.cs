namespace BorderHopping
{
  partial class Game
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this._pictureBox = new System.Windows.Forms.PictureBox();
      this.scoreLabel = new System.Windows.Forms.Label();
      this.timer = new System.Windows.Forms.Timer(this.components);
      ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).BeginInit();
      this.SuspendLayout();
      // 
      // _pictureBox
      // 
      this._pictureBox.Location = new System.Drawing.Point(12, 12);
      this._pictureBox.Name = "_pictureBox";
      this._pictureBox.Size = new System.Drawing.Size(776, 426);
      this._pictureBox.TabIndex = 0;
      this._pictureBox.TabStop = false;
      this._pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
      this._pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this._pictureBox_MouseClick);
      // 
      // scoreLabel
      // 
      this.scoreLabel.AutoSize = true;
      this.scoreLabel.Location = new System.Drawing.Point(40, 31);
      this.scoreLabel.Name = "scoreLabel";
      this.scoreLabel.Size = new System.Drawing.Size(38, 13);
      this.scoreLabel.TabIndex = 1;
      this.scoreLabel.Text = "Score:";
      // 
      // timer
      // 
      this.timer.Enabled = true;
      this.timer.Interval = 90;
      this.timer.Tick += new System.EventHandler(this.timerTick);
      // 
      // Game
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.scoreLabel);
      this.Controls.Add(this._pictureBox);
      this.ForeColor = System.Drawing.Color.Black;
      this.Name = "Game";
      this.Text = "Border Hopping";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox _pictureBox;
    private System.Windows.Forms.Label scoreLabel;
    private System.Windows.Forms.Timer timer;
  }
}

