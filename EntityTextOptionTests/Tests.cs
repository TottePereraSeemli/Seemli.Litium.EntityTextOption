using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EntityTextOptionTests.LitiumDummyServices;
using Litium.Blocks;
using Litium.ComponentModel.Internal;
using Litium.Customers;
using Litium.Data;
using Litium.Globalization;
using Litium.Media;
using Litium.Products;
using Litium.Runtime;
using Litium.Sales;
using Microsoft.Extensions.DependencyInjection;
using Seemli.Litium.EntityTextOption;
using Seemli.Litium.EntityTextOption.Entities;
using Seemli.Litium.EntityTextOption.Registrations;
using Xunit;

namespace EntityTextOptionTests;

public class Tests
{
    public Tests()
    {
        InitMapper();
    }
    
    private static void InitMapper()
    {
        Mapper.Reset();
        Mapper.Initialize(_ =>
        {
        });
    }
    
    [Fact]
    public void Test_Add_Entity_Text_Option_Multi_Select()
    {
        var services = (IServiceCollection) new ServiceCollection();
        RegisterLitiumServices(services);

        services.AddEntityTextOption<Channel, CustomerArea>(c =>
        {
            c.FieldId = "test";
            c.MultiSelect = true;
            c.AreaType = typeof(CustomerArea);
            c.EntityType = typeof(Channel);
        });


        var sp = services.BuildServiceProvider();

        var registration = sp.GetRequiredService<IEntityTextOption<IEntityKey, IArea>>();

        Assert.NotNull(registration);
        var entityTextOptionService = services.BuildServiceProvider().GetService<IEntityTextOptionService>();
        
        var person = new Person(Guid.Empty);
        person.Fields.AddOrUpdateValue("test", new List<string> { "B4F788F3-0149-41B4-BA15-C48782C91BD3" });
        
        Assert.Throws<ArgumentException>(() =>
            entityTextOptionService?.GetEntity<Channel, CustomerArea>("test", person.Fields));

        var channel = entityTextOptionService?.GetEntities<Channel, CustomerArea>("test", person.Fields);

        Assert.NotNull(channel.FirstOrDefault());
    }
    
    [Fact]
    public void Test_Add_Entity_Text_Option_Single_Select()
    {
        var services = (IServiceCollection) new ServiceCollection();
        RegisterLitiumServices(services);

        services.AddEntityTextOption<Channel, CustomerArea>(c =>
        {
            c.FieldId = "test";
            c.MultiSelect = false;
            c.AreaType = typeof(CustomerArea);
            c.EntityType = typeof(Channel);
        });


        var sp = services.BuildServiceProvider();

        var registration = sp.GetRequiredService<IEntityTextOption<IEntityKey, IArea>>();

        Assert.NotNull(registration);
        var entityTextOptionService = services.BuildServiceProvider().GetService<IEntityTextOptionService>();
        
        var person = new Person(Guid.Empty);
        person.Fields.AddOrUpdateValue("test", "B4F788F3-0149-41B4-BA15-C48782C91BD3");
        
        var channel = entityTextOptionService?.GetEntity<Channel, CustomerArea>("test", person.Fields);

        Assert.NotNull(channel);
    }

    private static void RegisterLitiumServices(IServiceCollection services)
    {
        services.AddSingleton<AddressTypeService, AddressTypeServiceImpl>();
        services.AddSingleton<DataService, DataServiceImpl>();
        services.AddSingleton<BlockService, BlockServiceImpl>();
        services.AddSingleton<CampaignService, CampaignServiceImpl>();
        services.AddSingleton<ChannelService, ChannelServiceImpl>();
        services.AddSingleton<LanguageService, LanguageServiceImpl>();
        services.AddSingleton<CurrencyService, CurrencyServiceImpl>();
        services.AddSingleton<DiscountService, DiscountServiceImpl>();
        services.AddSingleton<DomainNameService, DomainNameServiceImpl>();
        services.AddSingleton<FolderService, FolderServiceImpl>();
        services.AddSingleton<InventoryService, InventoryServiceImpl>();
        services.AddSingleton<MarketService, MarketServiceImpl>();
        services.AddSingleton<PaymentProviderService, PaymentProviderServiceImpl>();
        services.AddSingleton<PriceListService, PriceListServiceImpl>();
        services.AddSingleton<RelationshipTypeService, RelationshipTypeServiceImpl>();
        services.AddSingleton<RoleService, RoleServiceImpl>();
        services.AddSingleton<ShippingProviderService, ShippingProviderServiceImpl>();
        services.AddSingleton<TaxClassService, TaxClassServiceImpl>();
        services.AddSingleton<UnitOfMeasurementService, UnitOfMeasurementServiceImpl>();
    }
}