using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votacao.Domain.Entidades;
using Votacao.Domain.Interfaces.Repositories;
using Votacao.Domain.Query;
using Votacao.Infra.Data.DataContexts;
using Votacao.Infra.Data.Queries;

namespace Votacao.Infra.Data.Repositories
{
    public class VotoRepository : IVotoRepository
    {
        private readonly DynamicParameters _parameters = new DynamicParameters();
        private readonly DataContext _dataContext;


        public VotoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Apagar(long id)
        {
            try
            {
                _parameters.Add("VotoId", id, DbType.String);

                
                _dataContext.SqlServerConexao.ExecuteScalar<long>(VotoQueries.Apagar, _parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Atualizar(Voto voto)
        {
            try
            {
                _parameters.Add("VotoId", voto.VotoId, DbType.Int64);
                _parameters.Add("FilmeId", voto.FilmeId, DbType.Int64);
                _parameters.Add("UsuarioId", voto.UsuarioId, DbType.Int64);

                
                _dataContext.SqlServerConexao.Execute(VotoQueries.Atualizar, _parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckId(long id)
        {
            try
            {
                _parameters.Add("VotoId", id, DbType.Int64);

                
                return _dataContext.SqlServerConexao.Query<bool>(VotoQueries.CheckId, _parameters).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Inserir(Voto voto)
        {
            try
            {
                _parameters.Add("FilmeId", voto.FilmeId, DbType.Int64);
                _parameters.Add("UsuarioId", voto.UsuarioId, DbType.Int64);

                
                return _dataContext.SqlServerConexao.ExecuteScalar<long>(VotoQueries.Inserir, _parameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<VotoQueryResult> Listar()
        {
            try
            {
                
                return _dataContext.SqlServerConexao.Query<VotoQueryResult, FilmeQueryResult, UsuarioQueryResult, VotoQueryResult>(
                    VotoQueries.Listar,
                    map: ((voto, filme, usuario) =>
                    {
                        voto.Filme = filme;
                        voto.Usuario = usuario;

                        return voto;
                    }),
                        splitOn: "FilmeId,UsuarioId"
                    ).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VotoQueryResult Obter(long id)
        {
            try
            {
                _parameters.Add("VotoId", id, DbType.Int64);
                                
                return _dataContext.SqlServerConexao.Query<VotoQueryResult, FilmeQueryResult, UsuarioQueryResult, VotoQueryResult>(
                    VotoQueries.Obter,
                    map: ((voto, filme, usuario) =>
                    {
                        voto.Filme = filme;
                        voto.Usuario = usuario;

                        return voto;
                    }),
                       splitOn: "FilmeId,UsuarioId",
                       param: _parameters
                    ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
