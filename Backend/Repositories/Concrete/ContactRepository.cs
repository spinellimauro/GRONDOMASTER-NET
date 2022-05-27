using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

public class ContactRepository : IContactRepository
{

    private readonly ApplicationDbContext db;
    private readonly Settings settings;
    private readonly IHelpers helpers;

    public ContactRepository(ApplicationDbContext db,
            IOptions<Settings> _settings, IHelpers _helpers)
    {
        this.db = db;
        this.settings = _settings.Value;
        this.helpers = _helpers;
    }


    public void DeleteContact(Contact contact)
    {
        db.Contacts.Remove(contact);
    }

    public Task<Contact> FindByEmailAsync(string email)
    {
        return db.Contacts.FirstOrDefaultAsync(contact => contact.Email == email);
    }

    public void AddContact(Contact contact)
    {
        db.Contacts.Add(contact);
    }

    public void ModifyContact(ContactViewModel model, Contact contact)
    {
        contact.FirstName = model.FirstName;
        contact.LastName = model.LastName;
        contact.CompanyId = model.CompanyId;
        contact.PhoneNumber = model.PhoneNumber;
    }

    public async Task<Contact> GetContact(int id)
    {
        return await db.Contacts.FindAsync(id);
    }

    public async Task<List<Contact>> GetContacts(int companyId, int page)
    {
        int totalItemsPerPages = helpers.GetTotalPages();

        return await db.Contacts.Where(contact => contact.CompanyId == companyId).Skip((page - 1) * totalItemsPerPages)
               .Take(totalItemsPerPages).ToListAsync();
    }

    public int GetTotalPagesContacts(int companyId)
    {
        int totalItemsPerPages = helpers.GetTotalPages();

        int count = db.Contacts.Where(contact => contact.CompanyId == companyId).Count();

        return count / totalItemsPerPages;
    }

}
