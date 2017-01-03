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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void btn_order_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            var sonuc = from urun in dc.Urunlers
                        orderby urun.Fiyat descending
                        select urun;
            dataGridView1.DataSource = sonuc;

        }

        private void btn_filtre_Click(object sender, EventArgs e)
        {
             DataClasses1DataContext dc = new DataClasses1DataContext();
            DateTime tarih = Convert.ToDateTime(maskedTextBox1.Text);
            var sonuc = from satis in dc.Satislars
                        where satis.SatisTarihi == tarih
                        select satis;

            dataGridView1.DataSource = sonuc;
        }
    }
}
