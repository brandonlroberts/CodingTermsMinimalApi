using CodingTermsMinimalApi.Dal.Repositories.Interfaces;
using CodingTermsMinimalApi.Models;
using CodingTermsMinimalApi.Services.Interfaces;

namespace CodingTermsMinimalApi.Services
{
    public class TermService : ITermService
    {
        private readonly ITermRepo _termRepo;
        public TermService(ITermRepo termRepo)
        {
            _termRepo = termRepo;
        }
        public IResult Create(Term term)
        {
            term.Created = DateTime.Now;
            term.CreatedBy = "system";
            term.IsActive = true;
            var result = _termRepo.Create(term, true);
            return Results.Ok(result);
        }

        public IResult Update(Term term)
        {
            var existingTerm = _termRepo.FindById(term.Id);
            if (existingTerm == null) return null;
            existingTerm.Title = term.Title;
            existingTerm.Description = term.Description;
            existingTerm.Modified = DateTime.Now;
            existingTerm.ModifiedBy = "system";
            var result = _termRepo.Update(existingTerm, true);
            return Results.Ok(result);
        }

        public IResult Delete(int id)
        {
            var term = _termRepo.FindById(id);
            var result = _termRepo.Delete(term, true);
            if (result == 0) Results.BadRequest("Something went wrong");
            return Results.Ok(result);
        }

        public IResult Get(int id)
        {
            var term = _termRepo.FindById(id);
            if (term == null) return Results.NotFound(term);
            return Results.Ok(term);
        }

        public IResult List()
        {
            var terms = _termRepo.GetAllActiveAsQueryableNoTracking().ToList();
            return Results.Ok(terms);
        }
    }
}
