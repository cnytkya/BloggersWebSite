using BusinessLayer.Service;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class NewsLetterManager : INewsLetterService
    {
        INewsLetterDal _newsDal;

        public NewsLetterManager(INewsLetterDal newsDal)
        {
            _newsDal = newsDal;
        }

        public void AddNewsLetter(NewsLetter newsLetter)
        {
            _newsDal.Insert(newsLetter);
        }
    }
}
