using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temas_de_Trabalhos.Modulos
{
    public class Modulo
    {
        public int Id_modulo { get; set; }
        public int Ano { get; set; }
        public int Id_disciplina { get; set; }
        public int Nmodulo { get; set; }
        public string Nome { get; set; }
        public int Nhoras { get; set; }

        public Modulo()
        {

        }

        public Modulo(int ano, int id_disciplina, int Nmodulo, string Nome, int Nhoras)
        {
            this.Ano = ano;
            this.Id_disciplina = id_disciplina;
            this.Nmodulo = Nmodulo;
            this.Nome = Nome;
            this.Nhoras = Nhoras;
        }

        public static DataTable ListarTodos(BaseDados bd)
        {
            string sql = "SELECT id_modulo, modulos.ano as Ano, disciplinas.nome as Disciplina, modulos.nome as Nome, nmodulo as [NºModulo], nhoras as [NºHoras] FROM modulos INNER JOIN disciplinas ON modulos.id_disciplina = disciplinas.id_disciplina";
            return bd.DevolveSQL(sql);
        }

        public override string ToString()
        {
            return this.Nome;
        }

        public void Guardar(BaseDados bd)
        {
            string sql = "INSERT INTO modulos(id_disciplina,ano,nmodulo,nome,nhoras) VALUES (@id_disciplina, @ano, @nmodulo, @nome, @nhoras)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@id_disciplina",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = this.Id_disciplina
                },
                new SqlParameter()
                {
                    ParameterName = "@ano",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = this.Ano
                },
                new SqlParameter()
                {
                    ParameterName = "@nmodulo",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = this.Nmodulo
                },
                new SqlParameter()
                {
                    ParameterName = "@nome",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = this.Nome
                },
                new SqlParameter()
                {
                    ParameterName = "@nhoras",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = this.Nhoras
                },

            };
            bd.DevolveSQL(sql, parametros);
        }

        public static DataTable ListarModulos(BaseDados bd, int id_disciplina)
        {
            string sql = "SELECT * FROM modulos WHERE id_disciplina = " + id_disciplina;
            return bd.DevolveSQL(sql);
        }

        public DataTable ProcurarPorIdModulo(BaseDados bd, int id_modulo)
        {
            string sql = "SELECT nmodulo FROM modulos WHERE id_modulo=" + id_modulo;
            return bd.DevolveSQL(sql);
        }

        public void Atualizar(BaseDados bd)
        {
            string sql = @"UPDATE modulos SET ano=@ano, id_disciplina=@id_disciplina, nmodulo=@nmodulo, nome=@nome, nhoras=@nhoras WHERE id_modulo=@id_modulo";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@ano",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = this.Ano
                },
                new SqlParameter()
                {
                    ParameterName = "@id_disciplina",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = this.Id_disciplina
                },
                new SqlParameter()
                {
                    ParameterName = "@nmodulo",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = this.Nmodulo
                },
                new SqlParameter()
                {
                    ParameterName = "@nome",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = this.Nome
                },
                new SqlParameter()
                {
                    ParameterName = "@nhoras",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = this.Nhoras
                },
                new SqlParameter()
                {
                    ParameterName = "@id_modulo",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = this.Id_modulo
                },
            };
            bd.ExecutaSQL(sql, parametros);
        }

        public static void ApagarModulo(int id_modulo, BaseDados bd)
        {
            string sql = "DELETE FROM modulos WHERE id_modulo=" + id_modulo;
            bd.ExecutaSQL(sql);
        }

        public DataTable Procurar(int id_modulo, BaseDados bd)
        {
            string sql = "SELECT * FROM modulos WHERE id_modulo=" + id_modulo;
            DataTable dados = bd.DevolveSQL(sql);

            if(dados != null && dados.Rows.Count > 0)
            {
                this.Id_modulo = int.Parse(dados.Rows[0]["id_modulo"].ToString());
                this.Id_disciplina = int.Parse(dados.Rows[0]["id_disciplina"].ToString());
                this.Nome = dados.Rows[0]["nome"].ToString();
                this.Ano = int.Parse(dados.Rows[0]["ano"].ToString());
                this.Nmodulo = int.Parse(dados.Rows[0]["nmodulo"].ToString());
                this.Nhoras = int.Parse(dados.Rows[0]["nhoras"].ToString());
            }

            return dados;
        }
    }
}
