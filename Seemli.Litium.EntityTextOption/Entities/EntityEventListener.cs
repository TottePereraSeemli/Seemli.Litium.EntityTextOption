using Litium.Blocks;
using Litium.Blocks.Events;
using Litium.ComponentModel.Internal;
using Litium.Customers;
using Litium.Customers.Events;
using Litium.Events;
using Litium.FieldFramework;
using Litium.FieldFramework.FieldTypes;
using Litium.Globalization;
using Litium.Globalization.Events;
using Litium.Media;
using Litium.Media.Events;
using Litium.Products;
using Litium.Products.Events;
using Litium.Runtime;
using Litium.Sales;
using Litium.Sales.Events;
using Litium.Security;
using Seemli.Litium.EntityTextOption.Entity;

namespace Seemli.Litium.EntityTextOption.Entities;

[Autostart]
public class ChannelEventListener : IAsyncAutostart
{
    private readonly SecurityContextService _securityContextService;
    private readonly FieldDefinitionService _fieldDefinitionService;
    private readonly IEnumerable<IEntityTextOption<IEntityKey, IArea>> _entities;
    private readonly IEntityTextOptionService _entityTextOptionService;
    private readonly EventBroker _eventBroker;

    public ChannelEventListener(
        SecurityContextService securityContextService,
        FieldDefinitionService fieldDefinitionService,
        IEnumerable<IEntityTextOption<IEntityKey, IArea>> entities,
        IEntityTextOptionService entityTextOptionService,
        EventBroker eventBroker
    )
    {
        _securityContextService = securityContextService;
        _fieldDefinitionService = fieldDefinitionService;
        _entities = entities;
        _entityTextOptionService = entityTextOptionService;
        _eventBroker = eventBroker;
    }

