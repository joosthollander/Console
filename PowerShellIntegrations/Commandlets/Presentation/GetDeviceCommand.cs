﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Layouts;
using Sitecore.Sites;
using Sitecore.Workflows;
using Sitecore.Workflows.Simple;
using Cognifide.PowerShell.PowerShellIntegrations.Commandlets.Data;

namespace Cognifide.PowerShell.PowerShellIntegrations.Commandlets.Presentation
{
    [Cmdlet(VerbsCommon.Get, "Device")]
    [OutputType(new[] {typeof (DeviceItem)}, ParameterSetName = new[] { "By Name", "Default" })]
    public class GetDeviceCommand : BaseCommand
    {
        [Parameter(Position = 0, Mandatory = true,ParameterSetName = "By Name")]
        public string Name { get; set; }

        [Parameter(Position = 0, Mandatory = true,ParameterSetName = "Default")]
        public SwitchParameter Default { get; set; }

        protected override void ProcessRecord()
        {
            if (Default)
            {
                WriteObject(CurrentDatabase.Resources.Devices.GetAll().FirstOrDefault(d => d.IsDefault));
            }
            else
            {
                WildcardWrite(Name, CurrentDatabase.Resources.Devices.GetAll(), device => device.Name);                
            }
        }
    }
}