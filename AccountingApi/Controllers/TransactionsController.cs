using System;
using AccountingApi.Models;
using AccountingApi.ServicesLayer;
using AccountingApi.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsService _transactionsService;

        public TransactionsController(ITransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
        }
        // GET api/transactions
        [HttpGet]
        [ProducesResponseType(typeof(TransactionResponse[]), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var transactions = _transactionsService.GetAll();
            return Ok(transactions);
        }

        // GET api/transactions/{GUID}
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TransactionResponse), StatusCodes.Status200OK)]
        public IActionResult Get(Guid id)
        {
            return Ok(_transactionsService.Get(id));
        }

        // POST api/transactions
        [HttpPost]
        [ProducesResponseType(typeof(TransactionResponse), StatusCodes.Status200OK)]
        public IActionResult Add([FromBody] TransactionRequest transactionModel)
        {
            try
            {
                return Ok(_transactionsService.Add(transactionModel));
            }
            catch (NegativeAmountException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
