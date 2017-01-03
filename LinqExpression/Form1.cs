using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Collections.Generic;
using System.Reflection;
using System.Linq.Expressions;


namespace LinqExpression
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
           
            DataClasses1DataContext dc = new DataClasses1DataContext();
            dataGridView1.DataSource = from urun in dc.Urunlers
                                       join kategori in dc.Kategorilers
                                       on urun.KategoriID equals kategori.KategoriID
                                       select new 
                                       {
                                           kategori.KategoriAdi,
                                           urun.UrunAdi,
                                           urun.Fiyat,
                                           urun.Stok,
                                       
                                       };

        }
    }
}
