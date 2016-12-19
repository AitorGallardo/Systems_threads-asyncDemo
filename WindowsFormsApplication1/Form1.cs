using System;
using System.Collections.Generic;
using System.Threading;
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

        private  void button1_Click(object sender, EventArgs e)
        {
            clock.Restart();
            var tasks = new List<Task>();
            Console.WriteLine($"** Inici Processant cues **");
            for (int i = 0; i < nCaixeres; i++)
            {
                var caixera = new Caixera() { Id = i };

                 tasks.Add(Task.Run(() => caixera.ProcessarCua()));
            }
            Task.WaitAll(tasks.ToArray());
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
            clock.Restart();
            var threads = new List<Thread>();
            var caixeres = new Caixera[nCaixeres];
            for (int i = 0; i < nCaixeres; i++)
                {

                    var caixera = new Caixera() { Id = i  };
                    var thread = new Thread(() => caixera.ProcessarCua());
                    threads.Add(thread);
                    thread.Start();
                }


                foreach (Thread thread in threads)
                    thread.Join();
                Text = $"Total D: {clock.ElapsedMilliseconds.ToString("n2")}";

        }

    }
    
}
