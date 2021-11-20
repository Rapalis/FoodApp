using System;
using AutoMapper;
using Moq;
using Xunit;
using FoodApp.Services;
using FoodApp.Repositories;
using FoodApp.DataAccess;
using FoodApp.Profiles;
using FoodApp.Models;
using Autofac.Extras.Moq;

namespace UTests
{
    public class ProviderServiceTests
    {
        IProvidersService _ProviderService;
        Mock<IProvidersRepository> moqProvidersRepository = new Mock<IProvidersRepository>();
        IMapper mapper;

        public ProviderServiceTests()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DishProfile());
                cfg.AddProfile(new ProviderProfile());
                cfg.AddProfile(new ReviewProfile());
            }
            );
            mapper = new Mapper(configuration);


            _ProviderService = new ProvidersService(moqProvidersRepository.Object, mapper);
        }

        [Fact]
        public async void AddNewProviderTest()
        {
            const string FakeName = "Vardas";
            const string Address = "Adresas";
            //Arange
            CreateProviderDTO createProviderDto = new CreateProviderDTO
            {
                Name = FakeName,
                Address = Address
            };
            Provider fakeProvider = new Provider
            {
                Id = 1,
                Name = FakeName,
                Address = Address
            };

            moqProvidersRepository.Setup(providerRep => providerRep.CreateAsync(It.Is<Provider>(p => p.Name == FakeName && p.Address == Address)).Result).Returns(fakeProvider);

            //Act
            var result = await _ProviderService.CreateAsync(createProviderDto);

            //Assert
            Assert.NotNull(result);
            moqProvidersRepository.Verify(mock => mock.CreateAsync(It.Is<Provider>(p => p.Name == FakeName && p.Address == Address)), Times.Once());
        }

        [Fact]
        public async void GetAsyncProviderTest()
        {
            const string FakeName = "Vardas";
            const string Address = "Adresas";
            const long Id = 1;
            //Arange
            Provider fakeProvider = new Provider
            {
                Id = Id,
                Name = FakeName,
                Address = Address
            };

            moqProvidersRepository.Setup(providerRep => providerRep.GetAsync(Id).Result).Returns(fakeProvider);

            //Act
            var result = await _ProviderService.GetAsync(Id);

            //Assert
            Assert.NotNull(result);
            moqProvidersRepository.Verify(mock => mock.GetAsync(Id), Times.Once());
        }
        [Fact]
        public async void GetAllAsyncProviderTest()
        {
            const string FakeName = "Vardas";
            const string Address = "Adresas";
            const long Id = 1;

            const string FakeName1 = "Vardas1";
            const string Address1 = "Adresas1";
            const long Id1 = 2;

            Provider[] providers = new Provider[2];
            //Arange
            Provider fakeProvider = new Provider
            {
                Id = Id,
                Name = FakeName,
                Address = Address
            };
            Provider fakeProvider1 = new Provider
            {
                Id = Id1,
                Name = FakeName1,
                Address = Address1
            };
            providers[0] = fakeProvider;
            providers[1] = fakeProvider;

            moqProvidersRepository.Setup(providerRep => providerRep.GetAllAsync().Result).Returns(providers);

            //Act
            var result = await _ProviderService.GetAllAsync();

            //Assert
            Assert.NotNull(result);
            moqProvidersRepository.Verify(mock => mock.GetAllAsync(), Times.Once());
        }
        [Fact]
        public async void UpdateProviderTest()
        {
            const string FakeName = "Vardas";
            const string Address = "Adresas";
            const long Id = 1;
            //Arange
            CreateProviderDTO createProviderDto = new CreateProviderDTO
            {
                Name = FakeName,
                Address = Address
            };
            Provider fakeProvider = new Provider
            {
                Id = Id,
                Name = FakeName,
                Address = Address
            };

            moqProvidersRepository.Setup(providerRep => providerRep.UpdateAsync(It.Is<Provider>(p => p.Name == FakeName && p.Address == Address)).Result).Returns(fakeProvider);

            //Act
            var result = await _ProviderService.UpdateAsync(Id,createProviderDto);

            //Assert
            Assert.NotNull(result);
            moqProvidersRepository.Verify(mock => mock.UpdateAsync(It.Is<Provider>(p => p.Name == FakeName && p.Address == Address)), Times.Once());
        }

        [Fact]
        public async void DeleteProviderTest()
        {
            const long Id = 1;
            //Arange

            moqProvidersRepository.Setup(providerRep => providerRep.DeleteAsync(Id).Result).Returns(true);

            //Act
            var result = await _ProviderService.DeleteAsync(Id);

            //Assert
            Assert.True(result);
            moqProvidersRepository.Verify(mock => mock.DeleteAsync(Id), Times.Once());
        }
    }
}