    public ValueTask StartAsync(CancellationToken cancellationToken)
    {
        _eventBroker.Subscribe<ChannelUpdated>(_ => UpdateField(typeof(global::Litium.Globalization.Channel)));
        _eventBroker.Subscribe<ChannelCreated>(_ => UpdateField(typeof(global::Litium.Globalization.Channel)));
        _eventBroker.Subscribe<ChannelDeleted>(_ => UpdateField(typeof(global::Litium.Globalization.Channel)));

        _eventBroker.Subscribe<AddressTypeUpdated>(_ => UpdateField(typeof(global::Litium.Customers.AddressType)));
        _eventBroker.Subscribe<AddressTypeCreated>(_ => UpdateField(typeof(global::Litium.Customers.AddressType)));
        _eventBroker.Subscribe<AddressTypeDeleted>(_ => UpdateField(typeof(global::Litium.Customers.AddressType)));

        _eventBroker.Subscribe<BlockCreated>(_ => UpdateField(typeof(Block)));
        _eventBroker.Subscribe<BlockUpdated>(_ => UpdateField(typeof(Block)));
        _eventBroker.Subscribe<BlockDeleted>(_ => UpdateField(typeof(Block)));

        _eventBroker.Subscribe<RoleCreated>(_ => UpdateField(typeof(Role)));
        _eventBroker.Subscribe<RoleUpdated>(_ => UpdateField(typeof(Role)));
        _eventBroker.Subscribe<RoleDeleted>(_ => UpdateField(typeof(Role)));

        _eventBroker.Subscribe<CurrencyCreated>(_ => UpdateField(typeof(Currency)));
        _eventBroker.Subscribe<CurrencyUpdated>(_ => UpdateField(typeof(Currency)));
        _eventBroker.Subscribe<CurrencyDeleted>(_ => UpdateField(typeof(Currency)));

        _eventBroker.Subscribe<DomainNameCreated>(_ => UpdateField(typeof(DomainName)));
        _eventBroker.Subscribe<DomainNameUpdated>(_ => UpdateField(typeof(DomainName)));
        _eventBroker.Subscribe<DomainNameDeleted>(_ => UpdateField(typeof(DomainName)));

        _eventBroker.Subscribe<LanguageCreated>(_ => UpdateField(typeof(Language)));
        _eventBroker.Subscribe<LanguageUpdated>(_ => UpdateField(typeof(Language)));
        _eventBroker.Subscribe<LanguageDeleted>(_ => UpdateField(typeof(Language)));

        _eventBroker.Subscribe<MarketCreated>(_ => UpdateField(typeof(Market)));
        _eventBroker.Subscribe<MarketUpdated>(_ => UpdateField(typeof(Market)));
        _eventBroker.Subscribe<MarketDeleted>(_ => UpdateField(typeof(Market)));

        _eventBroker.Subscribe<TaxClassCreated>(_ => UpdateField(typeof(TaxClass)));
        _eventBroker.Subscribe<TaxClassUpdated>(_ => UpdateField(typeof(TaxClass)));
        _eventBroker.Subscribe<TaxClassDeleted>(_ => UpdateField(typeof(TaxClass)));

        _eventBroker.Subscribe<FolderCreated>(_ => UpdateField(typeof(Folder)));
        _eventBroker.Subscribe<FolderUpdated>(_ => UpdateField(typeof(Folder)));
        _eventBroker.Subscribe<FolderDeleted>(_ => UpdateField(typeof(Folder)));

        _eventBroker.Subscribe<InventoryCreated>(_ => UpdateField(typeof(Inventory)));
        _eventBroker.Subscribe<InventoryUpdated>(_ => UpdateField(typeof(Inventory)));
        _eventBroker.Subscribe<InventoryDeleted>(_ => UpdateField(typeof(Inventory)));

        _eventBroker.Subscribe<PriceListCreated>(_ => UpdateField(typeof(PriceList)));
        _eventBroker.Subscribe<PriceListUpdated>(_ => UpdateField(typeof(PriceList)));
        _eventBroker.Subscribe<PriceListDeleted>(_ => UpdateField(typeof(PriceList)));

        _eventBroker.Subscribe<RelationshipTypeCreated>(_ => UpdateField(typeof(RelationshipType)));
        _eventBroker.Subscribe<RelationshipTypeUpdated>(_ => UpdateField(typeof(RelationshipType)));
        _eventBroker.Subscribe<RelationshipTypeDeleted>(_ => UpdateField(typeof(RelationshipType)));

        _eventBroker.Subscribe<UnitOfMeasurementCreated>(_ => UpdateField(typeof(UnitOfMeasurement)));
        _eventBroker.Subscribe<UnitOfMeasurementCreated>(_ => UpdateField(typeof(UnitOfMeasurement)));
        _eventBroker.Subscribe<UnitOfMeasurementUpdated>(_ => UpdateField(typeof(UnitOfMeasurement)));

        _eventBroker.Subscribe<CampaignUpdated>(_ => UpdateField(typeof(Campaign)));
        _eventBroker.Subscribe<CampaignDeleted>(_ => UpdateField(typeof(Campaign)));
        _eventBroker.Subscribe<CampaignDeleted>(_ => UpdateField(typeof(Campaign)));

        _eventBroker.Subscribe<DiscountUpdated>(_ => UpdateField(typeof(Discount)));
        _eventBroker.Subscribe<DiscountDeleted>(_ => UpdateField(typeof(Discount)));
        _eventBroker.Subscribe<DiscountDeleted>(_ => UpdateField(typeof(Discount)));

        _eventBroker.Subscribe<PaymentProviderUpdated>(_ => UpdateField(typeof(PaymentProvider)));
        _eventBroker.Subscribe<PaymentProviderDeleted>(_ => UpdateField(typeof(PaymentProvider)));
        _eventBroker.Subscribe<PaymentProviderDeleted>(_ => UpdateField(typeof(PaymentProvider)));

        _eventBroker.Subscribe<ShippingProviderUpdated>(_ => UpdateField(typeof(ShippingProvider)));
        _eventBroker.Subscribe<ShippingProviderDeleted>(_ => UpdateField(typeof(ShippingProvider)));
        _eventBroker.Subscribe<ShippingProviderDeleted>(_ => UpdateField(typeof(ShippingProvider)));


        return ValueTask.CompletedTask;
    }

    private void UpdateField(Type typeAffected)
    {
        var channelSpecific = _entities.Where(x => x.EntityType == typeAffected);

        foreach (var test in channelSpecific)
        {
            var fieldDefinition = _fieldDefinitionService.Get(test.AreaType, test.FieldId);
            fieldDefinition = fieldDefinition.MakeWritableClone();

            fieldDefinition.Option = new TextOption
            {
                MultiSelect = test.MultiSelect,
                Items = _entityTextOptionService.GetEntityItems(test.EntityType)
            };

            using (_securityContextService.ActAsSystem())
            {
                _fieldDefinitionService.Update(fieldDefinition);
            }
        }
    }
}