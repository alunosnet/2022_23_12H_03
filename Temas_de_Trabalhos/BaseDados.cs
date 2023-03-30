using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Temas_de_Trabalhos
{
    public class BaseDados
    {
        string ligaBD;
        SqlConnection sqlConnection;
        string NomeBD;
        string caminhoBD;

        public BaseDados(string NomeBD)
        {

            ligaBD = ConfigurationManager.ConnectionStrings["servidor"].ToString();
            this.NomeBD = NomeBD;
            string caminhoBD = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            caminhoBD += "\\M15_Projeto\\";
            this.caminhoBD = caminhoBD + NomeBD + ".mdf";
            if (System.IO.Directory.Exists(caminhoBD) == false)
            {
                System.IO.Directory.CreateDirectory(caminhoBD);
            }
            if (System.IO.File.Exists(this.caminhoBD) == false)
            {
                CriarBD();
            }

            //ligação BD

            sqlConnection = new SqlConnection(ligaBD);
            sqlConnection.Open();
            sqlConnection.ChangeDatabase(NomeBD);

        }

        ~BaseDados()
        {

            try
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            catch
            {
                //pode ocorrer erros
            }

        }

        private void CriarBD()
        {
            // ligar ao servidor BD
            sqlConnection = new SqlConnection(ligaBD);
            sqlConnection.Open();

            // criar a BD
            string sql = $"CREATE DATABASE {NomeBD} ON PRIMARY (NAME={NomeBD},FILENAME='{caminhoBD}')";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.ChangeDatabase(NomeBD);

            // criar as tabelas
            sql = @"create table disciplinas(
                        id_disciplina int identity primary key,
                        nome varchar(100) not null check(len(nome) >= 2),
                        ano int not null check(ano between 10 and 12)
                    );


                    create table modulos(
                        id_modulo int identity primary key,    
                        ano int not null check(ano between 10 and 12),
                        id_disciplina int references disciplinas(id_disciplina),                                                       
                        nmodulo int not null check(nmodulo >= 0),
                        nome varchar(50) not null check(len(nome) >= 2),
                        nhoras int not null check(nhoras >= 1),                    
                    );

                    create table temas(
                        id_tema int identity primary key,
                        ano int not null check(ano between 10 and 12),
                        id_modulo int references modulos(id_modulo),
                        id_disciplina int references disciplinas(id_disciplina),
                        nome varchar(40) not null check(len(nome) > 2),
                        entrega date default(getdate()), 
                        fotografia varbinary(max),
                        estado bit
                    );
                    CREATE INDEX i_nome ON temas(nome)
                    ";

            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            // fechar a ligação ao servidor BD

            sqlCommand.Dispose();
            sqlConnection.Close();
            sqlConnection.Dispose();
        }


        /// <summary>
        /// Vai executar um SQL que altera os dados (p.e: insert, delete ou update)
        /// </summary>
        public void ExecutaSQL(string sql, List<SqlParameter> parametros = null)
        {
            //TODO: Adicionar transações
            SqlCommand comando = new SqlCommand(sql, sqlConnection);
            if (parametros != null)
            {
                comando.Parameters.AddRange(parametros.ToArray());
            }
            comando.ExecuteNonQuery();
            comando.Dispose();
            comando = null;
        }

        /// <summary>
        /// Executa uma consulta e devolve os dados da bd
        /// </summary>
        /// <returns>Um datatable com o resultado da consulta</returns>
        public DataTable DevolveSQL(string sql, List<SqlParameter> parametros = null)
        {
            //TODO: Adicionar transações
            SqlCommand comando = new SqlCommand(sql, sqlConnection);
            if (parametros != null)
            {
                comando.Parameters.AddRange(parametros.ToArray());
            }
            DataTable dados = new DataTable();

            SqlDataReader registos = comando.ExecuteReader();
            dados.Load(registos);

            registos.Close();
            registos.Dispose();
            registos = null;
            comando = null;


            return dados;

        }
    }
}
