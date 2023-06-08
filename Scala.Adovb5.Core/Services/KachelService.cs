using Scala.Adovb5.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scala.Adovb5.Core.Services
{
    public class KachelService
    {
        public List<Soort> GetSoorten()
        {
            string sql;
            sql = "select * from soorten order by soortnaam";
            List<Soort> soorten = new List<Soort>();
            DataTable dt = DBServices.ExecuteSelect(sql);
            foreach (DataRow dr in dt.Rows)
            {
                string id = dr["id"].ToString();
                string soortnaam = dr["soortnaam"].ToString();
                soorten.Add(new Soort(id, soortnaam));
            }
            return soorten;
        }
        //private bool SoortInUse(Soort soort)
        //{

        //}
        //private bool SoortnaamExists(Soort soort)
        //{

        //}
        //public bool SoortToevoegen(Soort soort)
        //{

        //}
        //public bool SoortWijzigen(Soort soort)
        //{

        //}
        //public bool SoortVerwijderen(Soort soort)
        //{

        //}

        public List<Kachel> GetKachels(Soort soortFilter = null)
        {
            string sql;
            sql = "select * from kachels ";
            if (soortFilter != null)
            {
                sql += $" where soortid = '{soortFilter.Id}' ";
            }
            sql += " order by merk, serie";
            List<Kachel> kachels = new List<Kachel>();
            DataTable dt = DBServices.ExecuteSelect(sql);
            foreach (DataRow dr in dt.Rows)
            {
                string id = dr["id"].ToString();
                string soortId = dr["soortid"].ToString();
                string merk = dr["merk"].ToString();
                string serie = dr["serie"].ToString();
                decimal prijs = decimal.Parse(dr["prijs"].ToString());
                kachels.Add(new Kachel(id, soortId, merk, serie, prijs));
            }
            return kachels;
        }
        public bool KachelToevoegen(Kachel kachel)
        {
            string sql;
            sql = "insert into kachels (id, soortid, merk, serie, prijs) ";
            sql += " values (";
            sql += $" '{kachel.Id}' , ";
            sql += $" '{kachel.SoortId}' , ";
            sql += $" '{Helper.HandleQuotes(kachel.Merk)}' , ";
            sql += $" '{Helper.HandleQuotes(kachel.Serie)}' , ";
            sql += $" {kachel.Prijs} )";
            return DBServices.ExecuteCommand(sql);
        }
        public bool KachelWijzigen(Kachel kachel)
        {
            string sql;
            sql = "update kachels set ";
            sql += $" soortid = '{kachel.SoortId}' , ";
            sql += $" merk = '{Helper.HandleQuotes(kachel.Merk)}' , ";
            sql += $" serie = '{Helper.HandleQuotes(kachel.Serie)}' , ";
            sql += $" prijs = {kachel.Prijs} ";
            return DBServices.ExecuteCommand(sql);
        }
        public bool KachelVerwijderen(Kachel kachel)
        {
            string sql = "delete from kachels ";
            sql += $" where id = '{kachel.Id}' ";
            return DBServices.ExecuteCommand(sql);
        }
    }
}
