using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
#if !DNXCORE50
using System.Threading;
#endif

namespace Breeze.ContextProvider
{
    public class BreezeConfig
    {

        public static BreezeConfig Instance
        {
            get
            {
                lock (__lock)
                {
#if DNX451
                    // WB THIS isn't going to work in CORE the way that it will in normal DotNet because
                    // core lacks the AppDomain and there is no assembly probing as far as I know.
                    // At lease in short run can set BreezeConfig.ProbeAssemblies in the StartUp.cs

                    // TODO: Ask Jay why the handler is added here and not inside the `if` block
                    // I added the next line because, w/o it, every call to Instance adds another handler!
                    AppDomain.CurrentDomain.AssemblyLoad -= CurrentDomain_AssemblyLoad; 
                    AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;
#endif               
                    if (__instance == null)
                    {
                        var typeCandidates = ProbeAssemblies.SelectMany(a => GetTypes(a));
                        var types = typeCandidates.Where(t => typeof(BreezeConfig).IsAssignableFrom(t) && !t.GetTypeInfo().IsAbstract).ToList();

                        if (types.Count == 0)
                        {
                            __instance = new BreezeConfig();
                        }
                        else if (types.Count == 1)
                        {
                            __instance = (BreezeConfig)Activator.CreateInstance(types[0]);
                        }
                        else
                        {
                            throw new Exception(
                              "More than one BreezeConfig implementation was found in the currently loaded assemblies - limit is one.");
                        }
                    }
                    return __instance;
                }
            }

        }
        public JsonSerializerSettings GetJsonSerializerSettings()
        {
            lock (__lock)
            {
                if (_jsonSerializerSettings == null)
                {
                    _jsonSerializerSettings = CreateJsonSerializerSettings();
                }
                return _jsonSerializerSettings;
            }
        }


        /// <summary>
        /// Returns TransactionSettings.Default.  Override to return different settings.
        /// </summary>
        /// <returns></returns>
        public virtual TransactionSettings GetTransactionSettings()
        {
            return TransactionSettings.Default;
        }

        private static object __lock = new object();
        private static BreezeConfig __instance;

        private JsonSerializerSettings _jsonSerializerSettings = null;

        /// <summary>
        /// Override to use a specialized JsonSerializer implementation.
        /// </summary>
        protected virtual JsonSerializerSettings CreateJsonSerializerSettings()
        {

            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Include,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                TypeNameHandling = TypeNameHandling.Objects,
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
            };

            // Default is DateTimeZoneHandling.RoundtripKind - you can change that here.
            // jsonSerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;

            // Hack is for the issue described in this post:
            // http://stackoverflow.com/questions/11789114/internet-explorer-json-net-javascript-date-and-milliseconds-issue
            jsonSerializerSettings.Converters.Add(new IsoDateTimeConverter
            {
                DateTimeFormat = "yyyy-MM-dd\\THH:mm:ss.fffK"
                // DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK"
            });
            // Needed because JSON.NET does not natively support I8601 Duration formats for TimeSpan
            jsonSerializerSettings.Converters.Add(new TimeSpanConverter());
            jsonSerializerSettings.Converters.Add(new StringEnumConverter());
            return jsonSerializerSettings;
        }

        protected static IEnumerable<Type> GetTypes(Assembly assembly)
        {

            try
            {
                return assembly.GetTypes();
            }
            catch (Exception ex)
            {
                string msg = string.Empty;
                if (ex is ReflectionTypeLoadException)
                {
                    msg = ((ReflectionTypeLoadException)ex).LoaderExceptions.ToAggregateString(". ");
                }
                Trace.WriteLine("Breeze probing: Unable to execute Assembly.GetTypes() for "
                  + assembly.ToString() + "." + msg);

                return new Type[] { };
            }
        }

        public static bool IsFrameworkAssembly(Assembly assembly)
        {
            var fullName = assembly.FullName;
            if (fullName.StartsWith("Microsoft.")) return true;
            if (fullName.StartsWith("EntityFramework")) return true;
            if (fullName.StartsWith("NHibernate")) return true;
            var productAttr = assembly.CustomAttributes.FirstOrDefault(att => att.AttributeType == typeof(AssemblyProductAttribute));
            if (productAttr == null)
            {
                return false;
            }
            var productName = productAttr.NamedArguments.First(arg => arg.MemberName == "Product").TypedValue.Value.ToString();
            return FrameworkProductNames.Any(nm => productName.StartsWith(nm));
        }



        protected static readonly List<string> FrameworkProductNames = new List<string> {
          "Microsoft®",
          "Microsoft (R)",
          "Microsoft ASP.",
          "System.Net.Http",
          "Json.NET",
          "Antlr3.Runtime",
          "Iesi.Collections",
          "WebGrease",
          "Breeze.ContextProvider"
        };

        private static ReadOnlyCollection<Assembly> __probeAssemblies = new ReadOnlyCollection<Assembly>(new List<Assembly>());

#if DNXCORE50
        // Can't probe for assemblies in CORE
        // Make it possible to register the assemblies in StartUp.cs
        // by preparing a list of them there and then
        //     BreezeConfig.ProbeAssemblies = theProbeAssemblyCollection;
        public static ReadOnlyCollection<Assembly> ProbeAssemblies
        {
            get
            {
                lock (__lock)
                {
                    return __probeAssemblies;
                }
            }
            set
            {
                lock (__lock)
                {
                    __probeAssemblies = value;
                }
            }
        }
#else
        public static ReadOnlyCollection<Assembly> ProbeAssemblies
        {
            get
            {
                lock (__lock)
                {
                    if (__assemblyCount == 0 || __assemblyCount != __assemblyLoadedCount)
                    {
                        // Cache the ProbeAssemblies.
                        __probeAssemblies = new ReadOnlyCollection<Assembly>(AppDomain.CurrentDomain.GetAssemblies().Where(a => !IsFrameworkAssembly(a)).ToList());
                        __assemblyCount = __assemblyLoadedCount;
                    }
                    return __probeAssemblies;
                }
            }
        }

        static void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            Interlocked.Increment(ref __assemblyLoadedCount);
        }
        private static int __assemblyCount = 0;
        private static int __assemblyLoadedCount = 0;


#endif

    }
}