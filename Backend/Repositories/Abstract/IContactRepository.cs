using System.Threading.Tasks;
using System.Collections.Generic;

public interface IContactRepository
{
    void DeleteContact(Contact contact);
    Task<Contact> FindByEmailAsync(string email);
    void AddContact(Contact model);
    void ModifyContact(ContactViewModel model, Contact contact);
    Task<Contact> GetContact(int id);
    Task<List<Contact>> GetContacts(int companyId, int page);
    int GetTotalPagesContacts(int companyId);


}