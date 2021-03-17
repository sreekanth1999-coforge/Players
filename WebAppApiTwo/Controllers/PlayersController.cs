using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppApiTwo.Models;

namespace WebAppApiTwo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        static List<Player> listplay = new List<Player>
        {
            new Player
            {PId=1,PName="Dhoni",PTeam="India",PDOB=DateTime.Parse("10/02/1990")},
            new Player
            {PId=2,PName="Jofer Archer",PTeam="England",PDOB=DateTime.Parse("11/09/1992")},
            new Player
            {PId=3,PName="Kholi",PTeam="India",PDOB=DateTime.Parse("02/02/1993")},

        };
        [HttpGet]
        public IEnumerable<Player> Get()
        {
            return listplay;
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = listplay.SingleOrDefault(n => listplay.IndexOf(n) == id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = listplay.SingleOrDefault(n => listplay.IndexOf(n) == id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                listplay.RemoveAt(id);
                return NoContent();

            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] Player obj)
        {
            listplay.Add(obj);
            //{
            //    PId=obj.PId,
            //    PName=obj.PName,
            //    PTeam=obj.PTeam,
            //    PDOB=obj.PDOB
            //});
              return NoContent();
        }
        [HttpPut("{id}")]
        public ActionResult put(int id, [FromBody] Player player)
        {
            var result = listplay.SingleOrDefault(n => listplay.IndexOf(n) == id);
            if (result != null)
            {
                result.PId = player.PId;
                result.PName = player.PName;
                result.PTeam = player.PTeam;
                result.PDOB = player.PDOB;
                return NoContent();
            }
            else
            {
                return BadRequest("Not a valid Id");
            }
        }
    }
}

    