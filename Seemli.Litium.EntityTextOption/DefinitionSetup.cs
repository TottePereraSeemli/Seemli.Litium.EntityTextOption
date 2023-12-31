﻿using Litium.Common;
using Litium.ComponentModel.Internal;
using Litium.FieldFramework;
using Litium.FieldFramework.FieldTypes;
using Litium.Runtime;
using Litium.Security;
using Seemli.Litium.EntityTextOption.Entities;
using Seemli.Litium.EntityTextOption.Entity;

namespace Seemli.Litium.EntityTextOption;

[Autostart]
public class DefinitionSetup : IAsyncAutostart
{
    private readonly FieldDefinitionService _fieldDefinitionService;
    private readonly SecurityContextService _securityContextService;
    private readonly FieldFrameworkSetupLocalizationService _fieldFrameworkSetupLocalizationService;
    private readonly SettingService _settingService;
    private readonly IEnumerable<IEntityTextOption<IEntityKey, IArea>> _entityTextOptions;
    private readonly IEntityTextOptionService _entityTextOptionService;

    public DefinitionSetup(
        FieldDefinitionService fieldDefinitionService,
        SecurityContextService securityContextService,
        FieldFrameworkSetupLocalizationService fieldFrameworkSetupLocalizationService,
        SettingService settingService,
        IEnumerable<IEntityTextOption<IEntityKey, IArea>> entityTextOptions,
        IEntityTextOptionService entityTextOptionService)
    {
        _fieldDefinitionService = fieldDefinitionService;
        _securityContextService = securityContextService;
        _fieldFrameworkSetupLocalizationService = fieldFrameworkSetupLocalizationService;
        _settingService = settingService;
        _entityTextOptions = entityTextOptions;
        _entityTextOptionService = entityTextOptionService;
    }

    public ValueTask StartAsync(CancellationToken cancellationToken)
    {
        using (_securityContextService.ActAsSystem())
        {
            CreateFields();
        }
        
        return ValueTask.CompletedTask;
    }

    private void CreateFields()
    {
        foreach (var option in _entityTextOptions)
        {
            var currentField = _fieldDefinitionService.Get(option.AreaType, option.FieldId);
            if (currentField == null)
            {
                var item = new FieldDefinition(option.FieldId, SystemFieldTypeConstants.TextOption, option.AreaType)
                {
                    Option = new TextOption
                    {
                        MultiSelect = option.MultiSelect,
                        Items = _entityTextOptionService.GetEntityItems(option.EntityType)
                    }
                };

                _fieldFrameworkSetupLocalizationService.Localize(item);
                _fieldDefinitionService.Create(item);
                SetAlreadyExecuted<FieldDefinition>(item.Id, item.AreaType.Name);
            }
        }
    }

    private void SetAlreadyExecuted<T>(string id, string? area = null)
    {
        if (area == null)
        {
            _settingService.Set($"AcceleratorBuilder:{typeof(T).FullName}:{id}", true);
        }

        _settingService.Set($"AcceleratorBuilder:{typeof(T).FullName}:{area}:{id}", true);
    }
}