using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votacao.Infra.Data.Queries
{
    public static class FilmeQueries
    {
        public static string Apagar = @"Delete from Filme where FilmeId=@FilmeId";

        public static string Atualizar = @"Update Filme Set Titulo=@Titulo, Diretor=@Diretor
                                            Where FilmeId=@FilmeId;";

        public static string Inserir = @"Insert into Filme(Titulo, Diretor) values (@Titulo, @Diretor);
                                        Select SCOPE_IDENTITY();";

        public static string CheckId = @"Select FilmeId from Filme Where FilmeId=@FilmeId";

        public static string Listar = @"Select
                                            FilmeId as FilmeId,
                                            Titulo as Titulo,
                                            Diretor as Diretor
                                        from Filme
                                        Order By Titulo";

        public static string Obter = @"Select
                                            FilmeId as FilmeId,
                                            Titulo as Titulo,
                                            Diretor as Diretor
                                        from Filme
                                        Where FilmeId=@FilmeId";

    }
}
