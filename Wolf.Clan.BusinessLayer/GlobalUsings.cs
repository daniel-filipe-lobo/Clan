global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;

global using System.Globalization;
global using System.Net.Http.Headers;
global using System.Runtime.Serialization;
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using System.Web;

global using Wolf.Clan.BusinessLayer.Models;
global using Wolf.Clan.BusinessLayer.Models.Api;
global using Wolf.Clan.BusinessLayer.Rules;
global using Wolf.Clan.DataLayer;
global using Wolf.Utilities;

global using ExceptionHandler = Wolf.Utilities.ExceptionHandler<Wolf.Clan.BusinessLayer.ExceptionRulesFactory>;
