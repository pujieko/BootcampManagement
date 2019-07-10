using BootcampManagement.BussinessLogic.Service;
using BootcampManagement.BussinessLogic.Service.Master;
using BootcampManagement.Common.Repositories;
using BootcampManagement.Common.Repositories.Master;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace BootcampManagement.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<ILessonRepository, LessonRepository>();
            container.RegisterType<IProvinceRepository, ProvinceRepository>();
            container.RegisterType<IRegencyRepository, RegencyRepository>();
            container.RegisterType<IDistrictRepository, DistrictRepository>();
            container.RegisterType<IVillageRepository, VillageRepository>();
            container.RegisterType<IReligionRepository, ReligionRepository>();
            container.RegisterType<IBatchRepository, BatchRepository>();
            container.RegisterType<ICompanyRepository, CompanyRepository>();
            container.RegisterType<IRoomRepository, RoomRepository>();
            container.RegisterType<IClassRepository, ClassRepository>();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            container.RegisterType<ILockerRepository, LockerRepository>();

            container.RegisterType<ILessonService, LessonService>();
            container.RegisterType<IProvinceService, ProvinceService>();
            container.RegisterType<IRegencyService, RegencyService>();
            container.RegisterType<IDistrictService, DistrictService>();
            container.RegisterType<IVillageService, VillageService>();
            container.RegisterType<IReligionService, ReligionService>();
            container.RegisterType<IBatchService, BatchService>();
            container.RegisterType<ICompanyService, CompanyService>();
            container.RegisterType<IRoomService, RoomService>();
            container.RegisterType<IClassService, ClassService>();
            container.RegisterType<IEmployeeService, EmployeeService>();
            container.RegisterType<ILockerService, LockerService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}