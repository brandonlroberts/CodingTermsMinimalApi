using CodingTermsMinimalApi.Dal.Data;
using CodingTermsMinimalApi.Dal.Repositories.Base;
using CodingTermsMinimalApi.Dal.Repositories.Interfaces;
using CodingTermsMinimalApi.Models;

namespace CodingTermsMinimalApi.Dal.Repositories
{
    public class TermRepo : RepoBase<Term, TermRepo>, ITermRepo
    {
        public TermRepo(ApplicationDbContext context) : base(context)
        {
        }
    }
}
