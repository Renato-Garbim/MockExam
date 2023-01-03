using System.Threading.Tasks;

namespace WebAPIMock.Requests
{
    public interface IProcessoRequisicao
    {
        Task ProcessaLogRequest(string mensagemParaConsumir);
    }
}
