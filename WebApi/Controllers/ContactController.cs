using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Infra.Entidade;
using WebApi.Model;
using WebApi.Uow;

namespace WebApi
{
    [EnableCors]
    [Route("api/v1/contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactUow _uow;
        private IMapper _mapper;
        public ContactController(ContactUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        
        [EnableCors]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ContactModel>> GetById(int id)
        {

            try
            {
                var result = await _uow.contact.GetById(id);
                if (result == null)
                    return BadRequest(new { success = false, message = "Contact not found!!" });


                return Ok(new { success = true, message = "Operation completed successfully!", data = _mapper.Map<ContactEntity>(result)  });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }


        [EnableCors]
        [HttpGet("")]
        public async Task<ActionResult<List<ContactModel>>> GetAll()
        {
            try
            {
                var result = await _uow.contact.GetAll();
                return Ok(new { success = true, message = "Operation completed successfully!", data = _mapper.Map<List<ContactModel>>(result) });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }

        }

        [EnableCors]
        [HttpPost()]
        [AllowAnonymous]
        public ActionResult<ContactEntity> Insert([FromBody]ContactModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).ToList();
                    return Ok(new { success = false, message = errors [0]});
                }

                _uow.contact.Insert(_mapper.Map<ContactEntity>(model));
                return Ok(new { success = true, message = "Contact successfully registered!", data = model });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [EnableCors]
        [HttpPut("{id:int}")]
        public ActionResult<ContactModel> Update(int id, [FromBody]ContactModel model)
        {
            try
            {
                    if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _uow.contact.Update(_mapper.Map<ContactEntity>(model));
                return Ok(new { success = true, message = "Contact successfully update!", data = model });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [EnableCors]
        [HttpDelete("{id:int}")]
        public ActionResult<ContactModel> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _uow.contact.Delete(id);
                return Ok(new { success = true, message = "Contact successfully deleted!", data = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

    }
}
