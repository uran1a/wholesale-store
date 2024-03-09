using Duende.IdentityServer.Test;

namespace WholesaleStore.Identity.Configuration.ISp;

public static class AppApiTestUsers
{
    public static List<TestUser> ApiUsers =>
        new List<TestUser>
        {
            new TestUser
            {
                SubjectId = "1",
                Username = "nikita@mail.ru",
                Password = "password"
            },
            new TestUser
            {
                SubjectId = "2",    
                Username = "ivan@mail.ru",
                Password = "password"
            }
        };
}
