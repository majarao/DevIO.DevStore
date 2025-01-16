using DevIO.NerdStore.WebApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.NerdStore.WebApp.MVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();

    public IActionResult Privacy() => View();

    [Route("erro/{id:length(3,3)}")]
    public IActionResult Error(int id)
    {
        ErrorViewModel modelErro = new();

        if (id == 500)
        {
            modelErro.Mensagem = "Ocorreu um erro! Tente novamente mais tarde ou contate nosso suporte.";
            modelErro.Titulo = "Ocorreu um erro!";
            modelErro.ErroCode = id;
        }
        else if (id == 404)
        {
            modelErro.Mensagem =
                "A p�gina que est� procurando n�o existe! <br />Em caso de d�vidas entre em contato com nosso suporte";
            modelErro.Titulo = "Ops! P�gina n�o encontrada.";
            modelErro.ErroCode = id;
        }
        else if (id == 403)
        {
            modelErro.Mensagem = "Voc� n�o tem permiss�o para fazer isto.";
            modelErro.Titulo = "Acesso Negado";
            modelErro.ErroCode = id;
        }
        else
        {
            return StatusCode(404);
        }

        return View("Error", modelErro);
    }

    [Route("sistema-indisponivel")]
    public IActionResult SistemaIndisponivel()
    {
        ErrorViewModel modelErro = new()
        {
            Mensagem = "O sistema est� temporiamente indispon�vel, isto pode ocorrer em momentos de sobrecarga de usu�rios.",
            Titulo = "Sistema indispon�vel",
            ErroCode = 500
        };

        return View("Error", modelErro);
    }
}
