using Conte.Car.DataContracts;
using Conte.Car.Website.Cj.ConfigOptions;
using Conte.Car.Website.Cj.Contracts;
using Conte.Car.Website.Cj.Models;
using Conte.Components.Core.Instrumentation.Contracts;
using Conte.Components.Core.Instrumentation.Contracts.Enums;
using Microsoft.Extensions.Options;
using System;
using System.Diagnostics;


namespace Conte.Car.Website.Cj.Helper
{
    public sealed class ResponseHelper
    {
        public IConteSession ConteSession { get; private set; }        
        private readonly ILogger _logger;
        private  readonly AppConfigOptions _appConfigOptions;
        public ResponseHelper(ILogger logger, IConteSession userSession, IOptionsMonitor<AppConfigOptions> appOptions)
        {
            ConteSession = userSession ?? throw new ArgumentNullException(nameof(userSession));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _appConfigOptions = appOptions.CurrentValue ?? throw new ArgumentNullException(nameof(appOptions));
        }
        public object Response(bool status, Exception exception)
        {
            if (!status) _logger.Log(exception, exception.Message, 1, LogCategory.CodeLogic, DateTime.Now, TraceEventType.Error, ConteSession.SessionId); 
            return new
            {
                IsSuccess = status,
                Message = status ? "Success" : exception.Message
            };
        }
        public object Response(bool status,string url, Exception exception)
        {
            if (!status) _logger.Log(exception, exception.Message, 1, LogCategory.CodeLogic, DateTime.Now, TraceEventType.Error, ConteSession.SessionId);
            return new
            {
                IsSuccess = status,
                Url= url,
                Message = status ? "Success" : exception.Message
            };
        }
        public object Response(bool status, Exception exception,Guid ReQuoteReferenceId)
        {
            if (!status) _logger.Log(exception, exception.Message, 1, LogCategory.CodeLogic, DateTime.Now, TraceEventType.Error, ConteSession.SessionId);
            return new
            {
                IsSuccess = status,
                ReQuoteReferenceId = status ? ReQuoteReferenceId.ToString() : "",
                Message = status ? "Success" : exception.Message
            };
        }
        public object ConteData(AniaModel aniaModel, Exception exception, string plateNumber, string dateOfBirth)
        {
            if (!aniaModel.IsSuccess)
            {
                _logger.Log(exception, $"{exception.Message} , plateNumber - {plateNumber}, dateOfBirth - {dateOfBirth}", 1, LogCategory.CodeLogic, DateTime.Now, TraceEventType.Error, ConteSession.SessionId);

            }

            var longFlowUrl = string.Format(_appConfigOptions.longFlowUrl, System.Net.WebUtility.UrlEncode(dateOfBirth.Replace("-", "/")), plateNumber);
            if (!aniaModel.IsAniaEligible)
                longFlowUrl = longFlowUrl + "&campaignSource=FQ-NotEligible";
            else if (aniaModel.IsControlGroupEligible && aniaModel.IsAniaEligible)
                longFlowUrl = longFlowUrl + "&campaignSource=FQ-ControlGroup";

