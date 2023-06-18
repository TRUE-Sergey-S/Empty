using EmptyTemplateWebApiJwtAuthPsql.Models;

namespace EmptyTemplateWebApiJwtAuthPsql.Interfaces;

public interface ITestRepository
{
    Task<List<TestData>> TestRequestAsync();
}