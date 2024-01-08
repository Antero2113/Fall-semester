namespace WordsDictionary1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.findButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.saveJSONButton = new System.Windows.Forms.Button();
            this.loadJSONButton = new System.Windows.Forms.Button();
            this.saveXMLButton = new System.Windows.Forms.Button();
            this.loadXMLButton = new System.Windows.Forms.Button();
            this.saveSQLiteButton = new System.Windows.Forms.Button();
            this.loadSQLiteButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openDictionaryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(776, 248);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(12, 317);
            this.searchTextBox.Multiline = true;
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(247, 80);
            this.searchTextBox.TabIndex = 1;
            // 
            // findButton
            // 
            this.findButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.findButton.Location = new System.Drawing.Point(267, 317);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(91, 37);
            this.findButton.TabIndex = 2;
            this.findButton.Text = "find";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addButton.Location = new System.Drawing.Point(267, 360);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(91, 37);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // saveJSONButton
            // 
            this.saveJSONButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveJSONButton.Location = new System.Drawing.Point(364, 317);
            this.saveJSONButton.Name = "saveJSONButton";
            this.saveJSONButton.Size = new System.Drawing.Size(137, 37);
            this.saveJSONButton.TabIndex = 4;
            this.saveJSONButton.Text = "save JSON";
            this.saveJSONButton.UseVisualStyleBackColor = true;
            this.saveJSONButton.Click += new System.EventHandler(this.saveJSONButton_Click);
            // 
            // loadJSONButton
            // 
            this.loadJSONButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadJSONButton.Location = new System.Drawing.Point(365, 360);
            this.loadJSONButton.Name = "loadJSONButton";
            this.loadJSONButton.Size = new System.Drawing.Size(137, 37);
            this.loadJSONButton.TabIndex = 5;
            this.loadJSONButton.Text = "load JSON";
            this.loadJSONButton.UseVisualStyleBackColor = true;
            this.loadJSONButton.Click += new System.EventHandler(this.loadJSONButton_Click);
            // 
            // saveXMLButton
            // 
            this.saveXMLButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveXMLButton.Location = new System.Drawing.Point(507, 317);
            this.saveXMLButton.Name = "saveXMLButton";
            this.saveXMLButton.Size = new System.Drawing.Size(137, 37);
            this.saveXMLButton.TabIndex = 6;
            this.saveXMLButton.Text = "save XML";
            this.saveXMLButton.UseVisualStyleBackColor = true;
            this.saveXMLButton.Click += new System.EventHandler(this.saveXMLButton_Click);
            // 
            // loadXMLButton
            // 
            this.loadXMLButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadXMLButton.Location = new System.Drawing.Point(508, 360);
            this.loadXMLButton.Name = "loadXMLButton";
            this.loadXMLButton.Size = new System.Drawing.Size(137, 37);
            this.loadXMLButton.TabIndex = 7;
            this.loadXMLButton.Text = "load XML";
            this.loadXMLButton.UseVisualStyleBackColor = true;
            this.loadXMLButton.Click += new System.EventHandler(this.loadXMLButton_Click);
            // 
            // saveSQLiteButton
            // 
            this.saveSQLiteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveSQLiteButton.Location = new System.Drawing.Point(651, 317);
            this.saveSQLiteButton.Name = "saveSQLiteButton";
            this.saveSQLiteButton.Size = new System.Drawing.Size(137, 37);
            this.saveSQLiteButton.TabIndex = 8;
            this.saveSQLiteButton.Text = "save SQLite";
            this.saveSQLiteButton.UseVisualStyleBackColor = true;
            this.saveSQLiteButton.Click += new System.EventHandler(this.saveSQLiteButton_Click);
            // 
            // loadSQLiteButton
            // 
            this.loadSQLiteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadSQLiteButton.Location = new System.Drawing.Point(651, 360);
            this.loadSQLiteButton.Name = "loadSQLiteButton";
            this.loadSQLiteButton.Size = new System.Drawing.Size(137, 37);
            this.loadSQLiteButton.TabIndex = 9;
            this.loadSQLiteButton.Text = "load SQLite";
            this.loadSQLiteButton.UseVisualStyleBackColor = true;
            this.loadSQLiteButton.Click += new System.EventHandler(this.loadSQLiteButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 422);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Кол-во слов с словаре: 0";
            // 
            // openDictionaryButton
            // 
            this.openDictionaryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.openDictionaryButton.Location = new System.Drawing.Point(508, 422);
            this.openDictionaryButton.Name = "openDictionaryButton";
            this.openDictionaryButton.Size = new System.Drawing.Size(280, 28);
            this.openDictionaryButton.TabIndex = 11;
            this.openDictionaryButton.Text = "Open Dictionary";
            this.openDictionaryButton.UseVisualStyleBackColor = true;
            this.openDictionaryButton.Click += new System.EventHandler(this.openDictionaryButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 458);
            this.Controls.Add(this.openDictionaryButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loadSQLiteButton);
            this.Controls.Add(this.saveSQLiteButton);
            this.Controls.Add(this.loadXMLButton);
            this.Controls.Add(this.saveXMLButton);
            this.Controls.Add(this.loadJSONButton);
            this.Controls.Add(this.saveJSONButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.treeView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button saveJSONButton;
        private System.Windows.Forms.Button loadJSONButton;
        private System.Windows.Forms.Button saveXMLButton;
        private System.Windows.Forms.Button loadXMLButton;
        private System.Windows.Forms.Button saveSQLiteButton;
        private System.Windows.Forms.Button loadSQLiteButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button openDictionaryButton;
    }
}

