﻿using Dapper;
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
    public class FilmeRepository : IFilmeRepository
    {
        private readonly DynamicParameters _parameters = new DynamicParameters();
        private readonly DataContext _dataContext;

        public FilmeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Apagar(long id)
        {
            try
            {
                _parameters.Add("FilmeId", id, DbType.String);
                                            

                _dataContext.SqlServerConexao.ExecuteScalar<long>(FilmeQueries.Apagar, _parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Atualizar(Filme filme)
        {
            try
            {
                _parameters.Add("FilmeId", filme.FilmeId, DbType.Int64);
                _parameters.Add("Titulo", filme.Titulo, DbType.String);
                _parameters.Add("Diretor", filme.Diretor, DbType.String);

                
                _dataContext.SqlServerConexao.Execute(FilmeQueries.Atualizar, _parameters);
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
                _parameters.Add("FilmeId", id, DbType.Int64);

                
                return _dataContext.SqlServerConexao.Query<bool>(FilmeQueries.CheckId, _parameters).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Inserir(Filme filme)
        {
            try
            {
                _parameters.Add("Titulo", filme.Titulo, DbType.String);
                _parameters.Add("Diretor", filme.Diretor, DbType.String);

                
                return _dataContext.SqlServerConexao.ExecuteScalar<long>(FilmeQueries.Inserir, _parameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<FilmeQueryResult> Listar()
        {
            try
            {
                var filmes = _dataContext.SqlServerConexao.Query<FilmeQueryResult>(FilmeQueries.Listar).ToList();
                return filmes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FilmeQueryResult Obter(long id)
        {
            try
            {
                _parameters.Add("FilmeId", id, DbType.Int64);

          
                var filme = _dataContext.SqlServerConexao.Query<FilmeQueryResult>(FilmeQueries.Obter, _parameters).FirstOrDefault();
                return filme;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
