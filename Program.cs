
using Blazored.LocalStorage;
using HorizonPollyC;
using HorizonPollyC.Components;
using HorizonPollyC.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using HorizonPollyC.Services.Authentication;
using HorizonPollyC.Services.UserManagement;
//using HorizonPollyC.Services.General;
using HorizonPollyC.Services.Configuration;
using HorizonPollyC.Shared;
using HorizonPollyC.Services.General;
using HorizonPollyC.Models.Configuration;
using Radzen;
using HorizonPollyC.Services.Chat;
using HorizonPollyC.Services.Financial;
using HorizonPollyC.Services.SCV;
using Microsoft.AspNetCore.Builder;

namespace HorizonPollyC
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5153/Horizon.UI/") });

            builder.Services.AddAuthorizationCore();



            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IAncilTypeService, AncilTypeService>();
            builder.Services.AddScoped<IAnnIncFactorService, AnnIncFactorService>();
            builder.Services.AddScoped<IAttributeService, AttributeService>();
            builder.Services.AddScoped<IBenefitOptionService, BenefitOptionService>();
            builder.Services.AddScoped<IBenefitPackageServices, BenefitPackageService>();
            builder.Services.AddScoped<IBenefitTypeService, BenefitTypeService>();
            builder.Services.AddScoped<IBillPeriodService, BillPeriodService>();
            builder.Services.AddScoped<IBordereauxSourceService, BordereauxSourceService>();
            builder.Services.AddScoped<IChannelService, ChannelService>();
            builder.Services.AddScoped<ICoverService, CoverService>();
            builder.Services.AddScoped<IDataArtefactService, DataArtefactService>();
            builder.Services.AddScoped<IDiscountService, DiscountService>();
            builder.Services.AddScoped<IDiscountTypeService, DiscountTypeService>();
            builder.Services.AddScoped<IEntityTypeService, EntityTypeService>();
            builder.Services.AddScoped<IEntryAgeService, EntryAgeService>();
            builder.Services.AddScoped<IErrorService, ErrorService>();
            builder.Services.AddScoped<IEventFieldService, EventFieldService>();
            builder.Services.AddScoped<IEventHeaderService, EventHeaderService>();
            builder.Services.AddScoped<IEventSubscriberService, EventSubscriberService>();
            builder.Services.AddScoped<IEventSubscriptionService, EventSubscriptionService>();
            builder.Services.AddScoped<IEventTypeService, EventTypeService>();
            builder.Services.AddScoped<IExpiryAgeService, ExpiryAgeService>();
            builder.Services.AddScoped<IGenderService, GenderService>();
            builder.Services.AddScoped<IExportService, ExportService>();
            builder.Services.AddScoped<ILanguageService, LanguageService>();
            builder.Services.AddScoped<ILegacyPaymentService, LegacyPaymentService>();
            builder.Services.AddScoped<ILevelService, LevelService>();
            builder.Services.AddScoped<ILoadingService, LoadingService>();
            builder.Services.AddScoped<ILoadingTypeService, LoadingTypeService>();
            builder.Services.AddScoped<IMovementService, MovementService>();
            builder.Services.AddScoped<IPartnerService, PartnerService>();
            builder.Services.AddScoped<IPaymentFrequencyService, PaymentFrequencyService>();
            builder.Services.AddScoped<IPlanOptionService, PlanOptionService>();
            builder.Services.AddScoped<IPlanTypeService, PlanTypeService>();
            builder.Services.AddScoped<IPortionControlService, PortionControlService>();
            builder.Services.AddScoped<IPortionOptionService, PortionOptionService>();
            builder.Services.AddScoped<IPremiumPortionService, PremiumPortionService>();
            builder.Services.AddScoped<ISCVService, SCVService>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddScoped<IUserManagementService, UserManagementService>();
            builder.Services.AddScoped<IBenefitAgesService, BenefitAgesService>();
            builder.Services.AddScoped<IBenefitOptionsService, BenefitOptionsService>();
            builder.Services.AddScoped<IBenefitPackagesService, BenefitPackagesService>();
            builder.Services.AddScoped<IBenefitPlanAncillsService, BenefitPlanAncillsService>();
            builder.Services.AddScoped<IBenefitPlanIncrsService, BenefitPlanIncrsService>();
            builder.Services.AddScoped<IBenefitPlansService, BenefitPlansService>();
            builder.Services.AddScoped<IBenefitPremFreqsService, BenefitPremFreqsService>();
            builder.Services.AddScoped<IChannelBenTypesService, ChannelBenTypesService>();
            builder.Services.AddScoped<IPremPortionService, PremPortionService>();
            builder.Services.AddScoped<IProductBenefitsService, ProductBenefitsService>();
            builder.Services.AddScoped<ISchemePlanFactorsService, SchemePlanFactorsService>();
            builder.Services.AddScoped<IStatusReasonsService, StatusReasonsService>();
            builder.Services.AddScoped<ITableService, TableService>();
            builder.Services.AddScoped<ITransTypeService, TransTypeService>();
            builder.Services.AddScoped<IValidateStructureService, ValidateStructureService>();
            //builder.Services.AddScoped<ITableConfigurationService, TableConfigurationService>();
            builder.Services.AddScoped<IYesNoService, YesNoService>();
            builder.Services.AddScoped<IFinancialService, FinancialService>();
            builder.Services.AddScoped<IQuotesService, QuotesService>();

            builder.Services.AddScoped<IBenefitPackagesService, BenefitPackagesService>();
            builder.Services.AddScoped<IValidateStructureService, ValidateStructureService>();
            builder.Services.AddScoped<ITransTypeService, TransTypeService>();
            builder.Services.AddScoped(typeof(IGeneric<WaitingPeriodsVM>), typeof(WaitingPeriodService));
            builder.Services.AddScoped(typeof(IGeneric<UnitTypesVM>), typeof(UnitTypeService));
            builder.Services.AddScoped(typeof(IGeneric<TransTypeVM>), typeof(TransactionTypeService));
            builder.Services.AddScoped(typeof(IGeneric<TranslateVM>), typeof(TranslateService));
            builder.Services.AddScoped(typeof(IGeneric<TransactionTypesVM>), typeof(TransactionTypeService));
            builder.Services.AddScoped(typeof(IGeneric<TransactionCategoriesVM>), typeof(TransCategoryService));
            builder.Services.AddScoped(typeof(IGeneric<TitlesVM>), typeof(TitlesService));
            builder.Services.AddScoped(typeof(IGeneric<TierVM>), typeof(TierSerice));
            builder.Services.AddScoped(typeof(IGeneric<TakeOnOptionVM>), typeof(TakeonOptionService));
            builder.Services.AddScoped(typeof(IGeneric<SubscriptionTypeVM>), typeof(SubscriptionTypeService));
            builder.Services.AddScoped(typeof(IGeneric<StatusReasonsVM>), typeof(StatusReasonsService));
            builder.Services.AddScoped(typeof(IGeneric<ScheneLoadLinkVM>), typeof(SchemeLoadLinkService));
            builder.Services.AddScoped(typeof(IGeneric<RoleVM>), typeof(RoleService));
            builder.Services.AddScoped(typeof(IGeneric<ReinsuranceMemberTypeVM>), typeof(ReinsMemberTypeService));
            builder.Services.AddScoped(typeof(IGeneric<ReinsuranceDurationVM>), typeof(ReinsuranceDurationService));
            builder.Services.AddScoped(typeof(IGeneric<ReasonVM>), typeof(ReasonService));
            builder.Services.AddScoped(typeof(IGeneric<ProductLineVM>), typeof(ProductLineServices));
            builder.Services.AddScoped(typeof(IGeneric<ProcessVM>), typeof(ProcessService));
            builder.Services.AddScoped(typeof(IGeneric<PremiumTypeVM>), typeof(PremiumTypeService));
            builder.Services.AddScoped(typeof(IGeneric<StatusVM>), typeof(StatusService));
            builder.Services.AddScoped(typeof(IGeneric<SmokerVM>), typeof(SmokerService));
            builder.Services.AddScoped(typeof(IGeneric<SchemeVM>), typeof(SchemeService));
            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<TooltipService>();

            builder.Services.AddScoped<NotificationService>();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddSingleton<TimerService>();
            builder.Services.AddTransient<CustomAuthorizationHandler>();

            builder.Services.AddSingleton<GlobalVariables>();
            //builder.Services.AddCors(cors => cors.AddPolicy("AllowAll",
            //    policy => {
            //        policy.AllowAnyMethod()
            //                .AllowAnyHeader()
            //                .AllowAnyOrigin()
            //                .SetIsOriginAllowed(origin => true)
            //                .AllowCredentials();
            //    }
            //)); 

            AddHttpClients(builder);

            var host = builder.Build();


            await host.RunAsync();
        }
        public static void AddHttpClients(WebAssemblyHostBuilder builder)
        {
            //transactional named http clients
            builder.Services.AddHttpClient<ISCVService, SCVService>("SCVService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IUserManagementService, UserManagementService>("UserManagementService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IAccountService, AccountService>("AccountService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IQuotesService, QuotesService>("QuotesService").AddHttpMessageHandler<CustomAuthorizationHandler>();

            builder.Services.AddHttpClient<IAccountService, AccountService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IAncilTypeService, AncilTypeService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IAnnIncFactorService, AnnIncFactorService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IAttributeService, AttributeService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IBenefitOptionService, BenefitOptionService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IBenefitPackageServices, BenefitPackageService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IBenefitTypeService, BenefitTypeService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IBillPeriodService, BillPeriodService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IBordereauxSourceService, BordereauxSourceService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IChannelService, ChannelService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<ICoverService, CoverService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IDataArtefactService, DataArtefactService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IDiscountService, DiscountService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IDiscountTypeService, DiscountTypeService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IEntityTypeService, EntityTypeService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IEntryAgeService, EntryAgeService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IErrorService, ErrorService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IEventFieldService, EventFieldService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IEventHeaderService, EventHeaderService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IEventSubscriberService, EventSubscriberService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IEventSubscriptionService, EventSubscriptionService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IEventTypeService, EventTypeService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IExpiryAgeService, ExpiryAgeService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IGenderService, GenderService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IExportService, ExportService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<ILanguageService, LanguageService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<ILegacyPaymentService, LegacyPaymentService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<ILevelService, LevelService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<ILoadingService, LoadingService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<ILoadingTypeService, LoadingTypeService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IMovementService, MovementService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IPartnerService, PartnerService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IPaymentFrequencyService, PaymentFrequencyService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IPlanOptionService, PlanOptionService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IPlanTypeService, PlanTypeService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IPortionControlService, PortionControlService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IPortionOptionService, PortionOptionService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IPremiumPortionService, PremiumPortionService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<ISCVService, SCVService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IAuthenticationService, AuthenticationService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IUserManagementService, UserManagementService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IBenefitAgesService, BenefitAgesService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IBenefitPackagesService, BenefitPackagesService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IBenefitOptionsService, BenefitOptionsService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IBenefitPlanAncillsService, BenefitPlanAncillsService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IBenefitPlanCoversService, BenefitPlanCoversService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IBenefitPlanIncrsService, BenefitPlanIncrsService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IBenefitPlansService, BenefitPlansService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IChannelBenTypesService, ChannelBenTypesService>("ConfigurationService").AddHttpMessageHandler<CustomAuthorizationHandler>();

            builder.Services.AddHttpClient<IGeneric<WaitingPeriodsVM>, WaitingPeriodService>("GenericService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IGeneric<UnitTypesVM>, UnitTypeService>("GenericService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IGeneric<TranslateVM>, TranslateService>("GenericService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IGeneric<TransactionCategoriesVM>, TransCategoryService>("GenericService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IGeneric<TitlesVM>, TitlesService>("GenericService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IGeneric<TelecomType>, TelecomTypesService>("GenericService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IGeneric<CountryPhone>, CountryPhoneService>("GenericService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IGeneric<TierVM>, TierSerice>("GenericService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IGeneric<TakeOnOptionVM>, TakeonOptionService>("GenericService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IGeneric<SubscriptionTypeVM>, SubscriptionTypeService>("GenericService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IGeneric<ScheneLoadLinkVM>, SchemeLoadLinkService>("GenericService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IGeneric<ReinsuranceMemberTypeVM>, ReinsMemberTypeService>("GenericService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IGeneric<RoleVM>, RoleService>("GenericService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IGeneric<ReinsuranceDurationVM>, ReinsuranceDurationService>("GenericService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IGeneric<ReasonVM>, ReasonService>("GenericService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IGeneric<ProductLineVM>, ProductLineServices>("GenericService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IGeneric<ProcessVM>, ProcessService>("GenericService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IGeneric<PremiumTypeVM>, PremiumTypeService>("GenericService").AddHttpMessageHandler<CustomAuthorizationHandler>();
            builder.Services.AddHttpClient<IGeneric<SmokerVM>, SmokerService>("GenericService").AddHttpMessageHandler<CustomAuthorizationHandler>();
        }


    }
}