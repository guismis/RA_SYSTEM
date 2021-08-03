using DevIO.Domain.Notificacoes;
using System.Collections.Generic;

namespace DevIO.Domain.Intefaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}