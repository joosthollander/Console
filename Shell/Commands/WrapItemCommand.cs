﻿using System.Management.Automation;
using Sitecore.Data.Items;

namespace Cognifide.PowerShell.Shell.Commands
{
    [Cmdlet("Wrap", "Item", SupportsShouldProcess = true, DefaultParameterSetName = "Item")]
    public class WrapItemCommand : BaseCommand
    {
        [Parameter(ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public Item Item { get; set; }

        protected override void ProcessRecord()
        {
            if (Item != null)
            {
                PSObject psobj = ItemShellExtensions.GetPsObject(SessionState, Item);
                WriteObject(psobj, false);
            }
        }
    }
}