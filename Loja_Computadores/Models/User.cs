using Loja_Computadores.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Loja_Computadores.Models
{
    public class User
    {
        public int id;
        public string nome;
        public string email;
        public string morada;
        public string nif;
        public string password;
        public int perfil;
        public int sal;

        BaseDados bd;

        public User()
        {
            bd = new BaseDados();
        }

        public void Adicionar()
        {
            string sql = @"INSERT INTO users(email,nome,morada,nif,password,estado,perfil,sal)
                            VALUES (@email,@nome,@morada,@nif,HASHBYTES('SHA2_512',concat(@password,@sal)),@estado,@perfil, @sal)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@email",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.email
                },
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nome
                },
                new SqlParameter()
                {
                    ParameterName="@morada",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.morada
                },
                new SqlParameter()
                {
                    ParameterName="@nif",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nif
                },
                new SqlParameter()
                {
                    ParameterName="@password",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.password
                },
                new SqlParameter()
                {
                    ParameterName="@estado",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=1
                },
                new SqlParameter()
                {
                    ParameterName="@perfil",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.perfil
                },
                new SqlParameter()
                {
                    ParameterName="@sal",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.sal
                },
            };
            bd.executaSQL(sql, parametros);
        }

        internal DataTable ListaTodosUsers()
        {
            return bd.devolveSQL("SELECT * FROM Users");
        }

        public DataTable devolveDadosUser(int id)
        {
            string sql = "SELECT * FROM users WHERE id=@id";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value=id }
            };
            DataTable dados = bd.devolveSQL(sql, parametros);
            if (dados.Rows.Count == 0)
            {
                return null;
            }
            return dados;
        }

        public DataTable devolveDadosUser(string email)
        {
            string sql = "SELECT * FROM users WHERE email=@email";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@email",SqlDbType=SqlDbType.VarChar,Value=email }
            };
            DataTable dados = bd.devolveSQL(sql, parametros);
            return dados;
        }

        public void atualizarUtilizador()
        {
            string sql = @"UPDATE users SET nome=@nome,morada=@morada,nif=@nif 
                            WHERE id=@id";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nome",SqlDbType=SqlDbType.VarChar,Value=nome },
                new SqlParameter() {ParameterName="@morada",SqlDbType=SqlDbType.VarChar,Value=morada },
                new SqlParameter() {ParameterName="@nif",SqlDbType=SqlDbType.VarChar,Value=nif },
                new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value=id },
            };
            bd.executaSQL(sql, parametros);
        }

        internal void atualizarPassword(string guid, string password)
        {
            string sql = "UPDATE users set password=HASHBYTES('SHA2_512',concat(@password,sal)),estado=1,lnkRecuperar=null WHERE lnkRecuperar=@lnk";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@password",SqlDbType=SqlDbType.VarChar,Value=password},
                new SqlParameter() {ParameterName="@lnk",SqlDbType=SqlDbType.VarChar,Value=guid },
            };
            bd.executaSQL(sql, parametros);
        }

        internal void recuperarPassword(string email, string guid)
        {
            string sql = "UPDATE users set lnkRecuperar=@lnk WHERE email=@email";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@email",SqlDbType=SqlDbType.VarChar,Value=email },
                new SqlParameter() {ParameterName="@lnk",SqlDbType=SqlDbType.VarChar,Value=guid },
            };
            bd.executaSQL(sql, parametros);
        }
    }
}