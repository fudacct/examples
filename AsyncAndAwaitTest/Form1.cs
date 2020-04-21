using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAndAwaitTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btn_Async_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("test");
                ShowMessage("111 balabala. my thread id is:" + Thread.CurrentThread.ManagedThreadId);
                var resultTask = MethodAsync();
                textBox1.Text += await resultTask;
                ShowMessage("222 balabala. my thread id is:" + Thread.CurrentThread.ManagedThreadId);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
            
        }

        private async Task<string> MethodAsync()
        {
            var resultFromTimeConsumingMethod = TimeConsumingMethod();
            string result = await resultFromTimeConsumingMethod + " + MethodAsync. my thread id is:" + Thread.CurrentThread.ManagedThreadId + "\r\n";
            ShowMessage(result);
            return result;
        }

        private Task<string> TimeConsumingMethod()
        {
            var task = Task.Run(() =>
            {
                ShowMessage("Helo I am TimeConsumingMethod. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(5000);
                ShowMessage("Helo I am TimeConsumingMethod after Sleep(5000). My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(5000);
                return "Hello I am TimeConsumingMethod";
            });
            return task;
        }

        private async Task<string> MethodAsyncReturnObject()
        {
            var resultFromTimeConsumingMethod = TimeConsumingMethodReturnObject();
            ReturnObject returnObject = resultFromTimeConsumingMethod.Result;
            if (returnObject.Flag)
            {

            }
            string result = await resultFromTimeConsumingMethod + " + MethodAsync. my thread id is:" + Thread.CurrentThread.ManagedThreadId + "\r\n";
            ShowMessage(result);
            return result;
        }

        private async Task<ReturnObject> TimeConsumingMethodReturnObject()
        {
            var task = Task.Run(() =>
            {
                ReturnObject returnObject = new ReturnObject();
                returnObject.ReturnMessage1 = "Helo I am TimeConsumingMethod. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId;
                Thread.Sleep(5000);
                returnObject.ReturnMessage2 = "Helo I am TimeConsumingMethod after Sleep(5000). My Thread ID is :" + Thread.CurrentThread.ManagedThreadId;
                returnObject.ReturnMessage3 = "Hello I am TimeConsumingMethod";
                returnObject.Flag = true;
                return returnObject;
            });
            return await task;
        }

        private void ShowMessage(string message)
        {
            if (!textBox1.InvokeRequired)
                textBox1.AppendText(message + "\r\n");
            else
                textBox1.Invoke(new Action<string>(ShowMessage), new object[] { message });
        }


        private void btn_Clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private async void btn_SimpleAsync_Click(object sender, EventArgs e)
        {
            var resultTask = MethodAsync();
            textBox1.Text += await resultTask;
        }

        private void btn_Task_Click(object sender, EventArgs e)
        {
            var resultTask = Task.Run(() =>
            {
                ShowMessage("Helo I am TimeConsumingMethod. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(5000);
                ShowMessage("Helo I am TimeConsumingMethod after Sleep(5000). My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
                return "Hello I am TimeConsumingMethod";
            });
            resultTask.ContinueWith(OnDoSomthingIsComplete);
        }

        private void OnDoSomthingIsComplete(Task<string> t)
        {
            Action action = () => {
                textBox1.Text = t.Result+"\r\n";
            };
            textBox1.Invoke(action);
            ShowMessage("Continue Thread ID :" + Thread.CurrentThread.ManagedThreadId);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var resultTask = TimeConsumingMethodReturnObject();
            var returnResult = await resultTask;
            if (returnResult.Flag)
            {
                textBox1.AppendText(returnResult.ReturnMessage1 + "\r\n");
                textBox1.AppendText(returnResult.ReturnMessage2 + "\r\n");
                textBox1.AppendText(returnResult.ReturnMessage3 + "\r\n");
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                textBox1.AppendText(( MethodAsync2(i))+ "\r\n");
                Thread.Sleep(50);
                textBox1.AppendText(string.Format("main thread output:{0};thread id is:{1};\r\n", i, Thread.CurrentThread.ManagedThreadId));
            }
        }

        private async Task<ReturnObject> MethodAsync2(int inputValue)
        {
            ReturnObject returnObject = new ReturnObject();
            var task = Task.Run(() =>
            {
                for (int i = 0; i < 3; i++)
                {
                    if (inputValue % 2 == 0)
                        Thread.Sleep(2000);
                    ShowMessage(string.Format("async function output: input values is :{0};thread id is:{1};runing count is:{2}", inputValue, Thread.CurrentThread.ManagedThreadId, i));
                }
                return "you input is:"+ inputValue;
            });
            returnObject.ReturnMessage1 = await task;
            returnObject.Flag = true;
            ShowMessage(string.Format("111:{0}", inputValue));
            return returnObject;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("hello world!\r\n");
        }
    }

    public class ReturnObject
    {
        public string ReturnMessage1 { get; set; }
        public string ReturnMessage2 { get; set; }
        public string ReturnMessage3 { get; set; }
        public bool Flag { get; set; }
    }



}
