using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oqituvchi_test
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new Buttonlar.SavolQoshish());
            //Application.Run(new Buttonlar.SavolTahrirlash());
            //Application.Run(new Buttonlar.TalabaNatijalari());
           //Application.Run(new Talaba.testishlash());
           //  Application.Run(new Talaba.TestBoshlash());
          // Application.Run(new Admin());
             Application.Run(new Loading());
           // Application.Run(new Form1());
        }
    }
}
