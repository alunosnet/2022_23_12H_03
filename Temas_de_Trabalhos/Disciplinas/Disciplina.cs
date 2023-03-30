using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Temas_de_Trabalhos.Disciplinas
{
    public class Disciplina
    {
        public int Id_disciplina { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }


        public Disciplina(string nome, int ano)
        {
            this.Nome = nome;
            this.Ano = ano;
        }

        public Disciplina()
        {
        }

        public static DataTable ListarTodos(BaseDados bd)
        {
            string sql = "SELECT * FROM disciplinas";
            return bd.DevolveSQL(sql);
        }

        public void Guardar(BaseDados bd)
        {
            string sql = @"INSERT INTO disciplinas(nome, ano) VALUES (@nome, @ano)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@nome",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = this.Nome
                },
                new SqlParameter()
                {
                    ParameterName = "@ano",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = this.Ano
                },
            };

            bd.DevolveSQL(sql, parametros);
        }

        public void Atualizar(BaseDados bd)
        {
            string sql = @"UPDATE disciplinas SET nome=@nome, ano=@ano WHERE id_disciplina=@id_disciplina";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@nome",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = this.Nome
                },
                new SqlParameter()
                {
                    ParameterName = "@ano",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = this.Ano
                },
                new SqlParameter(){
                    ParameterName = "@id_disciplina",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = this.Id_disciplina
                }
            };
            bd.ExecutaSQL(sql, parametros);
        }

        public DataTable Procurar(int id_disciplina, BaseDados bd)
        {
            string sql = "SELECT * FROM disciplinas WHERE id_disciplina="+id_disciplina;
            DataTable dados = bd.DevolveSQL(sql);

            if (dados != null && dados.Rows.Count > 0)
            {
                this.Id_disciplina = int.Parse(dados.Rows[0]["id_disciplina"].ToString());
                this.Nome = dados.Rows[0]["nome"].ToString();
                this.Ano = int.Parse(dados.Rows[0]["ano"].ToString());
            }

            return dados;
        }

        public static void ApagarDisciplina(int id_disciplina, BaseDados bd)
        {
            string sql = "DELETE FROM disciplinas WHERE id_disciplina=" + id_disciplina;
            bd.ExecutaSQL(sql);
        }

        public static DataTable ListarTodosDoAno(BaseDados bd, int ano)
        {
            string sql = "SELECT * FROM disciplinas WHERE ano=" + ano;
            return bd.DevolveSQL(sql);
        }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}
