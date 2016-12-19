using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        const int nCaixeres = 10;
        System.Diagnostics.Stopwatch clock = System.Diagnostics.Stopwatch.StartNew();

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            clock.Restart();
            Console.WriteLine($"** Inici Processant cues **");
            for (int i = 0; i < nCaixeres; i++)
            {
                var caixera = new Caixera() { Id = i };
                await Task.Run(() => caixera.ProcessarCua());
            }
            Console.WriteLine($"** Final Processant cues **");
            Text = $"Total A: {clock.ElapsedMilliseconds.ToString("n2")}";
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            clock.Restart();
            Console.WriteLine($"** Inici Processant cues **");
            for (int i = 0; i < nCaixeres; i++)
            {
                var caixera = new Caixera() { Id = i };
                await caixera.ProcessarCuaAsync();
            }
            Console.WriteLine($"** Final Processant cues **");
            Text = $"Total B: {clock.ElapsedMilliseconds.ToString("n2")}";
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            clock.Restart();
            var tasks = new List<Task>();
            Console.WriteLine($"** Inici Processant cues **");
            for (int i = 0; i < nCaixeres; i++)
            {
                var caixera = new Caixera() { Id = i };
                tasks.Add(caixera.ProcessarCuaAsync());
            }
            await Task.WhenAll(tasks);
            Console.WriteLine($"** Final Processant cues **");
            Text = $"Total C: {clock.ElapsedMilliseconds.ToString("n2")}";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var tasks = new List<Task>();
            var caixeres = new Caixera[nCaixeres];
            for (int i = 0; i < nCaixeres; i++)
            {
                caixeres[i] = new Caixera();
                caixeres[i].Id = i;
                var task = new Task(() =>
                              caixeres[i].ProcessarCua());


                tasks.Add(task);
                task.Start();

            }

        }
    }
}
