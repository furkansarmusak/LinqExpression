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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            var sonuc = from urun in dc.Urunlers
                        join satisdetay in dc.SatisDetays on urun.UrunID equals satisdetay.UrunID
                        group satisdetay by urun.UrunAdi into grup
                        select new
                        {
                            UrunAdi = grup.Key,
                            ToplamSatis = grup.Sum(x=>x.Adet*x.Fiyat),
                        };
            dataGridView1.DataSource = sonuc;
                       

        }
    }
}