            return new
            {
                IsSuccess = aniaModel.IsSuccess,
                IsFastQuote = aniaModel.IsFastQuoteJourney,
                DataImmatricolazione = aniaModel.DataImmatricolazione,
                IsDataImmatricolazione = aniaModel.IsDataImmatricolazione,
                DataAcquisto = aniaModel.DataAcquisto,
                IsDataAcquisto = aniaModel.IsDataAcquisto,
                IsControlGroupEligible = aniaModel.IsControlGroupEligible,
                IsAniaEligible = aniaModel.IsAniaEligible,
                LongFlowUrl = longFlowUrl,
                Message = aniaModel.IsSuccess ? "Success" : exception.Message,
                IsError = aniaModel.IsError,
                ScadenzaPolizza=aniaModel.ScadenzaPolizza,
                EsitiSinistriEstrattiCount = aniaModel.EsitiSinistriEstrattiCount,
                IsCarValue= aniaModel.IsCarValue,
                CarValue=aniaModel.CarValue,
                IsMarca = aniaModel.IsMarca,
                Marca = aniaModel.Marca,
                MarcaCode = aniaModel.MarcaCode,
                IsModel = aniaModel.IsModel,
                Model = aniaModel.Model,
                ModelCode = aniaModel.ModelCode,
                IsVersion = aniaModel.IsVersion,
                Version = aniaModel.Version,
                VersionCode = aniaModel.VersionCode,
                FuelCode = aniaModel.FuelCode,
                RegistrationMonth = aniaModel.RegistrationMonth,
                RegistrationYear = aniaModel.RegistrationYear
            };
        }
        public string GetAniaUrl(string plateNumber,string dateOfBirth)
        {
            var dobArray = dateOfBirth.Split('-');
            var newDob = dobArray[2] + "-" + dobArray[1] + "-" + dobArray[0];

            var nqfUrl = string.Format(_appConfigOptions.nqfUrl, plateNumber, newDob);
            return nqfUrl;
        }
        public object AniaEligibilityData(AniaDataResponse aniaDataResponse, Exception exception, string plateNumber, string dateOfBirth)
        {
            if (!aniaDataResponse.IsSuccess)
            {
                _logger.Log(exception, $"{ exception.Message}, plateNumber - {plateNumber}, dateOfBirth - {dateOfBirth}", 1, LogCategory.CodeLogic, DateTime.Now, TraceEventType.Error, ConteSession.SessionId);

            }

            var longFlowUrl = string.Format(_appConfigOptions.longFlowUrl, System.Net.WebUtility.UrlEncode(dateOfBirth.Replace("-", "/")), plateNumber);
            if (!aniaDataResponse.IsAniaEligible)
                longFlowUrl = longFlowUrl + "&campaignSource=FQ-NotEligible";
            else if (aniaDataResponse.IsControlGroupEligible && aniaDataResponse.IsAniaEligible)
                longFlowUrl = longFlowUrl + "&campaignSource=FQ-ControlGroup";

            return new
            {
                IsSuccess = aniaDataResponse.IsSuccess,
                IsFastQuote = aniaDataResponse.IsFastQuoteJourney,
                DataImmatricolazione = aniaDataResponse.DataImmatricolazione,
                IsDataImmatricolazione = aniaDataResponse.IsDataImmatricolazione,
                DataAcquisto = aniaDataResponse.DataAcquisto,
                IsDataAcquisto = aniaDataResponse.IsDataAcquisto,
                IsControlGroupEligible = aniaDataResponse.IsControlGroupEligible,
                IsAniaEligible = aniaDataResponse.IsAniaEligible,
                LongFlowUrl = longFlowUrl,//string.Format(_config.GetValue<string>(AppSettingsKeys.LongFlowUrl), System.Net.WebUtility.UrlEncode(dateOfBirth.Replace("-", "/")), plateNumber),
                Message = aniaDataResponse.IsSuccess ? "Success" : exception.Message,                
                IsError = aniaDataResponse.IsError,
                ScadenzaPolizza = aniaDataResponse.ScadenzaPolizza

            };
        }
        public object InstantflowEligibilityData(InstantflowResponse instantflowResponse, Exception exception, string plateNumber, string dateOfBirth)
        {
            if (!instantflowResponse.IsSuccess)
            {
                _logger.Log(exception, $"{ exception.Message}, plateNumber - {plateNumber}, dateOfBirth - {dateOfBirth}", 1, LogCategory.CodeLogic, DateTime.Now, TraceEventType.Error, ConteSession.SessionId);

            } 
            return new
            {
                IsSuccess = instantflowResponse.IsSuccess,
                IsQuickFlowEligible = instantflowResponse.IsQuickFlowEligible,
                QuickFlowStatus = instantflowResponse.QuickFlowStatus,
                QuickFlowStatusCode = instantflowResponse.QuickFlowStatusCode,
                QuickFlowMessage = instantflowResponse.QuickFlowMessage,
                IsError = instantflowResponse.IsError,

            };
        }
        public object ConteDecisionData(QuickFlowDecisionData quickFlowDecisionData, Exception exception, string plateNumber, string dateOfBirth)
        {
            if (!quickFlowDecisionData.IsSuccess)
            {
                _logger.Log(exception, $"{ exception.Message}, plateNumber - {plateNumber}, dateOfBirth - {dateOfBirth}", 1, LogCategory.CodeLogic, DateTime.Now, TraceEventType.Error, ConteSession.SessionId);

            }

