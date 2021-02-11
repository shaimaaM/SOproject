using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Product.DataAccess.Base.Enum;
using Product.DataAccess.Enum;
using SOproject.CustomModel;
using SOproject.Models;
using SOproject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SOproject.Controllers
{
    public class SalesOrderController : Controller
    {
        private readonly ISalesOrderRepository _salesOrderRepository; 
        private readonly ISalesOrderLinesRepository _salesOrderLinesRepository; 
        private readonly IMapper _mapper;
        private readonly HttpClient _client;
        private readonly IHttpClientFactory _httpClientFactory;

        
        public SalesOrderController(ISalesOrderRepository salesOrdersRepository, ISalesOrderLinesRepository salesOrderLinesRepository, IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _salesOrderRepository = salesOrdersRepository;
            _salesOrderLinesRepository = salesOrderLinesRepository;
            _mapper = mapper;
            _client = CreateHttpClientWithNTLM();
            _httpClientFactory = httpClientFactory;

        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> IndexDBAjax([FromBody] SalesOrderCM model)
        {
            var list = _salesOrderRepository.GetAllAsyncPage(model.PageNo,model.PageSize);
            var list2 = new List<SlaesOrderHeaderAndLines.Value>();

            foreach (var item in list.Item1)
            {
               var newSO = new SlaesOrderHeaderAndLines.Value()
                {
                   No = item.Number,
                  Sell_to_Customer_Name = item.CustomerName,
                  Posting_Description = item.Description,
                  Order_Date = item.OrderDate.ToShortDateString(),
                  Phone_No = item.PhoneNumber,
                  Shipment_Date = item.ShipmentDate.ToShortDateString(),
                  CRM_Cost_Amount = item.Ammount.ToString(),
                  SalesOrderSalesLines = null
               };
                list2.Add(newSO);
            }
            return Json(new
            {
                TotalItems = list.Item2,
                Data = list2
            });
        }

        public async Task<JsonResult> IndexAjax([FromBody] SalesOrderCM model)
        {
            var resultt = await _client.GetAsync($@"{_client.BaseAddress}/SalesOrder?$filter={model.Number}");
            var NotofocationList = JsonConvert.DeserializeObject<SlaesOrderHeaderAndLines.Rootobject>(await resultt.Content.ReadAsStringAsync());
          
            return Json(new
            {
                TotalItems = 3,
                Data = NotofocationList.value
            });
        }
        public HttpClient CreateHttpClientWithNTLM()
        {
            var url = "http://ns-hou-navdev01.netsync.com:9837/DEVNETSYNC2018/ODataV4/Company(";

            var uri = new Uri($"{url}'NetSync%20Network%20-%20Live')");
            var credentialsCache = new CredentialCache { { uri, "NTLM", new NetworkCredential("sales", "Netsync01") } };
            var handler = new HttpClientHandler { Credentials = credentialsCache };
            var httpClient = new HttpClient(handler) { BaseAddress = uri };
            httpClient.DefaultRequestHeaders.ConnectionClose = false;
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            ServicePointManager.FindServicePoint(uri).ConnectionLeaseTimeout = 120 * 1000;  // Close connection after two minutes

            return httpClient;
        }

        public async Task<IActionResult> _Details(string soNo)
        {
           return PartialView( new SalesOrderCM() { Number=soNo }); ;
        }

        public async Task<IActionResult> DetailsAjax([FromBody]SalesOrderCM model)
        {
            var resultt = await _client.GetAsync($@"{_client.BaseAddress}/SalesOrder?$filter={model.Number}&$expand=SalesOrderSalesLines");
            var NotofocationList = JsonConvert.DeserializeObject<SlaesOrderHeaderAndLines.Rootobject>(await resultt.Content.ReadAsStringAsync());
            var count = NotofocationList.value[0].SalesOrderSalesLines.Count();

            return Json(new
            {
                TotalItems = count,
                Data = NotofocationList.value[0].SalesOrderSalesLines
            });
        }

        [HttpPost]
        public async Task<IActionResult> SaveToDB([FromBody]string No)
        {
            var getapi = await _client.GetAsync($@"{_client.BaseAddress}/SalesOrder?$filter={No}&$expand=SalesOrderSalesLines");
            var SOLineList = JsonConvert.DeserializeObject<SlaesOrderHeaderAndLines.Rootobject>(await getapi.Content.ReadAsStringAsync());
            var SO = SOLineList.value[0];
            var SOLines = SOLineList.value[0].SalesOrderSalesLines.ToList();

            if (_salesOrderRepository.Find(SO.No) != null)
            {
                return Json(new
                {
                    status = JsonStatus.Exist,
                    color = NotificationColor.Error.ToColorName(),
                    management = "SalesOrder Management",
                    msg = "This SalesOrder is already saved in DB.",
                });
            }
            else
            {
                var res =  await _salesOrderRepository.AddAsync(new SalesOrder()
                {
                    Number = SO.No,
                    CustomerName = SO.Sell_to_Customer_Name,
                    Description = SO.Posting_Description,
                    OrderDate = Convert.ToDateTime(SO.Order_Date),
                    PhoneNumber = SO.Phone_No,
                    ShipmentDate = Convert.ToDateTime(SO.Shipment_Date),
                    Ammount = Convert.ToDecimal(SO.CRM_Cost_Amount)
                });

                if (res > 0)
                {
                    foreach (var sol in SOLines)
                    {
                        await _salesOrderLinesRepository.AddAsync(new SOLines()
                        {
                            Number = sol.No,
                            Description = sol.Description,
                            Quantity = sol.Quantity,
                            JobNumber = sol.Job_No,
                            UnitPrice = sol.Unit_Price,
                            SalesOrder = _salesOrderRepository.Find(SO.No)
                        });
                    }
                    return Json(new
                    {
                        status = JsonStatus.Success,
                        color = NotificationColor.Success.ToColorName(),
                        management = "SalesOrder Management",
                        msg = "The SalesOrder is saved succesfully.",
                    });
                }
                else
                    return Json(new
                    {
                        status = JsonStatus.Error,
                        color = NotificationColor.Error.ToColorName(),
                        management = "SalesOrder Management",
                        msg = "Error Happened",
                    });
            }

        }
    }
}

