using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temas_de_Trabalhos.Temas
{
    public class Tema
    {

        public int Id_tema { get; set; }
        public int Id_disciplina { get; set; }
        public int Ano { get; set; }
        public int Id_modulo { get; set; }
        public string Nome { get; set; }
        public DateTime Entrega { get; set; }
        public byte[] Fotografia { get; set; }
        public bool Estado { get; set; }

        public Tema(int id_disciplina, int ano, int id_modulo, string nome, DateTime entrega, byte[] fotografia)
        {
            Id_disciplina = id_disciplina;
            Ano = ano;
            Id_modulo = id_modulo;
            Nome = nome;
            Entrega = entrega;
            Fotografia = fotografia;
        }

        public Tema()
        {

        }


        public static object ListarTodos(BaseDados bd)
        {
            string sql = "SELECT id_tema, temas.ano as Ano, disciplinas.nome as Disciplina, modulos.nmodulo AS [NºMódulos], modulos.nome as [Módulo], temas.nome as Nome, entrega as [Data de Entrega], fotografia as [Fotografía], estado as [Entregue] FROM temas INNER JOIN modulos ON temas.id_modulo = modulos.id_modulo INNER JOIN disciplinas ON temas.id_disciplina = disciplinas.id_disciplina";
            return bd.DevolveSQL(sql);
        }

        internal void Guardar(BaseDados bd)
        {
            string sql = "INSERT INTO temas(id_disciplina, ano, id_modulo, nome, entrega, fotografia, estado) VALUES (@id_disciplina, @ano, @id_modulo, @nome, @entrega, @fotografia, 0)";

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
                    ParameterName = "@id_modulo",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = this.Id_modulo
                },
                new SqlParameter()
                {
                    ParameterName = "@nome",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = this.Nome
                },
                new SqlParameter()
                {
                    ParameterName = "@entrega",
                    SqlDbType = System.Data.SqlDbType.Date,
                    Value = this.Entrega
                },
                new SqlParameter()
                {
                    ParameterName = "@fotografia",
                    SqlDbType = System.Data.SqlDbType.VarBinary,
                    Value = this.Fotografia
                },

            };
            bd.DevolveSQL(sql, parametros);
        }

        internal void Procurar(BaseDados bd, int id_tema)
        {
            string sql = "SELECT * FROM temas WHERE id_tema=" + id_tema;
            DataTable dados = bd.DevolveSQL(sql);

            if (dados != null && dados.Rows.Count > 0)
            {
                this.Id_tema = int.Parse(dados.Rows[0]["id_tema"].ToString());
                this.Ano = int.Parse(dados.Rows[0]["ano"].ToString());
                this.Id_modulo = int.Parse(dados.Rows[0]["id_modulo"].ToString());
                this.Id_disciplina = int.Parse(dados.Rows[0]["id_disciplina"].ToString());
                this.Nome = dados.Rows[0]["nome"].ToString();
                this.Entrega = DateTime.Parse(dados.Rows[0]["entrega"].ToString());
                this.Fotografia = (byte[])dados.Rows[0]["fotografia"];
            }
        }

        internal void Atualizar(BaseDados bd)
        {
            string sql = @"UPDATE temas SET ano=@ano, id_modulo=@id_modulo, id_disciplina=@id_disciplina, nome=@nome, entrega=@entrega";
            if (this.Fotografia != null)
                sql += ",fotografia=@fotografia";
            sql += " WHERE id_tema=@id_tema";
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
                    ParameterName = "@id_modulo",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = this.Id_modulo
                },
                new SqlParameter()
                {
                    ParameterName = "@nome",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = this.Nome
                },
                new SqlParameter()
                {
                    ParameterName = "@entrega",
                    SqlDbType = System.Data.SqlDbType.Date,
                    Value = this.Entrega
                },
                new SqlParameter()
                {
                    ParameterName = "@id_tema",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = this.Id_tema
                }


            };
            if (this.Fotografia != null)
                parametros.Add(
                    new SqlParameter()
                    {
                        ParameterName = "@fotografia",
                        SqlDbType = System.Data.SqlDbType.VarBinary,
                        Value = this.Fotografia
                    }
                );
            bd.ExecutaSQL(sql, parametros);
        }

        public static void ApagarTema(int id_tema, BaseDados bd)
        {
            string sql = "DELETE FROM temas WHERE id_tema=" + id_tema;
            bd.ExecutaSQL(sql);
        }

        public static DataTable PesquisarNome(BaseDados bd, string nome)
        {
            string sql = @"SELECT id_tema, temas.ano as Ano, disciplinas.nome as Disciplina, modulos.nmodulo AS [NºMódulos], modulos.nome as [Módulo], temas.nome as Nome, entrega as [Data de Entrega], fotografia as [Fotografía], estado as [Entregue] FROM temas INNER JOIN modulos ON temas.id_modulo = modulos.id_modulo INNER JOIN disciplinas ON temas.id_disciplina = disciplinas.id_disciplina WHERE temas.nome LIKE @nome";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value="%"+nome+"%"
                },
            };
            return bd.DevolveSQL(sql, parametros);
        }

        public static DataTable ListarPorEntregar(BaseDados bd)
        {
            string sql = "SELECT * FROM temas WHERE estado = 0";
            return bd.DevolveSQL(sql);
        }

        public static void Entregar(BaseDados bd, int id_tema)
        {
            string sql = @"UPDATE temas SET estado=1 WHERE estado=0 and id_tema=" + id_tema;
            bd.ExecutaSQL(sql);
        }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}
