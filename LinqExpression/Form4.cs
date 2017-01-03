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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            var sonuc = from satis in dc.Satislars
                        join personel in dc.Personellers on satis.PersonelID equals personel.PersonelID
                        group satis by personel.Adi into grup
                        select new 
                        {
                        personelAdi =grup.Key,
                        toplamSatis = grup.Count()
                        };

            dataGridView1.DataSource = sonuc;

        }
    }
}
