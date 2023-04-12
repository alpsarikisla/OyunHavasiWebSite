using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;
        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.ConStr);
            cmd = con.CreateCommand();
        }

        #region Admin Metotları

        public Yonetici YoneticiGiris(string kullaniciAdi, string sifre)
        {
            try
            {
                Yonetici y = new Yonetici();
                cmd.CommandText = "SELECT COUNT(*) FROM Yoneticiler WHERE KullaniciAdi = @ka AND Sifre = @s";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ka", kullaniciAdi);
                cmd.Parameters.AddWithValue("@s", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi == 1)
                {
                    cmd.CommandText = "SELECT * FROM Yoneticiler WHERE KullaniciAdi = @ka AND Sifre = @s";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ka", kullaniciAdi);
                    cmd.Parameters.AddWithValue("@s", sifre);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        y.ID = reader.GetInt32(0);
                        y.YoneticiTur_ID = reader.GetInt32(1);
                        y.Isim = reader.GetString(2);
                        y.Soyisim = reader.GetString(3);
                        y.KullaniciAdi = reader.GetString(4);
                        y.Mail = reader.GetString(5);
                        y.Sifre = reader.GetString(6);
                        y.Durum = reader.GetBoolean(7);
                    }
                    return y;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Uye Metotları

        public Uye UyeGiris(string mail, string sifre)
        {
            try
            {
                Uye y;
                cmd.CommandText = "SELECT COUNT(*) FROM Uyeler WHERE Mail = @m AND Sifre = @s";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@m", mail);
                cmd.Parameters.AddWithValue("@s", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi == 1)
                {
                    cmd.CommandText = "SELECT * FROM Uyeler WHERE Mail = @ka AND Sifre = @s";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ka", mail);
                    cmd.Parameters.AddWithValue("@s", sifre);
                    SqlDataReader reader = cmd.ExecuteReader();
                    y = new Uye();
                    while (reader.Read())
                    {
                        y.ID = reader.GetInt32(0);
                        y.Isim = reader.GetString(1);
                        y.Soyisim = reader.GetString(2);
                        y.KullaniciAdi = reader.GetString(3);
                        y.Mail = reader.GetString(4);
                        y.Sifre = reader.GetString(5);
                        y.UyelikTarihi = reader.GetDateTime(6);
                        y.Durum = reader.GetBoolean(7);
                    }
                    return y;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Kategori Metotları

        public bool KategoriEkle(Kategori kat)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Kategoriler(Isim) VALUES(@isim)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", kat.Isim);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Kategori> KategoriListele()
        {
            List<Kategori> kategoriler = new List<Kategori>();
            try
            {
                cmd.CommandText = "SELECT ID,Isim FROM Kategoriler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Kategori k = new Kategori();
                    k.ID = reader.GetInt32(0);
                    k.Isim = reader.GetString(1);
                    kategoriler.Add(k);
                }
                return kategoriler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Kategori KategoriGetir(int id)
        {
            Kategori k = new Kategori();
            try
            {
                cmd.CommandText = "SELECT ID, Isim FROM Kategoriler WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    k.ID = reader.GetInt32(0);
                    k.Isim = reader.GetString(1);
                }
                return k;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool KategoriDuzenle(Kategori kat)
        {
            try
            {
                cmd.CommandText = "UPDATE Kategoriler SET Isim = @i WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", kat.ID);
                cmd.Parameters.AddWithValue("@i", kat.Isim);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public void KategoriSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Kategoriler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Makale Metotları

        public bool MakaleEkle(Makale mak)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Makaleler (Kategori_ID, Yazar_ID, Baslik, Ozet, Icerik, KapakResim, BegeniSayi, GoruntulemeSayi, YayinDurumu, Silinmis,EklemeTarihi) VALUES(@kategori_ID, @yazar_ID, @baslik, @ozet, @icerik, @kapakResim, @begeniSayi, @goruntulemeSayi, @yayinDurum, @silinmis, @eklemeTarih)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kategori_ID", mak.Kategori_ID);
                cmd.Parameters.AddWithValue("@yazar_ID", mak.Yazar_ID);
                cmd.Parameters.AddWithValue("@baslik", mak.Baslik);
                cmd.Parameters.AddWithValue("@ozet", mak.Ozet);
                cmd.Parameters.AddWithValue("@icerik", mak.Icerik);
                cmd.Parameters.AddWithValue("@kapakResim", mak.KapakResim);
                cmd.Parameters.AddWithValue("@begeniSayi", mak.BegeniSayi);
                cmd.Parameters.AddWithValue("@goruntulemeSayi", mak.GoruntulemeSayi);
                cmd.Parameters.AddWithValue("@yayinDurum", mak.YayinDurumu);
                cmd.Parameters.AddWithValue("@silinmis", mak.Silinmis);
                cmd.Parameters.AddWithValue("@eklemeTarih", mak.EklemeTarih);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Makale> MakaleListele()
        {
            List<Makale> makaleler = new List<Makale>();
            try
            {
                cmd.CommandText = "SELECT M.[ID],M.[Kategori_ID],K.Isim, M.[Yazar_ID], Y.KullaniciAdi, M.[Baslik], M.[Ozet],M.[Icerik], M.[KapakResim], M.[GoruntulemeSayi], M.[BegeniSayi], M.[EklemeTarihi],M.[YayinDurumu],M.[Silinmis] FROM Makaleler AS M JOIN Kategoriler AS K ON M.Kategori_ID = K.ID JOIN Yoneticiler AS Y ON M.Yazar_ID = Y.ID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Makale mak = new Makale();
                    mak.ID = reader.GetInt32(0);
                    mak.Kategori_ID = reader.GetInt32(1);
                    mak.Kategori = reader.GetString(2);
                    mak.Yazar_ID = reader.GetInt32(3);
                    mak.Yazar = reader.GetString(4);
                    mak.Baslik = reader.GetString(5);
                    mak.Ozet = reader.GetString(6);
                    mak.Icerik = reader.GetString(7);
                    mak.KapakResim = reader.GetString(8);
                    mak.GoruntulemeSayi = reader.GetInt32(9);
                    mak.BegeniSayi = reader.GetInt32(10);
                    mak.EklemeTarih = reader.GetDateTime(11);
                    mak.EklemeTarihStr = mak.EklemeTarih.ToShortDateString();
                    mak.YayinDurumu = reader.GetBoolean(12);
                    mak.YayinDurumuStr = reader.GetBoolean(12) == true ? "<span class='yayinda'>Aktif</span>" : "<span class='yayindadegil'>Pasif</span>";
                    mak.Silinmis = reader.GetBoolean(13);
                    makaleler.Add(mak);
                }
                return makaleler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Makale MakaleGetir(int id)
        {
           
            try
            {
                cmd.CommandText = "SELECT M.[ID],M.[Kategori_ID],K.Isim, M.[Yazar_ID], Y.KullaniciAdi, M.[Baslik], M.[Ozet],M.[Icerik], M.[KapakResim], M.[GoruntulemeSayi], M.[BegeniSayi], M.[EklemeTarihi],M.[YayinDurumu],M.[Silinmis] FROM Makaleler AS M JOIN Kategoriler AS K ON M.Kategori_ID = K.ID JOIN Yoneticiler AS Y ON M.Yazar_ID = Y.ID WHERE M.ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Makale mak = new Makale();
                while (reader.Read())
                {
                    mak.ID = reader.GetInt32(0);
                    mak.Kategori_ID = reader.GetInt32(1);
                    mak.Kategori = reader.GetString(2);
                    mak.Yazar_ID = reader.GetInt32(3);
                    mak.Yazar = reader.GetString(4);
                    mak.Baslik = reader.GetString(5);
                    mak.Ozet = reader.GetString(6);
                    mak.Icerik = reader.GetString(7);
                    mak.KapakResim = reader.GetString(8);
                    mak.GoruntulemeSayi = reader.GetInt32(9);
                    mak.BegeniSayi = reader.GetInt32(10);
                    mak.EklemeTarih = reader.GetDateTime(11);
                    mak.EklemeTarihStr = mak.EklemeTarih.ToShortDateString();
                    mak.YayinDurumu = reader.GetBoolean(12);
                    mak.YayinDurumuStr = reader.GetBoolean(12) == true ? "<span class='yayinda'>Aktif</span>" : "<span class='yayindadegil'>Pasif</span>";
                    mak.Silinmis = reader.GetBoolean(13);
                }
                return mak;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Yorum Metotları

        public bool YorumEkle(Yorum y)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Yorumlar (Uye_ID,Makale_ID,Icerik,EklemeTarihi,BegeniSayi,Durum) VALUES(@uye_ID,@makale_ID,@icerik,@eklemeTarihi,@begeniSayi,@durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@uye_ID", y.Uye_ID);
                cmd.Parameters.AddWithValue("@makale_ID", y.Makale_ID);
                cmd.Parameters.AddWithValue("@icerik", y.Icerik);
                cmd.Parameters.AddWithValue("@eklemeTarihi", y.EklemeTarihi);
                cmd.Parameters.AddWithValue("@begeniSayi", y.BegeniSayi);
                cmd.Parameters.AddWithValue("@durum", y.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Yorum> YorumListele()
        {
            try
            {
                List<Yorum> yorumlar = new List<Yorum>();
                cmd.CommandText = "SELECT Y.ID, Y.Makale_ID, M.Baslik, Y.Uye_ID, U.KullaniciAdi, Y.Icerik, Y.EklemeTarihi, Y.BegeniSayi,Y.Durum FROM Yorumlar AS Y JOIN Makaleler AS M ON Y.Makale_ID=M.ID JOIN Uyeler AS U ON Y.Uye_ID= U.ID ";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Yorum y = new Yorum();
                    y.ID = reader.GetInt32(0);
                    y.Makale_ID = reader.GetInt32(1);
                    y.Makale = reader.GetString(2);
                    y.Uye_ID = reader.GetInt32(3);
                    y.Uye = reader.GetString(4);
                    y.Icerik = reader.GetString(5);
                    y.EklemeTarihi = reader.GetDateTime(6);
                    y.EklemeTarihiStr = reader.GetDateTime(6).ToShortDateString();
                    y.BegeniSayi = reader.GetInt32(7);
                    y.Durum = reader.GetBoolean(8);
                    y.DurumStr = reader.GetBoolean(8) == true ? "<span class='yayinda'>Onaylı</span>" : "<span class='yayindadegil'>Onay Bekliyor</span>";
                    yorumlar.Add(y);
                }
                return yorumlar;
               
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Yorum> YorumListele(int makid)
        {
            try
            {
                List<Yorum> yorumlar = new List<Yorum>();
                cmd.CommandText = "SELECT Y.ID, Y.Makale_ID, M.Baslik, Y.Uye_ID, U.KullaniciAdi, Y.Icerik, Y.EklemeTarihi, Y.BegeniSayi,Y.Durum FROM Yorumlar AS Y JOIN Makaleler AS M ON Y.Makale_ID=M.ID JOIN Uyeler AS U ON Y.Uye_ID= U.ID WHERE Y.Durum=1 AND Y.Makale_ID = @id ORDER BY Y.EklemeTarihi DESC";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", makid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Yorum y = new Yorum();
                    y.ID = reader.GetInt32(0);
                    y.Makale_ID = reader.GetInt32(1);
                    y.Makale = reader.GetString(2);
                    y.Uye_ID = reader.GetInt32(3);
                    y.Uye = reader.GetString(4);
                    y.Icerik = reader.GetString(5);
                    y.EklemeTarihi = reader.GetDateTime(6);
                    y.EklemeTarihiStr = reader.GetDateTime(6).ToShortDateString();
                    y.BegeniSayi = reader.GetInt32(7);
                    y.Durum = reader.GetBoolean(8);
                    yorumlar.Add(y);
                }
                return yorumlar;

            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Yorum> YorumListele(bool durum)
        {
            try
            {
                List<Yorum> yorumlar = new List<Yorum>();
                cmd.CommandText = "SELECT Y.ID, Y.Makale_ID, M.Baslik, Y.Uye_ID, U.KullaniciAdi, Y.Icerik, Y.EklemeTarihi, Y.BegeniSayi,Y.Durum FROM Yorumlar AS Y JOIN Makaleler AS M ON Y.Makale_ID=M.ID JOIN Uyeler AS U ON Y.Uye_ID= U.ID WHERE Y.Durum = @durum";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@durum", durum);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Yorum y = new Yorum();
                    y.ID = reader.GetInt32(0);
                    y.Makale_ID = reader.GetInt32(1);
                    y.Makale = reader.GetString(2);
                    y.Uye_ID = reader.GetInt32(3);
                    y.Uye = reader.GetString(4);
                    y.Icerik = reader.GetString(5);
                    y.EklemeTarihi = reader.GetDateTime(6);
                    y.EklemeTarihiStr = reader.GetDateTime(6).ToShortDateString();
                    y.BegeniSayi = reader.GetInt32(7);
                    y.Durum = reader.GetBoolean(8);
                    yorumlar.Add(y);
                }
                return yorumlar;

            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public void YorumOnayla(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Yorumlar SET Durum=1 WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        public void YorumSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Yorumlar WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        #endregion
    }
}
