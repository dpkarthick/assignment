using AirportApp.Helper;
using AirportApp.Repository;
using System;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace AirportApp
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
       
        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes()
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            //container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            var container = new UnityContainer();
            container.RegisterType<IAirportDataRepository, AirportData>();
            container.RegisterType<ICacheRepository, CacheHelper>();
            container.RegisterType<IGeoLocationRepository, GeoLocationAPI>();
            container.RegisterType<IServiceHelperRepository, ServiceHelper>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}