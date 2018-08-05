using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProtectedResources.Model;

namespace ProtectedResources.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class CotacaoController : ControllerBase
    {
        [Route("criptoMoedas")]
        public async Task<IActionResult> CriptoMoedas()
        {
            HttpClient client = new HttpClient();

            // Free key with several limits - Get another at https://coinmarketcap.com/pt-br/
            client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", "9758b4ec-a00e-4cc3-94e3-f74cdf061516");

            var conteudo = await client.GetStringAsync("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest?start=1&limit=20");

            var moedas = JsonConvert.DeserializeObject<ListaMoedas>(conteudo).data.Select(s => new MoedaViewModel()
            {
                Id = s.id,
                Nome = s.name,
                Simbolo = s.symbol,
                Rank = s.cmc_rank,
                Preco = s.quote["USD"].price,
            }).ToList();
            return Ok(moedas);
        }
    }
}
