using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactDB;
using System.Collections.Generic;
using System.Linq;

namespace ContactRepository
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneType { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Notes { get; set; }
        public System.DateTime CreatedDate { get; set; }
    }

    public class ContactRepository
    {
        public ContactModel Add(ContactModel contactModel)
        {
            var contactDb = ToDbModel(contactModel);

            DatabaseManager.Instance.Contacts.Add(contactDb);
            DatabaseManager.Instance.SaveChanges();

            contactModel = new ContactModel
            {
                Age = contactDb.ContactAge,
                CreatedDate = contactDb.ContactCreatedDate,
                Email = contactDb.ContactEmail,
                Id = contactDb.ContactId,
                Name = contactDb.ContactName,
                Notes = contactDb.ContactNotes,
                PhoneNumber = contactDb.ContactPhoneNumber,
                PhoneType = contactDb.ContactPhoneType
            };
            return contactModel;
        }

        public List<ContactModel> GetAll()
        {
            // Use .Select() to map the database contacts to ContactModel
            var items = DatabaseManager.Instance.Contacts
              .Select(t => new ContactModel
              {
                  Age = t.ContactAge,
                  CreatedDate = t.ContactCreatedDate,
                  Email = t.ContactEmail,
                  Id = t.ContactId,
                  Name = t.ContactName,
                  Notes = t.ContactNotes,
                  PhoneNumber = t.ContactPhoneNumber,
                  PhoneType = t.ContactPhoneType,
              }).ToList();

            return items;
        }

        public bool Update(ContactModel contactModel)
        {
            var original = DatabaseManager.Instance.Contacts.Find(contactModel.Id);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(contactModel));
                DatabaseManager.Instance.SaveChanges();
            }

            return false;
        }

        public bool Remove(int contactId)
        {
            var items = DatabaseManager.Instance.Contacts
                                .Where(t => t.ContactId == contactId);

            if (items.Count() == 0)
            {
                return false;
            }

            DatabaseManager.Instance.Contacts.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();

            return true;
        }

        private Contact ToDbModel(ContactModel contactModel)
        {
            var contactDb = new Contact
            {
                ContactAge = contactModel.Age,
                ContactCreatedDate = contactModel.CreatedDate,
                ContactEmail = contactModel.Email,
                ContactId = contactModel.Id,
                ContactName = contactModel.Name,
                ContactNotes = contactModel.Notes,
                ContactPhoneNumber = contactModel.PhoneNumber,
                ContactPhoneType = contactModel.PhoneType,
            };

            return contactDb;
        }
    }
}
