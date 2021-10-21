using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votacao.Infra.Data.Queries
{
    public static class VotoQueries
    {
        public static string Apagar = @"Delete from Voto where VotoId=@VotoId";

        public static string Atualizar = @"Update Voto Set FilmeId=@FilmeId, UsuarioId=@UsuarioId
                                        Where VotoId=@VotoId;";

        public static string Inserir = @"Insert into Voto(FilmeId, UsuarioId) values (@FilmeId, @UsuarioId);
                                        Select SCOPE_IDENTITY();";

        public static string CheckId = @"Select VotoId from Voto Where VotoId=@VotoId";

        public static string Listar = @"Select V.VotoId, 
                                            F.FilmeId as FilmeId, F.Titulo as Titulo, F.Diretor as Diretor,
                                            U.UsuarioId as UsuarioId, U.Nome as Nome, U.Login as Login
                                        from Voto V
                                        inner join filme F on F.FilmeId = V.FilmeId
                                        inner join usuario U on U.UsuarioId = V.UsuarioId
                                        order by V.VotoId";

        public static string Obter = @"Select V.VotoId, 
                                            F.FilmeId as FilmeId, F.Titulo as Titulo, F.Diretor as Diretor,
                                            U.UsuarioId as UsuarioId, U.Nome as Nome, U.Login as Login
                                        from Voto V
                                        inner join filme F on F.FilmeId = V.FilmeId
                                        inner join usuario U on U.UsuarioId = V.UsuarioId
                                        where VotoId=@VotoId";

    }
}
