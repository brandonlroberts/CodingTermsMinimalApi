using CodingTermsMinimalApi.Models;

namespace CodingTermsMinimalApi.Services.Interfaces
{
    public interface ITermService
    {
        public IResult Create(Term term);
        public IResult Update(Term term);
        public IResult Get(int id);
        public IResult List();
        public IResult Delete(int id);

    }
}
