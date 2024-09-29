using Business.Abstract;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContactManager(IContactDal contactDal) : IContactService
    {
        private readonly IContactDal _contactDal = contactDal;

        public IResult AddContact(Contact contact)
        {
            _contactDal.Add(contact);
            return new SuccessResult();
        }

        public IResult DeleteContact(int id)
        {
            Contact deleteContact = null;
            Contact resultContact = _contactDal.Get(c => c.Id == id && c.IsDeleted == false);
            if (resultContact != null)
            {
                deleteContact = resultContact;
            }
            deleteContact.IsDeleted = true;
            _contactDal.Delete(deleteContact);
            return new SuccessResult();
        }

        public IDataResult<List<Contact>> GetAllContacts()
        {
            var contacts = _contactDal.GetAll(c => c.IsDeleted == false).ToList();
            if(contacts.Count != 0)
                return new SuccessDataResult<List<Contact>>(contacts);
            return new ErrorDataResult<List<Contact>>(contacts);
        }

        public IResult UpdateContact(Contact contact)
        {
            Contact updateContact;
            updateContact = _contactDal.Get(c => c.Id == contact.Id && c.IsDeleted == false);
            updateContact.Address = contact.Address;
            updateContact.PhoneNumber = contact.PhoneNumber;
            updateContact.Facebook = contact.Facebook;
            updateContact.Twitter = contact.Twitter;
            updateContact.Email = contact.Email;
            updateContact.Instagram = contact.Instagram;
            updateContact.LinkedIn = contact.LinkedIn;
            _contactDal.Update(contact);
            return new SuccessResult();
        }
    }
}
