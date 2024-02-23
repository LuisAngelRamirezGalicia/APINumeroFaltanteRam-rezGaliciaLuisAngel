using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Reflection.Metadata.Ecma335;

namespace WepApi.Controllers
{
    public class NumerosNaturalesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("extract/{entrada}")]
        public IActionResult Extract(string entrada)
        {   //string entrada = string.Empty;
            int numero = 0;
            string exSalida = "";

            try 
            { 
                numero = int.Parse(entrada); 
            }
            catch (Exception ex) 
            {
                numero = 101;
                exSalida = "la entrada no es un numero ";
            }
            

            NumerosNaturales numerosNaturales = new NumerosNaturales();
            numerosNaturales.Numeros = new List<int> { };


            for (int i = 0; i < 100; i++)
            {
                numerosNaturales.Numeros.Add(i);
            }

            if (numero >= 0 && numero < 100)
            {
            numerosNaturales.Extract(numero);
                HttpContext.Session.SetString("Objeto", JsonSerializer.Serialize(numerosNaturales));
                return Ok("El numero se extrajo correctamente");
            }
            else
            {
                exSalida = exSalida + "tiene que estar entre 0 y 99";
                return BadRequest(exSalida);
            }
           
        }


        [HttpGet("cualExtrajo")]
        public IActionResult RecuperarExtraido()
        {   //string entrada = string.Empty;

            string temp = HttpContext.Session.GetString("Objeto");
            //result = (ML.Result)temp; 
            NumerosNaturales result = JsonSerializer.Deserialize<NumerosNaturales>(temp)!;

            int retorno = result.CualSeExtrajo();

            return Ok(retorno);
        }





    }
}
