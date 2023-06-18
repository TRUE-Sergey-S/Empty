using EmptyTemplateWebApiJwtAuthPsql.Interfaces;
using EmptyTemplateWebApiJwtAuthPsql.Models;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace EmptyTemplateWebApiJwtAuthPsql.Repository;

public class TestRepository : ITestRepository
{
    private readonly AppDbContent _appDbContent;
    private readonly Logger _log;
    
    public TestRepository(AppDbContent appDbContent)
    {
        _log = LogManager.GetLogger("ActionLog");
        _appDbContent = appDbContent;
        _log.Info("TestRepository Create");
    }

    public async Task<List<TestData>> TestRequestAsync()
    {
        _log.Info("TestRequestAsync Start");
        var newTestData = new TestData
        {
            TestString = Random.Shared.NextInt64().ToString(),
            GetDateTime = DateTime.UtcNow
        };
        _appDbContent.Tests.Add(newTestData);
        await _appDbContent.SaveChangesAsync();
        var testDataList = await _appDbContent.Tests.OrderByDescending(t=>t.Id).ToListAsync();
        return testDataList;
    }
}