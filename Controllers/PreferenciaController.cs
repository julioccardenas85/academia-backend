using Microsoft.AspNetCore.Mvc;
using MercadoPago.Config;
using MercadoPago.Client.Common;
using MercadoPago.Client.Preference;
using MercadoPago.Resource.Preference;
using System.Diagnostics;
using Server.Models;
using MercadoPago.Client.Payment;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreferenciaController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly AcademiaContext _context;

        public PreferenciaController(IConfiguration configuration, AcademiaContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost]

        public async Task<IActionResult> CrearPreferencia([FromBody] EnviarPagoDto modelo)
        {
            if (modelo.IdentificationType is null)
            {
                modelo.IdentificationType = "CC";
            }

            var accessToken = obtenerAccessToken();
            MercadoPagoConfig.AccessToken = accessToken;

            var productDetails = new Products()
            {
                Id = 1,
                Name = modelo.Description,
                Unit = 1,
                UnitPrice = Convert.ToDouble(modelo.TransactionAmount),
                CategoryId = 8,
                Description = modelo.Description,
            };

            var request = new PreferenceRequest
            {
                Items = new List<PreferenceItemRequest>
        {
            new PreferenceItemRequest
            {
                Id = productDetails.Id.ToString(),
                Title = productDetails.Name,
                CurrencyId = "MXN",
                PictureUrl = "https://www.mercadopago.com/org-img/MP3/home/logomp3.gif",
                Description = productDetails.Description,
                CategoryId = productDetails.CategoryId.ToString(),
                Quantity = productDetails.Unit,
                UnitPrice = Convert.ToDecimal(productDetails.UnitPrice)
            }
        },
                Payer = new PreferencePayerRequest
                {
                    Name = modelo.Email,
                    Surname = modelo.Email.ToUpper(),
                    Email = modelo.Email,
                    Identification = new IdentificationRequest
                    {
                        Type = modelo.IdentificationType,
                        Number = modelo.IdentificationNumber
                    },
                    Address = new AddressRequest
                    {
                        StreetName = modelo.StreetName,
                        StreetNumber = modelo.StreetNumber,
                        ZipCode = modelo.ZipCode
                    },
                    Phone = new PhoneRequest
                    {
                        AreaCode = modelo.PhoneAreaCode,
                        Number = modelo.PhoneNumber
                    }
                },
                BackUrls = new PreferenceBackUrlsRequest
                {
                    Success = "https://localhost:7185/api/Preferencia/Success",
                    Failure = "https://localhost:7185/api/Preferencia/Failure",
                },
                AutoReturn = "approved",
                PaymentMethods = new PreferencePaymentMethodsRequest
                {
                    ExcludedPaymentMethods = new List<PreferencePaymentMethodRequest>(),
                    ExcludedPaymentTypes = new List<PreferencePaymentTypeRequest>(),
                    Installments = 8
                },
                StatementDescriptor = "Sistema de Ventas .net 8",
                ExternalReference = $"Producto={productDetails.Name};Ref={Guid.NewGuid()}",
                Expires = true,
                ExpirationDateFrom = DateTime.Now,
                ExpirationDateTo = DateTime.Now.AddMinutes(10)
            };

            var client = new PreferenceClient();
            Preference preference = await client.CreateAsync(request);

            return Ok(new
            {
                //InitPoint = preference.InitPoint, // URL de pago para producción
                SandboxInitPoint = preference.SandboxInitPoint, // URL de pago en entorno de pruebas
                Id = preference.Id
            });
        }
        [HttpGet("privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("Success")]
        public async Task<IActionResult> Success(
            [FromQuery(Name = "payment_id")] string paymentId,
            [FromQuery(Name = "status")] string status,
            [FromQuery(Name = "payment_type")] string paymentType,
            [FromQuery(Name = "external_reference")] string externalReference)
        {
            var accessToken = obtenerAccessToken();
            MercadoPagoConfig.AccessToken = accessToken;

            var paymentClient = new PaymentClient();
            var payment = await paymentClient.GetAsync(long.Parse(paymentId));
            var nombreProducto = string.Empty;
            if (!string.IsNullOrEmpty(externalReference) && externalReference.Contains("Producto="))
            {
                var partes = externalReference.Split(';');
                foreach (var parte in partes)
                {
                    if (parte.StartsWith("Producto="))
                    {
                        nombreProducto = parte.Replace("Producto=", "");
                        break;
                    }
                }
            }

            var nuevoPago = new Pago
            {
                PaymentId = (long)payment.Id,
                Status = status,
                PaymentType = paymentType,
                EmailComprador = payment.Payer?.Email,
                Monto = payment.TransactionAmount ?? 0,
                FechaCreacion = payment.DateCreated ?? DateTime.Now,
                Concepto = nombreProducto
            };

            _context.Pagos.Add(nuevoPago);
            await _context.SaveChangesAsync();

            return Redirect("http://localhost:5173/pagos/pagoExitoso");
        }

        [HttpGet("Failure")]
        public async Task<IActionResult> Failure([FromQuery] PaymentResponse paymentResponse)
        {
            return Redirect("http://localhost:5173/pagos/pagoRechazado");
        }

        [HttpGet("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region Datos de configuracion para Mercado Pago
        private string obtenerAccessToken()
        {
            var token = _configuration.GetValue<string>("MercadoPago:AccessToken");
            return token.ToString() ?? string.Empty;
        }
        private string obtenerPublicKey()
        {
            var x = _configuration.GetValue<string>("MercadoPago:PublicKey");
            return x.ToString() ?? string.Empty;
        }
        #endregion
    }
}
