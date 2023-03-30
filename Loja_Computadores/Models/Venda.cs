using Loja_Computadores.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Loja_Computadores.Models
{
    public class Venda
    {
        BaseDados bd;

        public Venda()
        {
            bd = new BaseDados();
        }

        public void AdicionarVenda(int id_produto, int id_user, int quantidade,DateTime dataDevolve, string morada)
        {
            string sql = "SELECT * FROM produtos WHERE id=@id";
            List<SqlParameter> parametrosBloquear = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value=id_produto }
            };
            //iniciar transação
            SqlTransaction transacao = bd.iniciarTransacao(IsolationLevel.Serializable);
            DataTable dados = bd.devolveSQL(sql, parametrosBloquear, transacao);

            try
            {
                //verificar disponibilidade do produto
                if (dados.Rows[0]["estado"].ToString() != "1")
                    throw new Exception("O produto não está disponível");
                //alterar stock
                sql = "UPDATE produtos SET stock=stock-@stock WHERE id=@id";
                List<SqlParameter> parametrosUpdate = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value=id_produto },
                    new SqlParameter() {ParameterName="@stock",SqlDbType=SqlDbType.Int,Value=quantidade },
                };
                bd.executaSQL(sql, parametrosUpdate, transacao);
                //registar venda
                sql = @"INSERT INTO vendas(id_user,id_produto,data_venda,preco,quantidade,morada) 
                            VALUES (@id_user,@id_produto,@data_venda,@preco,@quantidade,@morada)";
                List<SqlParameter> parametrosInsert = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@id_produto",SqlDbType=SqlDbType.Int,Value=id_produto },
                    new SqlParameter() {ParameterName="@id_user",SqlDbType=SqlDbType.Int,Value=id_user },
                    new SqlParameter() {ParameterName="@data_venda",SqlDbType=SqlDbType.Date,Value=DateTime.Now.Date},
                    new SqlParameter() {ParameterName="@preco",SqlDbType=SqlDbType.Decimal,Value=Decimal.Parse(dados.Rows[0][3].ToString())*quantidade},
                    new SqlParameter() {ParameterName="@quantidade",SqlDbType=SqlDbType.Int,Value=quantidade },
                    new SqlParameter() {ParameterName="@morada",SqlDbType=SqlDbType.VarChar,Value=morada },

                };
                bd.executaSQL(sql, parametrosInsert, transacao);
                //concluir transação
                transacao.Commit();
            }
            catch
            {
                transacao.Rollback();
            }
            dados.Dispose();
        }

        public DataTable DevolveComprasUser(int id)
        {
            string sql = "SELECT nvenda as NºVenda, produtos.nome as [Nome do Produto], vendas.preco as [Preço], vendas.quantidade as Quantidade, vendas.data_venda as Data, vendas.morada as Morada FROM vendas INNER JOIN produtos ON vendas.id_produto = produtos.id WHERE id_user=@id";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@id",
                    SqlDbType= System.Data.SqlDbType.Int,
                    Value=id
                }
            };
            return bd.devolveSQL(sql, parametros);
        }

        public DataTable ListaVendas()
        {
            string sql = "SELECT nvenda as NºVenda, produtos.nome as [Nome do Produto], users.nome as [Nome do Utilizador], vendas.preco as [Preço], quantidade as Quantidade, vendas.data_venda as Data, vendas.morada as Morada FROM vendas INNER JOIN produtos ON vendas.id_produto = produtos.id INNER JOIN users ON vendas.id_user = users.id";
            return bd.devolveSQL(sql);
        }
    }
}