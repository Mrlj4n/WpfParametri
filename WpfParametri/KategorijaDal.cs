using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WpfParametri
{
    static class KategorijaDal
    {
        //pre sortiranja List<Kategorija> VratiKategorije()
        //public static List<Kategorija> VratiKategorije()
        // {
        //     List<Kategorija> listaKategorija = new List<Kategorija>();

        //     using (SqlConnection konekcija = new SqlConnection(Konekcija.cnnMagacin))
        //     {
        //         using (SqlCommand komanda = new SqlCommand("select * from Kategorija",konekcija))
        //         {
        //             try
        //             {
        //                 konekcija.Open();
        //                 SqlDataReader dr = komanda.ExecuteReader();
        //                 while (dr.Read())
        //                 {
        //                     Kategorija k = new Kategorija { 
        //                         KategorijaId = dr.GetInt32(0),
        //                         NazivKategorije = dr.GetString(1),
        //                         OpisKategorije = dr.GetString(2)
        //                     };

        //                     listaKategorija.Add(k);
        //                 }

        //                 return listaKategorija;
        //             }
        //             catch (Exception)
        //             {
        //                 return null;
        //             }
        //         }
        //     }
        // }

        public static List<Kategorija> VratiKategorije()
        {
            List<Kategorija> listaKategorija = new List<Kategorija>();

            using (SqlConnection konekcija = new SqlConnection(Konekcija.cnnMagacin))
            {
                using (SqlCommand komanda = new SqlCommand("select * from Kategorija ORDER BY NazivKategorije", konekcija))
                {
                    try
                    {
                        konekcija.Open();
                        SqlDataReader dr = komanda.ExecuteReader();
                        while (dr.Read())
                        {
                            Kategorija k = new Kategorija
                            {
                                KategorijaId = dr.GetInt32(0),
                                NazivKategorije = dr.GetString(1),
                                OpisKategorije = dr.GetString(2)
                            };

                            listaKategorija.Add(k);
                        }

                        return listaKategorija;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
        }

        //pre sortiranja UbaciKategoriju(Kategorija k)
        //public static int UbaciKategoriju(Kategorija k)
        //{//0, -1 greska
        //    string por = "";
        //    using (SqlConnection konekcija = new SqlConnection(Konekcija.cnnMagacin))
        //    {
        //        using (SqlCommand komanda = new SqlCommand("INSERT INTO Kategorija VALUES(@NazivKategorije, @OpisKategorije)", konekcija))
        //        {

        //            try
        //            {
        //                komanda.Parameters.AddWithValue("@NazivKategorije", k.NazivKategorije);
        //                komanda.Parameters.AddWithValue("@OpisKategorije", k.OpisKategorije);

        //                konekcija.Open();
        //                komanda.ExecuteNonQuery();

        //                return 0;

        //            }
        //            catch (Exception)
        //            {

        //                return -1;
        //            }

        //        }
        //    }
        //}

        public static int UbaciKategoriju(Kategorija k)
        {//0, -1 greska
            string por = "";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT INTO Kategorija VALUES(@NazivKategorije, @OpisKategorije)");
            sb.AppendLine("SELECT CAST(SCOPE_IDENTITY() AS int)");

            int Id = 0;
            using (SqlConnection konekcija = new SqlConnection(Konekcija.cnnMagacin))
            {
                using (SqlCommand komanda = new SqlCommand(sb.ToString(), konekcija))
                {

                    try
                    {
                        komanda.Parameters.AddWithValue("@NazivKategorije", k.NazivKategorije);
                        komanda.Parameters.AddWithValue("@OpisKategorije", k.OpisKategorije);

                        konekcija.Open();
                        Id = (int)komanda.ExecuteScalar();

                        return Id;

                    }
                    catch (Exception)
                    {

                        return -1;
                    }

                }
            }
        }

        public static int PromeniKategoriju(Kategorija k)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("UPDATE Kategorija");
            sb.AppendLine("Set NazivKategorije= @NazivKategorije,");
            sb.AppendLine("OpisKategorije = @OpisKategorije");
            sb.AppendLine("WHERE KategorijaId = @KategorijaId");

            using (SqlConnection konekcija = new SqlConnection(Konekcija.cnnMagacin))
            {
                using (SqlCommand komanda = new SqlCommand(sb.ToString(),konekcija))
                {
                    try
                    {
                        komanda.Parameters.AddWithValue("@KategorijaId", k.KategorijaId);
                        komanda.Parameters.AddWithValue("@NazivKategorije", k.NazivKategorije);
                        komanda.Parameters.AddWithValue("@OpisKategorije", k.OpisKategorije);
                        konekcija.Open();
                        komanda.ExecuteNonQuery();

                        return 0;
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
            }
        }

        public static int ObrisiKategoriju(int id)
        {
            using (SqlConnection konekcija = new SqlConnection(Konekcija.cnnMagacin))
            {
                using (SqlCommand komanda = new SqlCommand("DELETE FROM Kategorija WHERE KategorijaId=@KategorijaId",konekcija))
                {
                    try
                    {
                        komanda.Parameters.AddWithValue("@KategorijaId", id);
                        konekcija.Open();
                        komanda.ExecuteNonQuery();
                        return 0;
                    }
                    catch (Exception)
                    {

                        return -1;
                    }
                }
            }
        }
    }
}
