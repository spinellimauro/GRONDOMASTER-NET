using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.Extensions.Options;

namespace Gaby.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {

        private readonly IContactRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly Messages messages;


        public ContactController(IContactRepository _repository,
            IUnitOfWork _unitOfWork,
            IMapper _mapper,
            IOptions<Messages> _messages)
        {
            repository = _repository;
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            messages = _messages.Value;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> CreateContact([FromBody] ContactViewModel model)
        {

            var contactDb = await repository.FindByEmailAsync(model.Email);

            if (contactDb != null)
                return NotFound(messages.ExistingContactError);

            Contact contact = mapper.Map<ContactViewModel, Contact>(model);

            repository.AddContact(contact);

            await unitOfWork.CompleteAsync();

            return Ok(mapper.Map<Contact, ContactViewModel>(contact));

        }

        // [HttpGet("GetContacts/{company}/{page}")]
        // public ActionResult<List<Contact>> GetContacts(int company, int page)
        // {
        //     page = page < 1 ? 1 : page;

        //     List<Contact> contacts = repository.GetContacts(company, page).Result;
        //     int totalPages = repository.GetTotalPagesContacts(company);

        //     ContactsPage contactsPage = new ContactsPage(page, contacts, totalPages);

        //     return Ok(mapper.Map<ContactsPage, ContactsPageViewModel>(contactsPage));
        // }

        [HttpPut("{id}")]
        public async Task<ActionResult<Contact>> ModifyContact(int id, [FromBody] ContactViewModel model)
        {
            Contact contact = repository.GetContact(id).Result;

            if (contact == null)
                return NotFound(messages.NonExistingContactError);

            repository.ModifyContact(model, contact);

            await unitOfWork.CompleteAsync();

            return Ok(mapper.Map<Contact, ContactViewModel>(contact));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            Contact contact = repository.GetContact(id).Result;

            if (contact == null)
                return NotFound(messages.NonExistingContactError);

            repository.DeleteContact(contact);

            await unitOfWork.CompleteAsync();

            return Ok(new { message = "The contact was deleted successfully" });
        }

    }
}
