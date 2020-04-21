namespace AsyncAndAwaitTest
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Async = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_Task = new System.Windows.Forms.Button();
            this.btn_SimpleAsync = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Async
            // 
            this.btn_Async.Location = new System.Drawing.Point(12, 12);
            this.btn_Async.Name = "btn_Async";
            this.btn_Async.Size = new System.Drawing.Size(106, 23);
            this.btn_Async.TabIndex = 0;
            this.btn_Async.Text = "AsyncTest";
            this.btn_Async.UseVisualStyleBackColor = true;
            this.btn_Async.Click += new System.EventHandler(this.btn_Async_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(170, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(618, 426);
            this.textBox1.TabIndex = 1;
            // 
            // btn_Task
            // 
            this.btn_Task.Location = new System.Drawing.Point(13, 42);
            this.btn_Task.Name = "btn_Task";
            this.btn_Task.Size = new System.Drawing.Size(105, 23);
            this.btn_Task.TabIndex = 2;
            this.btn_Task.Text = "TaskTest";
            this.btn_Task.UseVisualStyleBackColor = true;
            this.btn_Task.Click += new System.EventHandler(this.btn_Task_Click);
            // 
            // btn_SimpleAsync
            // 
            this.btn_SimpleAsync.Location = new System.Drawing.Point(12, 72);
            this.btn_SimpleAsync.Name = "btn_SimpleAsync";
            this.btn_SimpleAsync.Size = new System.Drawing.Size(106, 23);
            this.btn_SimpleAsync.TabIndex = 3;
            this.btn_SimpleAsync.Text = "SimpleAsync";
            this.btn_SimpleAsync.UseVisualStyleBackColor = true;
            this.btn_SimpleAsync.Click += new System.EventHandler(this.btn_SimpleAsync_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(13, 102);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(105, 23);
            this.btn_Clear.TabIndex = 4;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "returnObject";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 415);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(13, 386);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_SimpleAsync);
            this.Controls.Add(this.btn_Task);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_Async);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Async;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_Task;
        private System.Windows.Forms.Button btn_SimpleAsync;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

