namespace CrMediaGenerator
{
	partial class NewSourceForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewSourceForm));
			this.Ok = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.rootAddressUrl = new System.Windows.Forms.TextBox();
			this.sectionsListText = new System.Windows.Forms.TextBox();
			this.Cancel = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.needDescription = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// Ok
			// 
			this.Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Ok.Location = new System.Drawing.Point(346, 309);
			this.Ok.Name = "Ok";
			this.Ok.Size = new System.Drawing.Size(75, 23);
			this.Ok.TabIndex = 0;
			this.Ok.Text = "ОК";
			this.Ok.UseVisualStyleBackColor = true;
			this.Ok.Click += new System.EventHandler(this.Ok_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(16, 20);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(132, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Корневой адрес";
			// 
			// rootAddressUrl
			// 
			this.rootAddressUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rootAddressUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.rootAddressUrl.Location = new System.Drawing.Point(20, 43);
			this.rootAddressUrl.Name = "rootAddressUrl";
			this.rootAddressUrl.Size = new System.Drawing.Size(494, 23);
			this.rootAddressUrl.TabIndex = 3;
			// 
			// sectionsListText
			// 
			this.sectionsListText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.sectionsListText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.sectionsListText.Location = new System.Drawing.Point(20, 102);
			this.sectionsListText.Multiline = true;
			this.sectionsListText.Name = "sectionsListText";
			this.sectionsListText.Size = new System.Drawing.Size(493, 173);
			this.sectionsListText.TabIndex = 4;
			// 
			// Cancel
			// 
			this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel.Location = new System.Drawing.Point(433, 309);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(75, 23);
			this.Cancel.TabIndex = 5;
			this.Cancel.Text = "ОТМЕНА";
			this.Cancel.UseVisualStyleBackColor = true;
			this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(16, 79);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 20);
			this.label3.TabIndex = 6;
			this.label3.Text = "Разделы";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(90, 83);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(230, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "(если есть - перечислить адреса построчно)";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(145, 25);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(130, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "(обязательнй параметр)";
			// 
			// needDescription
			// 
			this.needDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.needDescription.AutoSize = true;
			this.needDescription.Checked = true;
			this.needDescription.CheckState = System.Windows.Forms.CheckState.Checked;
			this.needDescription.Location = new System.Drawing.Point(20, 279);
			this.needDescription.Name = "needDescription";
			this.needDescription.Size = new System.Drawing.Size(154, 17);
			this.needDescription.TabIndex = 9;
			this.needDescription.Text = "Сгенерировать описание";
			this.needDescription.UseVisualStyleBackColor = true;
			// 
			// NewSourceForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(524, 341);
			this.Controls.Add(this.needDescription);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.Cancel);
			this.Controls.Add(this.sectionsListText);
			this.Controls.Add(this.rootAddressUrl);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.Ok);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimizeBox = false;
			this.Name = "NewSourceForm";
			this.Text = "Добавить директорию для нового источника";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button Ok;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox rootAddressUrl;
		private System.Windows.Forms.TextBox sectionsListText;
		private System.Windows.Forms.Button Cancel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox needDescription;
	}
}