            var longFlowUrl = string.Format(_appConfigOptions.longFlowUrl, System.Net.WebUtility.UrlEncode(dateOfBirth.Replace("-", "/")), plateNumber);
            if (!quickFlowDecisionData.IsAniaEligible)
                longFlowUrl = longFlowUrl + "&campaignSource=FQ-NotEligible";
            else if (quickFlowDecisionData.IsControlGroupEligible && quickFlowDecisionData.IsAniaEligible)
                longFlowUrl = longFlowUrl + "&campaignSource=FQ-ControlGroup";

            var dobArray = dateOfBirth.Split('-');
            var newDob = dobArray[2] + "-" + dobArray[1] + "-" + dobArray[0];

            var nqfUrl = string.Format(_appConfigOptions.nqfUrl, plateNumber, newDob);

            return new
            {
                IsSuccess = quickFlowDecisionData.IsSuccess,
                IsFastQuote = quickFlowDecisionData.IsFastQuoteJourney,
                DataImmatricolazione = quickFlowDecisionData.DataImmatricolazione,
                IsDataImmatricolazione = quickFlowDecisionData.IsDataImmatricolazione,
                DataAcquisto = quickFlowDecisionData.DataAcquisto,
                IsDataAcquisto = quickFlowDecisionData.IsDataAcquisto,
                IsControlGroupEligible = quickFlowDecisionData.IsControlGroupEligible,
                IsAniaEligible = quickFlowDecisionData.IsAniaEligible,
                LongFlowUrl = longFlowUrl,//string.Format(_config.GetValue<string>(AppSettingsKeys.LongFlowUrl), System.Net.WebUtility.UrlEncode(dateOfBirth.Replace("-", "/")), plateNumber),
                Message = quickFlowDecisionData.IsSuccess ? "Success" : exception.Message,
                IsQuickFlowEligible = quickFlowDecisionData.IsQuickFlowEligible,
                QuickFlowStatus = quickFlowDecisionData.QuickFlowStatus,
                QuickFlowStatusCode = quickFlowDecisionData.QuickFlowStatusCode,
                QuickFlowMessage = quickFlowDecisionData.QuickFlowMessage,
                IsError = quickFlowDecisionData.IsError,
                ScadenzaPolizza = quickFlowDecisionData.ScadenzaPolizza,
                EsitiSinistriEstrattiCount = quickFlowDecisionData.EsitiSinistriEstrattiCount,
                IsCarValue = quickFlowDecisionData.IsCarValue,
                CarValue = quickFlowDecisionData.CarValue,
                IsMarca = quickFlowDecisionData.IsMarca,
                Marca = quickFlowDecisionData.Marca,
                MarcaCode = quickFlowDecisionData.MarcaCode,
                IsModel = quickFlowDecisionData.IsModel,
                Model= quickFlowDecisionData.Model,
                ModelCode = quickFlowDecisionData.ModelCode,
                IsVersion = quickFlowDecisionData.IsVersion,
                Version= quickFlowDecisionData.Version,
                VersionCode = quickFlowDecisionData.VersionCode,
                FuelCode = quickFlowDecisionData.FuelCode,
                RegistrationMonth = quickFlowDecisionData.RegistrationMonth,
                RegistrationYear = quickFlowDecisionData.RegistrationYear,
                NqfUrl=nqfUrl
            };
        }
        public object CreateDecisionDataDefault(string plateNumber, string dateOfBirth)
        {
            var longFlowUrl = string.Format(_appConfigOptions.longFlowUrl, System.Net.WebUtility.UrlEncode(dateOfBirth.Replace("-", "/")), plateNumber);
            //if (!quickFlowDecisionData.IsAniaEligible)
            //    longFlowUrl = longFlowUrl + "&campaignSource=FQ-NotEligible";
            //else if (quickFlowDecisionData.IsControlGroupEligible && quickFlowDecisionData.IsAniaEligible)
            //    longFlowUrl = longFlowUrl + "&campaignSource=FQ-ControlGroup";

