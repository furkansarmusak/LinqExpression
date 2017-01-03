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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            dataGridView1.DataSource = from urun in dc.Urunlers
                                       join siparisDetay in dc.SatisDetays
                                       on urun.UrunID equals siparisDetay.UrunID
                                       join satis in dc.Satislars on siparisDetay.SatisID equals satis.SatisID
                                       join musteri in dc.Musterilers on satis.MusteriID equals musteri.MusteriID
                                       join personel in dc.Personellers on satis.PersonelID equals personel.PersonelID
                                       join tedarik in dc.Tedarikcilers on urun.TedarikciID equals tedarik.TedarikciID
                                       join kat in dc.Kategorilers on urun.KategoriID equals kat.KategoriID
                                       select new
                                       {
                                           urun.UrunAdi,
                                           urun.Fiyat,
                                           TedarikciAdi = tedarik.SirketAdi,
                                           kat.KategoriAdi,
                                           Musteri = musteri.SirketAdi,
                                           SatisFiyat = urun.Fiyat,
                                           SiparisFiyat = siparisDetay.Fiyat,
                                           siparisDetay.Adet,
                                           siparisDetay.Indirim,
                                           Personel = personel.Adi+" "+personel.SoyAdi,

                                       };

        }
    }
}
