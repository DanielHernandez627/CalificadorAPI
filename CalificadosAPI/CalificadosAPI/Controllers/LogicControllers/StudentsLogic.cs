using System.Data;
using CalificadosAPI.DAO;
using Newtonsoft.Json;
using CalificadosAPI.Models;

namespace CalificadosAPI.Controllers.LogicControllers
{
    public class StudentsLogic
    {
        Conexion  cn = new Conexion(); 

        public dynamic obtenerEstudiantes()
        {
            string query;
            DataTable dt;
            string json;

            query = "SELECT es.id, min(es.Nombre) + ' ' + min(es.Apellidos) as Nombre,CONVERT(DECIMAL(10,1),avg(nt.Nota)) as final FROM Estudiantes es INNER JOIN Notas nt ON es.id = nt.id_estudiante group by es.id order by es.id";

            dt = cn.Execonsultas(query);

            if (dt.Rows.Count > 0)
            {
                json = JsonConvert.SerializeObject(dt); 
            }
            else
            {
                json = JsonConvert.SerializeObject("Not data");
            }

            return json;
        }

        public dynamic obtenerMejorNota()
        {
            string query;
            DataTable dt;
            string json;            

            query = "SELECT es.id, min(es.Nombre) + ' ' + min(es.Apellidos) as Nombre,CONVERT(DECIMAL(10,1),avg(nt.Nota)) as final FROM Estudiantes es INNER JOIN Notas nt ON es.id = nt.id_estudiante group by es.id order by es.id";

            dt = cn.Execonsultas(query);

            if (dt.Rows.Count > 0)
            {
                DataView dtv = dt.DefaultView;
                dtv.Sort = "final DESC";
                dt = dtv.ToTable();
                json = JsonConvert.SerializeObject(dt);
            }
            else
            {
                json = JsonConvert.SerializeObject("Not data");
            }

            return json;
        }

        public dynamic obtenerPeorNota()
        {
            string query;
            DataTable dt;
            string json;

            query = "SELECT es.id, min(es.Nombre) + ' ' + min(es.Apellidos) as Nombre,CONVERT(DECIMAL(10,1),avg(nt.Nota)) as final FROM Estudiantes es INNER JOIN Notas nt ON es.id = nt.id_estudiante group by es.id order by es.id";

            dt = cn.Execonsultas(query);

            if (dt.Rows.Count > 0)
            {
                DataView dtv = dt.DefaultView;
                dtv.Sort = "final ASC";
                dt = dtv.ToTable();
                json = JsonConvert.SerializeObject(dt);
            }
            else
            {
                json = JsonConvert.SerializeObject("Not data");
            }

            return json;
        }

        public dynamic obtenerAprobados()
        {
            string json;
            DataTable dt;
            string query;
            int modicado = 0;

            query = "SELECT es.id, min(es.Nombre) + ' ' + min(es.Apellidos) as Nombre,CONVERT(DECIMAL(10,1),avg(nt.Nota)) as final FROM Estudiantes es INNER JOIN Notas nt ON es.id = nt.id_estudiante group by es.id order by es.id";

            dt = cn.Execonsultas(query);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; dt.Rows.Count > i; i++)
                {
                    if (Convert.ToDouble(dt.Rows[i]["final"]) < 3.0)
                    {
                        dt.Rows.RemoveAt(i);
                        modicado++;
                    }
                    if (modicado > 0)
                    {
                        i = -1;
                        modicado = 0;
                    }
                }

                DataView dtv = dt.DefaultView;
                dtv.Sort = "final DESC";
                dt = dtv.ToTable();

                json = JsonConvert.SerializeObject(dt);
            }
            else
            {
                json = "Not Data";
            }

            return json;
        }

        public dynamic obtenerNoAprobados()
        {
            string json;
            DataTable dt;
            string query;
            int modicado = 0;

            query = "SELECT es.id, min(es.Nombre) + ' ' + min(es.Apellidos) as Nombre,CONVERT(DECIMAL(10,1),avg(nt.Nota)) as final FROM Estudiantes es INNER JOIN Notas nt ON es.id = nt.id_estudiante group by es.id order by es.id";

            dt = cn.Execonsultas(query);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; dt.Rows.Count > i; i++)
                {
                    if (Convert.ToDouble(dt.Rows[i]["final"]) >= 3.0)
                    {
                        dt.Rows.RemoveAt(i);
                        modicado++;
                    }
                    if (modicado > 0)
                    {
                        i = -1;
                        modicado = 0;
                    }
                }

                DataView dtv = dt.DefaultView;
                dtv.Sort = "final ASC";
                dt = dtv.ToTable();


                json = JsonConvert.SerializeObject(dt);
            }
            else
            {
                json = "Not Data";
            }

            return json;
        }

        public dynamic obtenerDataEstudiantes()
        {
            string json;
            string query;
            DataTable dt;

            query = "SELECT id,Nombre+' '+Apellidos AS Nombre FROM Estudiantes";
            dt = cn.Execonsultas(query);

            if (dt.Rows.Count > 0)
            {
                json = JsonConvert.SerializeObject(dt);
            }
            else
            {
                json = "Not Data";
            }

            return json;
        }
    }
}
