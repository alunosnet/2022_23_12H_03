using Loja_Computadores.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Loja_Computadores.Models
{
    public class Produto
    {
        public int id;
        public string nome;
        public string tags;
        public DateTime data_aquisicao;
        public Decimal preco;
        public int stock;
        public int estado;

        BaseDados bd;

        public Produto()
        {
            bd = new BaseDados();
        }

        public int Adicionar()
        {
            string sql = "INSERT INTO Produtos(nome, tags, data_aquisicao, preco, stock, estado) " +
                "VALUES (@nome, @tags, @data_aquisicao, @preco, @stock, @estado);" +
                " SELECT CAST(SCOPE_IDENTITY() AS INT)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@nome",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = this.nome
                },
                new SqlParameter()
                {
                    ParameterName = "@tags",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = this.tags
                },
                new SqlParameter()
                {
                    ParameterName = "@preco",
                    SqlDbType = System.Data.SqlDbType.Decimal,
                    Value = this.preco
                },
                new SqlParameter()
                {
                    ParameterName = "@stock",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = this.stock
                },
                new SqlParameter()
                {
                    ParameterName = "@data_aquisicao",
                    SqlDbType = System.Data.SqlDbType.Date,
                    Value = this.data_aquisicao
                },
                new SqlParameter()
                {
                    ParameterName = "@estado",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value= this.estado
                }
            };
            return bd.executaEDevolveSQL(sql, parametros);
        }

        internal DataTable ListarTodosProdutos(int? filtra = null)
        {
            string sql = @"SELECT id,nome,tags,data_aquisicao,
                    preco, stock,
                    case
                        when estado=0 then 'Descontinuado'
                        when estado=1 then 'Disponível'
                    end as estado
                    FROM Produtos";
            if (filtra == 1)
            {
                sql += " WHERE estado = 0";
            }
            if (filtra == 2)
            {
                sql += " WHERE estado = 1";
            }
            return bd.devolveSQL(sql);
        }
        internal DataTable ListarTodosProdutosDisponiveis(string pesquisa = "", int? ordena = null, int? tipo = null, string lk = null)
        {
            string sql = @"SELECT id,nome,tags,data_aquisicao,
                    preco,
                    case
                        when stock=0 then 'Sem Stock'
                        when stock < 10 then 'Poucas Unidades'
                        when stock >= 10 then 'Em Stock'
                    end as stock
                    FROM Produtos
                    WHERE estado = 1";

            if (pesquisa != "")
            {
                sql += " and nome like @nome";
            }
            if (tipo != null && tipo == 1)
            {
                sql += " and tags like 'Processador%'";
            }
            if (tipo != null && tipo == 2)
            {
                sql += " and tags like 'Motherboard%'";
            }
            if (tipo != null && tipo == 3)
            {
                sql += " and tags like 'Ram%'";
            }
            if (tipo != null && tipo == 4)
            {
                sql += " and tags like 'Grafica%'";
            }
            if (tipo != null && tipo == 5)
            {
                sql += " and tags like 'PSU%'";
            }
            if (tipo != null && tipo == 6)
            {
                sql += " and tags like 'Armazenamento%'";
            }
            if (tipo != null && tipo == 7)
            {
                sql += " and tags like 'Caixa%'";
            }
            if (lk != null)
            {
                sql += " and tags like @lk";
            }
            if (ordena != null && ordena == 1)
            {
                sql += " order by preco";
            }
            if (ordena != null && ordena == 2)
            {
                sql += " order by preco desc";
            }
            
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType= System.Data.SqlDbType.VarChar,
                    Value="%"+pesquisa+"%",
                },
                new SqlParameter()
                {
                    ParameterName="@lk",
                    SqlDbType= System.Data.SqlDbType.VarChar,
                    Value="%"+lk+"%",
                }
            };
            return bd.devolveSQL(sql,parametros);
        }

        public DataTable devolveDadosProduto(int id)
        {
            string sql = "SELECT * FROM produtos WHERE id=@id";
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

        public void MudaEstadoProduto(int id)
        {
            DataTable dados = devolveDadosProduto(id);
            int novoestado;

            if (dados.Rows[0]["estado"].ToString() == "0") 
            {
                novoestado = 1;
            }
            else
            {
                novoestado = 0;
            }

                string sql = "UPDATE produtos SET estado = @novoestado WHERE id = @id";
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    new SqlParameter()
                    {
                        ParameterName="@id",
                        SqlDbType= System.Data.SqlDbType.Int,
                        Value=id
                    },
                    new SqlParameter()
                    {
                        ParameterName="@novoestado",
                        SqlDbType= System.Data.SqlDbType.Int,
                        Value=novoestado
                    }
                };
                bd.executaSQL(sql, parametros);
        }

        public void DescontinuarProduto(int id)
        {
            string sql = "UPDATE produtos SET estado = 0 WHERE id = @id";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@id",
                    SqlDbType= System.Data.SqlDbType.Int,
                    Value=id
                }
            };
            bd.executaSQL(sql, parametros);
        }

        public void DisponiblizarProduto(int id)
        {
            string sql = "UPDATE produtos SET estado = 1 WHERE id = @id";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@id",
                    SqlDbType= System.Data.SqlDbType.Int,
                    Value=id
                }
            };
            bd.executaSQL(sql, parametros);
        }

        public void AtualizaProduto()
        {
            string sql = "UPDATE produtos SET nome=@nome,tags=@tags,data_aquisicao=@data,preco=@preco,stock=@stock WHERE id=@id;";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nome",SqlDbType=SqlDbType.VarChar,Value= nome},
                new SqlParameter() {ParameterName="@tags",SqlDbType=SqlDbType.VarChar,Value= tags},
                new SqlParameter() {ParameterName="@data",SqlDbType=SqlDbType.DateTime,Value= data_aquisicao},
                new SqlParameter() {ParameterName="@preco",SqlDbType=SqlDbType.Decimal,Value= preco},
                new SqlParameter() {ParameterName="@stock",SqlDbType=SqlDbType.Int,Value=stock},
                new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value=id}
            };
            bd.executaSQL(sql, parametros);
        }

        internal void AddStock(int id, int stock)
        {
            string sql = "UPDATE Produtos SET stock= stock+@stock WHERE id=@id";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
               new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value=id},
                new SqlParameter() {ParameterName="@stock",SqlDbType=SqlDbType.Int,Value=stock},
            };
            bd.executaSQL(sql, parametros);
        }
    }
}