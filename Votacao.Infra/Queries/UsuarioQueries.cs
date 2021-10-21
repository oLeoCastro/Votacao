using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votacao.Infra.Data.Queries
{
    public static class UsuarioQueries
    {
        public static string Apagar = @"Delete from Usuario where UsuarioId=@UsuarioId";

        public static string Atualizar = @"Update Usuario Set Nome=@Nome, Login=@Login, Senha=@Senha
                                        Where UsuarioId=@UsuarioId;";

        public static string Inserir = @"Insert into Usuario(Nome, Login, Senha) values (@Nome, @Login, @Senha);
                                        Select SCOPE_IDENTITY();";

        public static string CheckId = @"Select UsuarioId from Usuario Where UsuarioId=@UsuarioId";

        public static string Listar = @"Select
                                            UsuarioId as UsuarioId,
                                            Nome as Nome,
                                            Login as Login
                                        from Usuario
                                        Order By Nome";

        public static string Obter = @"Select
                                            UsuarioId as UsuarioId,
                                            Nome as Nome,
                                            Login as Login                                
                                        from Usuario
                                        Where UsuarioId=@UsuarioId";

    }
}