            var dobArray = dateOfBirth.Split('-');
            var newDob = dobArray[2] + "-" + dobArray[1] + "-" + dobArray[0];

            var nqfUrl = string.Format(_appConfigOptions.nqfUrl, plateNumber, newDob);
            return new 
            {
                nqfUrl = nqfUrl,
                LongFlowUrl = longFlowUrl,
                IsSuccess = false,
                IsFastQuoteJourney = false,
                IsDataImmatricolazione = false,
                IsDataAcquisto = false,
                DataImmatricolazione = string.Empty,
                DataAcquisto = string.Empty,
                IsControlGroupEligible = false,
                IsAniaEligible = false,
                IsQuickFlowEligible = false,
                QuickFlowStatus = "KO",
                QuickFlowStatusCode = "500",
                QuickFlowMessage = "",
                IsError = true,
                ScadenzaPolizza = "",
                EsitiSinistriEstrattiCount = 0,
                IsCarValue = false,
                CarValue = 0,
                IsMarca = false,
                Marca = "",
                MarcaCode = "",
                IsModel = false,
                Model = "",
                ModelCode = "",
                IsVersion = false,
                Version = "",
                VersionCode = ""

            };
        }
        public QuickFlowDecisionData CreateDecisionDataDefault()
        {
            return new QuickFlowDecisionData()
            {
                IsSuccess = false,
                IsFastQuoteJourney = false,
                IsDataImmatricolazione = false,
                IsDataAcquisto = false,
                DataImmatricolazione = string.Empty,
                DataAcquisto = string.Empty,
                IsControlGroupEligible = false,
                IsAniaEligible = false,
                IsQuickFlowEligible = false,
                QuickFlowStatus = "KO",
                QuickFlowStatusCode = "500",
                QuickFlowMessage = "",
                IsError = true,
                ScadenzaPolizza = "",
                EsitiSinistriEstrattiCount=0,
                IsCarValue = false,
                CarValue = 0,
                IsMarca = false,
                Marca = "",
                MarcaCode = "",
                IsModel = false,
                Model = "",
                ModelCode = "",
                IsVersion = false,
                Version = "",
                VersionCode = ""
               
            };
        }
        public AniaDataResponse CreateAniaEligibilityDataDefault()
        {
            return new AniaDataResponse()
            {
                IsSuccess = false,
                IsFastQuoteJourney = false,
                IsDataImmatricolazione = false,
                IsDataAcquisto = false,
                DataImmatricolazione = string.Empty,
                DataAcquisto = string.Empty,
                IsControlGroupEligible = false,
                IsAniaEligible = false,                
                IsError = true,
                ScadenzaPolizza = ""
            };
        }
        public InstantflowResponse CreateInstantflowEligibilityDataDefault()
        {
            return new InstantflowResponse()
            {
                IsSuccess = false,
                IsQuickFlowEligible = false,
                QuickFlowStatus = "KO",
                QuickFlowStatusCode = "500",
                QuickFlowMessage = "",
                IsError = true
            };
        }
        public AniaModel CreateAniaModelDefault()
        {
            return new AniaModel()
            {
                IsSuccess = false,
                IsFastQuoteJourney = false,
                IsDataImmatricolazione = false,
                IsDataAcquisto = false,
                DataImmatricolazione = string.Empty,
                DataAcquisto = string.Empty,
                IsControlGroupEligible = false,
                IsAniaEligible = false,
                IsError = true,
                EsitiSinistriEstrattiCount=0,
                IsCarValue = false,
                CarValue = 0,
                IsMarca = false,
                Marca = "",
                IsModel = false,
                Model = "",
                IsVersion = false,
                Version = ""
            };
        }
    }
}
