using System;
using Litium.Customers;
using Litium.Globalization;
using Litium.Products;
using Litium.Runtime;
using Microsoft.Extensions.DependencyInjection;
using SpotOn.Litium.EntityTextOption;
using SpotOn.Litium.EntityTextOption.Entity;
using SpotOn.Litium.EntityTextOption.Registrations;
using Xunit;

namespace EntityTextOptionTests;

public class UnitTest1
{
    [Fact]
    public void Test_Add_Entity_Text_Option()
    {
        var services = (IServiceCollection) new ServiceCollection();
        services.AddEntityTextOption<Channel, CustomerArea>(c =>
        {
            c.FieldId = "test";
            c.MultiSelect = true;
            c.AreaType = typeof(CustomerArea);
            c.EntityType = typeof(Channel);
        });

        var sp = services.BuildServiceProvider();

        var registration = sp.GetRequiredService<IEntityTextOption<Channel, IArea>>();
        
        Assert.NotNull(registration);
        
        var entityTextOptionService = services.BuildServiceProvider().GetService<IEntityTextOptionService>();
        var person = new Person(Guid.Empty);
        var channel = entityTextOptionService?.GetEntity<Channel>(person.Fields.GetValue<string>("test"));
    }
}