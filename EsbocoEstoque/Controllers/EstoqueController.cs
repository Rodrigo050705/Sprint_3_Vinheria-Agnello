using EsbocoEstoque.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; // importando o SelectList
namespace EsbocoEstoque.Controllers
{
    public class EstoqueController : Controller
    {
        //Lista para armazenar os clientes
        public IList<VinhoModel> vinhos { get; set; }

        public EstoqueController()
        {
            //Simula a busca de clientes no banco de dados
            vinhos = GerarVinhosMocados();

        }
        public IActionResult Principal()
        {
            // Evitando valores null 
            if (vinhos == null)
            {
                vinhos = new List<VinhoModel>();
            }
            return View(vinhos);
        }
        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        public IActionResult Create()
        {
            Console.WriteLine("Executou a Action Cadastrar()");
            //Cria a variável para armazenar o SelectList
            var selectListVinhos =
                new SelectList(vinhos,
                                nameof(VinhoModel.VinhoId),
                                nameof(VinhoModel.NomeVinho));
            //Adiciona o SelectList a ViewBag para se enviado para a View
            //A propriedade Representantes é criada de forma dinâmica na ViewBag
            ViewBag.Vinhos = selectListVinhos;
            // Retorna para a View Create um 
            // objeto modelo com as propriedades em branco 
            return View(new VinhoModel());
        }
        // Anotação de uso do Verb HTTP Post
        [HttpPost]
        public IActionResult Create(VinhoModel vinhoModel)
        {
            // Simila que os dados foram gravados.
            Console.WriteLine("Gravando o vinho");
            //Criando a mensagem de sucesso que será exibida para o Cliente
            TempData["mensagemSucesso"] = $"O vinho {vinhoModel.NomeVinho} foi cadastrado com suceso";
            // Substituímos o return View()
            // pelo método de redirecionamento
            return RedirectToAction(nameof(Principal));
            // O trecho nameof(Principal) poderia ser usado da forma abaixo
            // return RedirectToAction("Principal");
        }
        /**
        /**
         * Este método estático GerarClientesMocados 
         * cria uma lista de 5 clientes com dados fictícios
         */
        public static List<VinhoModel> GerarVinhosMocados()
        {
            var vinhos = new List<VinhoModel>();
            for (int i = 1; i <= 5; i++)
            {
                var vinho = new VinhoModel
                {
                    VinhoId = i,
                    NomeVinho = "Vinho" + i,
                    PaisOrigem = "PaisOrigem" + i,
                    DataProduzido = DateTime.Now.AddYears(-15),
                    Preco =  i,
                    Quantidade =  i,
                    TipoVinho = "TipoVinho" + i,
                    DescricaoVinho = "Descricao do Vinho " + i,
                };
                vinhos.Add(vinho);
            }
            return vinhos;
        }

        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var selectListVinhos =
                new SelectList(vinhos,
                                nameof(VinhoModel.VinhoId),
                                nameof(VinhoModel.NomeVinho));
            ViewBag.Vinhos = selectListVinhos;
            // Simulando a busca no banco de dados 
            var vinhoConsultado =
                vinhos.Where(c => c.VinhoId == id).FirstOrDefault();
            // Retornando o cliente consultado para a View
            return View(vinhoConsultado);
        }
        [HttpPost]
        public IActionResult Edit(VinhoModel vinhoModel)
        {
            TempData["mensagemSucesso"] = $"Os dados do vinho {vinhoModel.NomeVinho} foram alterados com sucesso";
            return RedirectToAction(nameof(Principal));
        }

        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var selectListVinhos =
                new SelectList(vinhos,
                                nameof(VinhoModel.VinhoId),
                                nameof(VinhoModel.NomeVinho));
            ViewBag.Vinhos = selectListVinhos;
            // Simulando a busca no banco de dados 
            var vinhoConsultado =
                vinhos.Where(c => c.VinhoId == id).FirstOrDefault();
            // Retornando o vinho consultado para a View
            return View(vinhoConsultado);
        }

        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Simulando a busca no banco de dados 
            var vinhoConsultado =
                vinhos.Where(c => c.VinhoId == id).FirstOrDefault();
            if (vinhoConsultado != null)
            {
                TempData["mensagemSucesso"] = $"Os dados do vinho {vinhoConsultado.NomeVinho} foram removidos com sucesso";
            }
            else
            {
                TempData["mensagemSucesso"] = $"OPS !!! Vinho inexistente.";
            }
            return RedirectToAction(nameof(Principal));
        }
    }
}