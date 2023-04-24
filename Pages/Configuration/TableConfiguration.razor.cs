using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Services.Configuration;
using HorizonPollyC.Services.General;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;
using System.Collections.Generic;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class TableConfiguration
    {
        List<TableConfigurationVM> tableConfigurationView = null;
        List<TableConfigurationVM> tableConfigurationAllow = null;
        List<TableConfigurationVM> tableConfigurationConfig = null;

        public string screenName { get; set; }

        protected override async Task OnInitializedAsync()
        {

            tableConfigurationView = new List<TableConfigurationVM>();

            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "BenefitAges", DisplayName = "Benefit Ages", Schema = "allow" });
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "BenefitOptions", DisplayName = "Benefit Options", Schema = "allow" });
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "BenefitPackages", DisplayName = "Benefit Packages", Schema = "allow" });
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "Account", DisplayName = "Account", Schema = "config" });
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "BenefitPlanAncills", DisplayName ="Benefit Plan Ancills" ,Schema="allow"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "BenefitPlanCovers", DisplayName ="Benefit Plan Covers" ,Schema="allow"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "BenefitPlanIncrs", DisplayName ="Benefit Plan Increase" ,Schema="allow"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "BenefitPlans", DisplayName ="Benefit Plans" ,Schema="allow"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "BenefitPremFreqs", DisplayName ="Benefit Premium Frequency" ,Schema="allow"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "ChannelBenTypes", DisplayName ="Channel Benefit Types" ,Schema="allow"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "PremPortion", DisplayName ="Premium Portion" ,Schema="allow"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "ProductBenefits", DisplayName ="Product Benefits" ,Schema="allow"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "SchemePlanFactors", DisplayName ="Scheme Plan Factors" ,Schema="allow"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "StatusReasons", DisplayName ="Status Reasons" ,Schema="allow"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "AncillType", DisplayName ="Ancill Type" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "AnnIncFactors", DisplayName ="Annual Increase Factors" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "Attribute", DisplayName ="Attribute" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "BenefitOption", DisplayName ="Benefit Option" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "BenefitPackage", DisplayName ="Benefit Package" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "BenefitType", DisplayName ="Benefit Type" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "BillPeriod", DisplayName ="Billing Period" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "BordereauxSource", DisplayName ="Bordereaux Source" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "Channel", DisplayName ="Channel" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "Cover", DisplayName ="Cover" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "DataArtefact", DisplayName ="Data Artefact" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "Discount", DisplayName ="Discount" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "DiscountType", DisplayName ="Discount Type" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "EntityType", DisplayName ="Entity Type" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "EntryAge", DisplayName ="Entry Age" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "Error", DisplayName ="Error" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "EventField", DisplayName ="Event Field" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "EventHeader", DisplayName ="Event Header" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "EventSubscriber", DisplayName ="Event Subscriber" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "EventSubscription", DisplayName ="Event Subscription" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "EventType", DisplayName ="Event Type" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "ExpiryAge", DisplayName ="Expiry Age" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "Gender", DisplayName ="Gender" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "Language", DisplayName ="Language" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "LegacyPayment", DisplayName ="Legacy Payment" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "Level", DisplayName ="Level" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "Loading", DisplayName ="Loading" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "LoadingType", DisplayName ="Loading Type" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "Movement", DisplayName ="Movement" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "Partner", DisplayName ="Partner" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "PaymentFreq", DisplayName ="Payment Frequency" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "PlanOption", DisplayName ="Plan Option" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "PlanType", DisplayName ="Plan Type" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "PortionControl", DisplayName ="Portion Control" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "PortionOptionLink", DisplayName ="Portion Option Link" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "PremPortionType", DisplayName ="Premium Portion Type" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "PremiumType", DisplayName ="Premium Type" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "Process", DisplayName ="Process" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "ProductLine", DisplayName ="Product Line" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "Reason", DisplayName ="Reason" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "ReinsDuration", DisplayName ="Reinsurance Duration" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "ReinsMemberType", DisplayName ="Reinsurance Member Type" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "Role", DisplayName ="Role" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "Scheme", DisplayName ="Scheme" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "SchemeLoadlink", DisplayName ="Scheme Load link" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "SchemeBackup", DisplayName ="Scheme Backup" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "Smoker", DisplayName ="Smoker" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "Status", DisplayName ="Status" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "SubscriptionType", DisplayName ="Subscription Type" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "Table", DisplayName ="Table" ,Schema="allow"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "TakeOnOption", DisplayName ="Take On Option" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "Tier", DisplayName ="Tier" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "Titles", DisplayName ="Titles" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "TransCategory", DisplayName ="Transaction Category" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "TransType", DisplayName ="Transaction Type" ,Schema="allow"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "TransactionType", DisplayName ="Transaction Type" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "Translate", DisplayName ="Translate" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "UnitTypes", DisplayName ="Unit Types" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "ValidateStructure", DisplayName ="Validate Structure" ,Schema="allow"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "WaitingPeriod", DisplayName ="Waiting Period" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "YesNo", DisplayName ="Yes No" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "FileImportPath", DisplayName ="File Import Path" ,Schema="config"});
            tableConfigurationView.Add(new TableConfigurationVM() { ScreenName = "PortionOptionLink", DisplayName ="Portion Option Link" ,Schema="config"});

            tableConfigurationAllow = tableConfigurationView.Where(x => x.Schema == "allow").ToList();
            tableConfigurationConfig = tableConfigurationView.Where(x => x.Schema == "config").ToList();
        }

        public void showspecificScreen()
        {

            tableConfigurationAllow = tableConfigurationView.Where(x => x.Schema == "allow" && x.DisplayName.Contains(screenName, StringComparison.OrdinalIgnoreCase)).ToList();
            tableConfigurationConfig = tableConfigurationView.Where(x => x.Schema == "config" && x.DisplayName.Contains(screenName, StringComparison.OrdinalIgnoreCase)).ToList();

        }

    }
}

