using AutoMapper;
using cardData.Dto;
using cardData.interfaces;
using cardData.Models;
using Microsoft.AspNetCore.Mvc;

namespace cardData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController:Controller
    {
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;

        public CardController(ICardRepository cardRepository,IMapper mapper)
        {
           _cardRepository = cardRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Card>))]
        public IActionResult GetCards()
        {
            //another test for git
            var cards = _mapper.Map<List<CardDto>>(_cardRepository.GetCards());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(cards);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] CardDto cardCreate)
        {
            if (cardCreate == null)
                return BadRequest(ModelState);
           
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cardMap = _mapper.Map<Card>(cardCreate);

            if (!_cardRepository.CreateCard(cardMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);

            }
            return Ok("Successfully Created");

        }
    }
}

