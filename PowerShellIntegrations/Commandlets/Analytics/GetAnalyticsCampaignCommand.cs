﻿using System.Management.Automation;

namespace Cognifide.PowerShell.PowerShellIntegrations.Commandlets.Analytics
{
    [Cmdlet("Get", "AnalyticsCampaign", DefaultParameterSetName = "Name")]
    public class GetAnalyticsCampaignCommand : AnalyticsBaseCommand
    {
        protected override void ProcessRecord()
        {
            PipeQuery(Context.Campaigns);
        }
    }
}