using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Caixera
    {
        public int Id { get; set; }
        public void ProcessarCua()
        {
            Console.WriteLine($"** Inici Processant cua...{Id} **");
            //fer algo heavy...
            Thread.Sleep(500);
            Console.WriteLine($"** Final Processant cua...{Id} **");
        }

        public async Task ProcessarCuaAsync()
        {
            Console.WriteLine($"** Inici Processant cua...{Id} **");
            //fer algo heavy...
            await Task.Delay(500);
            Console.WriteLine($"** Final Processant cua...{Id} **");
        }
    }
}
