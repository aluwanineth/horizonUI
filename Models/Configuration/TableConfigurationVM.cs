//using DocumentFormat.OpenXml.CustomXmlSchemaReferences;

namespace HorizonPollyC.Models.Configuration
{
    public class TableConfigurationVM
    {
        public string ScreenName { get; set; }

        public string DisplayName { get; set; }

        public string Schema { get; set; }

        //public List<TableConfigurationVM> tableConfigurationVMs = new List<TableConfigurationVM>
        //{
        //    new TableConfigurationVM() { ScreenName="BenefitAges", DisplayName ="Benefit Ages" ,Schema="allow"},
        //    new TableConfigurationVM() { ScreenName="BenefitOptions", DisplayName ="Benefit Options" ,Schema="allow"},
        //    new TableConfigurationVM() { ScreenName="BenefitPackages", DisplayName ="Benefit Packages" ,Schema="allow"},
        //    new TableConfigurationVM() { ScreenName="BenefitPlanAncills", DisplayName ="Benefit Plan Ancills" ,Schema="allow"},
        //    new TableConfigurationVM() { ScreenName="BenefitPlanCovers", DisplayName ="Benefit Plan Covers" ,Schema="allow"},
        //    new TableConfigurationVM() { ScreenName="BenefitPlanIncrs", DisplayName ="Benefit Plan Increase" ,Schema="allow"},
        //    new TableConfigurationVM() { ScreenName="BenefitPlans", DisplayName ="Benefit Plans" ,Schema="allow"},
        //    new TableConfigurationVM() { ScreenName="BenefitPremFreqs", DisplayName ="Benefit Prememium Frequency" ,Schema="allow"},
        //    new TableConfigurationVM() { ScreenName="ChannelBenTypes", DisplayName ="Channel Benefit Types" ,Schema="allow"},
        //    new TableConfigurationVM() { ScreenName="PremPortion", DisplayName ="Premium Portion" ,Schema="allow"},
        //    new TableConfigurationVM() { ScreenName="ProductBenefits", DisplayName ="Product Benefits" ,Schema="allow"},
        //    new TableConfigurationVM() { ScreenName="SchemePlanFactors", DisplayName ="Scheme Plan Factors" ,Schema="allow"},
        //    new TableConfigurationVM() { ScreenName="StatusReasons", DisplayName ="Status Reasons" ,Schema="allow"},
        //    new TableConfigurationVM() { ScreenName="Account", DisplayName ="Account" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="AncillType", DisplayName ="Ancill Type" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="AnnIncFactors", DisplayName ="Annual Increase Factors" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="Attribute", DisplayName ="Attribute" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="BenefitOption", DisplayName ="Benefit Option" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="BenefitPackage", DisplayName ="Benefit Package" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="BenefitType", DisplayName ="Benefit Type" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="BillPeriod", DisplayName ="Billing Period" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="BordereauxSource", DisplayName ="Bordereaux Source" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="Channel", DisplayName ="Channel" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="Cover", DisplayName ="Cover" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="DataArtefact", DisplayName ="Data Artefact" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="Discount", DisplayName ="Discount" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="DiscountType", DisplayName ="Discount Type" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="EntityType", DisplayName ="Entity Type" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="EntryAge", DisplayName ="Entry Age" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="Error", DisplayName ="Error" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="EventField", DisplayName ="Event Field" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="EventHeader", DisplayName ="Event Header" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="EventSubscriber", DisplayName ="Event Subscriber" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="EventSubscription", DisplayName ="Event Subscription" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="EventType", DisplayName ="Event Type" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="ExpiryAge", DisplayName ="Expiry Age" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="Gender", DisplayName ="Gender" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="Language", DisplayName ="Language" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="LegacyPayment", DisplayName ="Legacy Payment" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="Level", DisplayName ="Level" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="Loading", DisplayName ="Loading" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="LoadingType", DisplayName ="Loading Type" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="Movement", DisplayName ="Movement" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="NBCutoff", DisplayName ="NB Cutoff" ,Schema="allow"},
        //    new TableConfigurationVM() { ScreenName="Partner", DisplayName ="Partner" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="PaymentFreq", DisplayName ="Payment Frequency" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="PlanOption", DisplayName ="Plan Option" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="PlanType", DisplayName ="Plan Type" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="PortionControl", DisplayName ="Portion Control" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="PortionOptionLink", DisplayName ="Portion Option Link" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="PremPortionType", DisplayName ="Premium Portion Type" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="PremiumType", DisplayName ="Premium Type" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="Process", DisplayName ="Process" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="ProductLine", DisplayName ="Product Line" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="Reason", DisplayName ="Reason" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="ReinsDuration", DisplayName ="Reinsurance Duration" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="ReinsMemberType", DisplayName ="Reinsurance Member Type" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="Role", DisplayName ="Role" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="Scheme", DisplayName ="Scheme" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="SchemeLoadlink", DisplayName ="Scheme Load link" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="SchemeBackup", DisplayName ="Scheme Backup" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="Smoker", DisplayName ="Smoker" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="Status", DisplayName ="Status" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="SubscriptionType", DisplayName ="Subscription Type" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="Table", DisplayName ="Table" ,Schema="allow"},
        //    new TableConfigurationVM() { ScreenName="TakeOnOption", DisplayName ="Take On Option" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="Tier", DisplayName ="Tier" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="Titles", DisplayName ="Titles" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="TransCategory", DisplayName ="Transaction Category" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="TransType", DisplayName ="Transaction Type" ,Schema="allow"},
        //    new TableConfigurationVM() { ScreenName="TransactionType", DisplayName ="Transaction Type" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="Translate", DisplayName ="Translate" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="UnitTypes", DisplayName ="Unit Types" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="ValidateStructure", DisplayName ="Validate Structure" ,Schema="allow"},
        //    new TableConfigurationVM() { ScreenName="WaitingPeriod", DisplayName ="Waiting Period" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="YesNo", DisplayName ="Yes No" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="ileImportPath", DisplayName ="File Import Path" ,Schema="config"},
        //    new TableConfigurationVM() { ScreenName="PortionOptionLink", DisplayName ="Portion Option Link" ,Schema="config"},
        //};

    }


}
