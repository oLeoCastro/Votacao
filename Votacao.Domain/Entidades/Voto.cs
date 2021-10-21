using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votacao.Domain.Entidades
{
    public class Voto
    {
        public long VotoId { get; private set; }
        public long FilmeId { get; private set; }
        public long UsuarioId { get; private set; }

        public Voto(long votoId, long filmeId, long usuarioId)
        {
            VotoId = votoId;
            FilmeId = filmeId;
            UsuarioId = usuarioId;
        }
    }
}
