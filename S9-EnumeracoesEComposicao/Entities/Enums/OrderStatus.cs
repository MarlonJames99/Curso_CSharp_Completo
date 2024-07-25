using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S9_EnumeracoesEComposicao.Entities.Enums
{
    enum OrderStatus : int
    {
        AguardandoPagamento = 0,
        Processando = 1,
        Enviado = 2,
        Entregue = 3
    }
}
